using System.Collections.Generic;
using NUnit.Framework;

namespace CStore.Model.Services._Nunit
{
    /// <summary>
    /// Nunits for MockData Class
    /// </summary>
    [TestFixture]
    public class MockDataTest
    {
        /// <summary>
        /// To Test GetItems
        /// </summary>
        [Test]
        public void GetItemsTest()
        {
           List<Item> itemlist = MockData.GetItems();
           Assert.IsNotNull(itemlist);
           Assert.Greater(itemlist.Count, 0);
        }
  
        /// <summary>
        /// Test GetCustomers
        /// </summary>
        [Test]
        public void GetCustomersTest()
        {
            List<Customer> itemlist = MockData.GetCustomers();
            Assert.IsNotNull(itemlist);
            Assert.Greater(itemlist.Count,0);
        }

       
    }
}
