using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            //arrange
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            //act
            var discountTotal = target.ApplyDiscount(total);

            //assert
            Assert.AreEqual(total * 0.9M, discountTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            //arrange
            IDiscountHelper target = getTestObject();

            //act
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDOllarDiscount = target.ApplyDiscount(50);

            //assert
            Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyDOllarDiscount, "$50 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            //arrange
            IDiscountHelper target = getTestObject();

            //act
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);

            //assert
            Assert.AreEqual(5, discount5, "5 dollar discount wrong");
            Assert.AreEqual(0, discount0, "0 dollar discount wrong");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            //arrange
            IDiscountHelper target = getTestObject();

            //act
            target.ApplyDiscount(-1);
        }
    }
}
