using System.Collections.Generic;
using System.Windows.Input;
using CStore.Model;
using CStore.ViewModel.Base;

namespace CStore.ViewModel
{
    /// <summary>
    /// This partial class has the definition of Binding that has Properties & Commands of ViewModel.
    /// </summary>
    partial class CustomerViewModel
    {
        #region Properties 
       /// <summary>
       /// Gets and Set the List
       /// </summary>
        private List<Customer> _customerlist;
        public List<Customer> CustomerList
        {
            get { return _customerlist; }
            set 
            {
                _customerlist = value;
                RaisePropertyChanged("CustomerList"); 
            }
        }
        
        /// <summary>
        /// Gets and Set the Selected Customer
        /// </summary>
        private Customer _selectedcustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedcustomer; }
            set 
            {
                _selectedcustomer = value;
                RaisePropertyChanged("SelectedCustomer"); 
            }
        } 
        #endregion

        #region Commands

        /// <summary>
        /// Gets the command object to Select the Customer
        /// </summary>
        private ICommand _clickSelectcommand;
        public ICommand SelectCommand
        {
            get
            {
                return _clickSelectcommand ?? (_clickSelectcommand = new Command(p => CloseForm(), q => true));
            }
        }

        /// <summary>
        /// Gets the command object to cancel
        /// </summary>
        private ICommand _cancelcommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelcommand ?? (_cancelcommand = new Command(p => CloseForm(true), q => true));
            }
        }

        #endregion
 
    }
}
