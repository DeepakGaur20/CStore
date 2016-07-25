using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using CStore.Model;
using CStore.Model.Services;
using CStore.ViewModel.Base;
using CStore.ViewModel.Enum;
using System.Windows.Threading;
using CStore.Properties;

namespace CStore.ViewModel
{
    partial class MainWindowViewModel: ViewModelBase
    {
        /// <summary>
        /// Represents the Default stock of items
        /// </summary>
        private readonly List<Item> _mockProductItems;

        /// <summary>
        /// Construct the View Model Object
        /// </summary>
        public MainWindowViewModel()
        {
            _mockProductItems = MockData.GetItems();    
        }

        #region Private Methods

        /// <summary>
        /// Clears the Data Bindings
        /// </summary>
        private void Clear()
        {
            Items.Clear();
            Items = null;
            SelectedProduct = null;
        }
        
        /// <summary>
        /// Can Execute Clear
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanExecuteClear()
        {
            if (Items != null && Items.Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Can Execute Add Product
        /// </summary>
        /// <returns>True or False</returns>
        private bool CanExecuteAdd()
        {
            if ((_mockProductItems != null && _mockProductItems.Count > 0) && SelectedCustomer!=null)
                return true;

            return false;
        }

        /// <summary>
        /// Gets the Customer
        /// </summary>
        private void GetCustomer()
        {
            var customer = new CustomerViewModel();
            customer.ShowCustomer();
            if (SelectedCustomer == null)
            {
                SelectedCustomer = customer.SelectedCustomer;
            }
            else if (Items != null && Items.Count > 0 && customer.SelectedCustomer != null && customer.SelectedCustomer.CustomerCode != SelectedCustomer.CustomerCode)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(SelectedCustomer.Name + Resources.ConfirmationMessage, Resources.ApplicationTitle, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    SelectedCustomer = customer.SelectedCustomer;
                    Clear();
                }
            }
            else if(customer.SelectedCustomer!=null && customer.SelectedCustomer.CustomerCode != SelectedCustomer.CustomerCode)
            {
                SelectedCustomer = customer.SelectedCustomer;
            }
        }
        
        /// <summary>
        /// Adds the Qty of Item
        /// </summary>
        private void Add(ProductCategary product)
        {
            Item toUpdate = null;
            if (Items == null)
            {
                Items = new ObservableCollection<Item>();
            }

            // Get the Product Code
            string code = product.ToString().GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", "");

            if (Items != null && Items.Count > 0)
            {
                toUpdate = Items.SingleOrDefault(x => x.Code == code);
            }

            // Get the Product Item with Default Quantity 1
            var defaultAdditem = this._mockProductItems.SingleOrDefault(x => x.Code == code);
            if (defaultAdditem != null && toUpdate==null)
            {
                defaultAdditem.Qty = 1;
                defaultAdditem.TotalQty = 100;
            }

            // Get the Product Item to increase the Quantity
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Render, new Action(() =>
                {
                    if (toUpdate != null)
                    {
                        int index = Items.IndexOf(toUpdate);
                        this.UpdateQty(toUpdate);
                        this.Items.RemoveAt(index);
                        this.Items.Insert(index, toUpdate);
                    }
                    else if (defaultAdditem != null)
                    {
                        this.AddQty(defaultAdditem);
                    }
                }));

            // Calculate the Total Amount
            CalculateTotalAmount();
        }

        /// <summary>
        /// Adds the Quantity
        /// </summary>
        /// <param name="defaultAdditem"> The Item</param>
        /// <param name="qty">The Quantity default is 1</param>
        private void AddQty(Item defaultAdditem, int qty=1)
        {
            // To Decrease the Total Quantity of Product because one more quantity is consumed
            defaultAdditem.TotalQty = defaultAdditem.TotalQty - qty;
            this.Items.Add(defaultAdditem);
        }

        /// <summary>
        /// Updates the Quantity 
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <param name="qty">The Quantity default is 1</param>
        private void UpdateQty(Item toUpdate, int qty=1)
        {                           
            // increase the Quantity if Item is already exist in row
            toUpdate.Qty = toUpdate.Qty + qty;

            // To Decrease the Total Quantity of Product because one more quantity is consumed
            toUpdate.TotalQty = toUpdate.TotalQty - qty;
        }

        /// <summary>
        /// Calculates the Total Amount
        /// </summary>
        private void CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var item in Items)
            {
                TotalAmount = TotalAmount + item.Amount;
                TotalAmount = Math.Round(TotalAmount, 2);
            }
        }
        
        /// <summary>
        /// Minus the Qty of Item
        /// </summary>
        private void Minus(ProductCategary product)
        {
            string code = product.ToString().GetHashCode().ToString(CultureInfo.InvariantCulture).Replace("-", "");
            var toUpdate = Items.SingleOrDefault(x => x.Code == code);
            if (toUpdate != null)
            {
                toUpdate.Qty = toUpdate.Qty - 1;
                toUpdate.TotalQty = toUpdate.TotalQty + 1;
                CalculateTotalAmount();
            }
        }

        #endregion
 
    }
}
