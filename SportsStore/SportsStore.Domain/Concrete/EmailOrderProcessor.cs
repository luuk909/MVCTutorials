using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace SportsStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "sportsstore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\sports_store_emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings settings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            this.settings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using(var client = new SmtpClient())
            {
                client.EnableSsl = settings.UseSsl;
                client.Host = settings.ServerName;
                client.Port = settings.ServerPort;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(settings.Username, settings.Password);

                if (settings.WriteAsFile)
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    client.PickupDirectoryLocation = settings.FileLocation;
                    client.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder().AppendLine("A new order has been submitted").AppendLine("---").AppendLine("Items:");

                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendLine($"{line.Quantity} x {line.Product.Name} (subtotal: {subtotal.ToString("c")})");
                }

                body.AppendLine($"Total order value: {cart.ComputeTotalValue().ToString("c")}")
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? "")
                    .AppendLine(shippingDetails.Line3 ?? "")
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? "")
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip)
                    .AppendLine("---")
                    .AppendFormat($"Gift wrap: {0}", shippingDetails.GiftWrap ? "Yes" : "No");

                MailMessage message = new MailMessage(settings.MailFromAddress, settings.MailToAddress, "New order submitted", body.ToString());

                if (settings.WriteAsFile)
                {
                    message.BodyEncoding = Encoding.ASCII;
                }

                client.Send(message);
            }
        }
    }
}
