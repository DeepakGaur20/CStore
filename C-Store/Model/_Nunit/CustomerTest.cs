using System.Globalization;
using NUnit.Framework;

namespace CStore.Model._Nunit
{
    /// <summary>
    /// Nunits for Customer that is a model Class 
    /// </summary>
    [TestFixture]
    public class CustomerTest
    {
        /// <summary>
        /// Represents the Item
        /// </summary>
        Customer _customer;
        
        /// <summary>
        /// Configure and Setups all require dependecy 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _customer = new Customer
            {
                Name = "R. Jones",
                CustomerCode = "R. Jones".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "893838832",
                Address = "C-120, Paderborn",
                CardDetails = "HDFC VISA"
            };
        }

        /// <summary>
        /// Destroys the all dependencies and Dispose the objects too.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _customer = null;
        }

        /// <summary>
        /// To Test the Empty Constructor
        /// </summary>
        [Test]
        public void ConstructorTest_WithEmptyConstructor()
        {
            _customer = new Customer();
            Assert.IsNotNull(_customer);
        }
  
        /// <summary>
        /// Test the CustomerCode
        /// </summary>
        [Test]
        public void TestCustomerCode()
        {
            string expectedconst = _customer.Name.GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", "");
            Assert.AreEqual(expectedconst, _customer.CustomerCode);
        }

        /// <summary>
        /// Test the Name
        /// </summary>
        [Test]
        public void TestName()
        {
            const string expectedconst = "R. Jones";
            Assert.AreEqual(expectedconst, _customer.Name);
        }

        /// <summary>
        /// Test the ContactNo
        /// </summary>
        [Test]
        public void TestContactNo()
        {
            const string expectedconst = "893838832";
            Assert.AreEqual(expectedconst, _customer.ContactNo);
        }

        /// <summary>
        /// Test the Address
        /// </summary>
        [Test]
        public void TestAddress()
        {
            const string expectedconst = "C-120, Paderborn";
            Assert.AreEqual(expectedconst, _customer.Address);
        }

        /// <summary>
        /// Test the CardDetails
        /// </summary>
        [Test]
        public void TestCardDetails()
        {
            const string expectedconst = "HDFC VISA";
            Assert.AreEqual(expectedconst, _customer.CardDetails);
        }
    }
}
