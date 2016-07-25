using System;
using System.Collections.Generic;
using System.Globalization;
using CStore.ViewModel.Enum;

namespace CStore.Model.Services
{
    public class MockData
    {
        /// <summary>
        /// Gets the List of Items
        /// </summary>
        /// <returns>List of Items</returns>
        public static List<Item> GetItems()
        {
            var itemsList = new List<Item>();

            foreach (var product in Enum.GetValues(typeof(ProductCategary)))
            {
                string description = product.ToString();
                var productitem = new Item
                {
                    Code = description.GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                    Description = description,
                    Qty = 1
                };

                switch ((ProductCategary) product)
                {
                    case ProductCategary.HotDog:
                        productitem.Price = 56.00;
                        productitem.Discount = 2;
                        productitem.TotalQty = 100;
                        break;

                    case ProductCategary.Slushee:
                        productitem.Price = 28.80;
                        productitem.Discount = 2;
                        productitem.TotalQty = 100;
                        break;

                    case ProductCategary.Cola:
                        productitem.Price = 10.18;
                        productitem.Discount = 4;
                        productitem.TotalQty = 100;
                        break;

                    case ProductCategary.CornDog:
                        productitem.Price = 40.99;
                        productitem.Discount = 2;
                        productitem.TotalQty = 100;
                        break;

                    case ProductCategary.CheeseBurger:
                    case ProductCategary.Chips:
                        productitem.Price = 20.00;
                        productitem.Discount =2;
                        productitem.TotalQty = 100;
                        break;

                    default:
                        productitem.Description = "<not available>";
                        productitem.Price = 20.0;
                        productitem.Discount = 2;
                        productitem.TotalQty = 100;
                        break;
                }

                itemsList.Add(productitem);
            }


            return itemsList;
        }

        /// <summary>
        /// Gets the Customer
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomers()
        {
            var customerList = new List<Customer>();
            var productitem = new Customer
            {
                Name = "R. Jones",
                CustomerCode = "R. Jones".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "893838832",
                Address = " C-120, Paderborn",
                CardDetails = "HDFC VISA"
            };
            customerList.Add(productitem);
            var productitem1 = new Customer
            {
                Name = "Peter Schwidt",
                CustomerCode = "Peter Schwidt".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "893555832",
                Address = " H-55, Paderborn",
                CardDetails = "HDFC VISA"
            };
            customerList.Add(productitem1);

            var productitem2 = new Customer
            {
                Name = "Michael Zimadar",
                CustomerCode = "Michael Zimadar".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "75467657",
                Address = " B-98, Paderborn",
                CardDetails = "HDFC VISA"
            };
            customerList.Add(productitem2);
            var productitem3 = new Customer
            {
                Name = "Markus Beller",
                CustomerCode = "Markus Beller".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "7567865885",
                Address = " A-120, Osny",
                CardDetails = "HDFC VISA"
            };
            customerList.Add(productitem3);
            var productitem4 = new Customer
            {
                Name = "Rajiv Arora",
                CustomerCode = "Rajiv Arora".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "56757577",
                Address = " B-02, Frankfurt",
                CardDetails = "HDFC VISA"
            };
            customerList.Add(productitem4);
            var productitem5 = new Customer
            {
                Name = "Manish Singh",
                CustomerCode = "Manish Singh".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "475567777",
                Address = " H-120, India",
                CardDetails = "HDFC VISA"
            };
            customerList.Add(productitem5);
            var productitem6 = new Customer
            {
                Name = "Maria D'costa",
                CustomerCode = "Maria D'costa".GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", ""),
                ContactNo = "7634634747",
                Address = " C-120, Paderborn",
                CardDetails = "HDFC VISA"
            };
            customerList.Add(productitem6);

            return customerList;
        }


    }
}
