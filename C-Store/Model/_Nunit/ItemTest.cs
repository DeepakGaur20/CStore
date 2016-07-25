using System.Globalization;
using CStore.ViewModel.Enum;
using NUnit.Framework;

namespace CStore.Model._Nunit
{
    /// <summary>
    /// Nunits for Item that is a model Class 
    /// </summary>
    [TestFixture]
    public class ItemTest
    {
        /// <summary>
        /// Represents the Item
        /// </summary>
        Item _productitem;
        
        /// <summary>
        /// Configure and Setups all require dependecy 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            string description = ProductCategary.HotDog.ToString();
            _productitem = new Item
                {
                    Code = description.GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                    Description = description,
                    Qty = 1,
                    Price = 56.00,
                    Discount = 2,
                    TotalQty = 100
                };
        }

        /// <summary>
        /// Destroys the all dependencies and Dispose the objects too.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _productitem = null;
        }

        /// <summary>
        /// To Test the Empty Constructor
        /// </summary>
        [Test]
        public void ConstructorTest_WithEmptyConstructor()
        {
            _productitem = new Item();
            Assert.IsNotNull(_productitem);
        }
  
        /// <summary>
        /// Test the Code
        /// </summary>
        [Test]
        public void TestCode()
        {
            string expectedconst =_productitem.Description.GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", "");
            Assert.AreEqual(expectedconst, _productitem.Code);
        }

        /// <summary>
        /// Test the Description
        /// </summary>
        [Test]
        public void TestDescription()
        {
            const string expectedconst = "HotDog";
            Assert.AreEqual(expectedconst, _productitem.Description);
        }

        /// <summary>
        /// Test the Discount
        /// </summary>
        [Test]
        public void TestDiscount()
        {
            const int expectedconst = 2;
            Assert.AreEqual(expectedconst, _productitem.Discount);
        }

        /// <summary>
        /// Test the Amount
        /// </summary>
        [Test]
        public void TestAmount()
        {
            double expectedvalue = _productitem.Qty * (_productitem.Price - (_productitem.Price * _productitem.Discount / 100));
            Assert.AreEqual(expectedvalue, _productitem.Amount);
        }


        /// <summary>
        /// Test the Discount
        /// </summary>
        [Test]
        public void TestPrice()
        {
            const double expectedconst = 56.00;
            Assert.AreEqual(expectedconst, _productitem.Price);
        }

        /// <summary>
        /// Test the Qty
        /// </summary>
        [Test]
        public void TestQty()
        {
            const int expectedconst = 1;
            Assert.AreEqual(expectedconst, _productitem.Qty);
        }

        /// <summary>
        /// Test the TotalQty
        /// </summary>
        [Test]
        public void TestTotalQty()
        {
            const int expectedconst = 100;
            Assert.AreEqual(expectedconst, _productitem.TotalQty);
        }

        /// <summary>
        /// Test the TotalQty
        /// </summary>
        [Test]
        public void TestRemainingQty()
        {
            const string expectedconst = "Balance HotDog : 100 and consumed : 1";
            Assert.AreEqual(expectedconst, _productitem.RemainingQty);
        }
    }
}
