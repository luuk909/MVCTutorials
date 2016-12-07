using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();

            var httpTask = client.GetAsync("http://apress.com");

            //Do other things while waiter for the http request

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedant) =>
            {
                return antecedant.Result.Content.Headers.ContentLength;
            });
        }

        public async static Task<long?> GetPageLengthAsync()
        {
            HttpClient client = new HttpClient();

            var httpMessage = await client.GetAsync("http://apress.com");

            //Do other things while waiter for the http request
            
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}