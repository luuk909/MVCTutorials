using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountSize / 100m * totalParam));
        }
    }

    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            decimal discount = totalParam > 100 ? 70 : 25;
            return (totalParam - (discount / 100m * totalParam));
        }
    }

    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            if (totalParam < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (totalParam > 100)
            {
                return totalParam * .9M;
            }
            else if (totalParam >= 10 && totalParam <= 100)
            {
                return totalParam - 5;
            }
            else
            {
                return totalParam;
            }
        }
    }
}