using CStore.Model.Services;
using CStore.ViewModel.Base;
using CStore.Views;

namespace CStore.ViewModel
{
    partial class CustomerViewModel: ViewModelBase
    {
        /// <summary>
        /// Customer View
        /// </summary>
        private readonly Customer _customer;

        /// <summary>
        /// Construct the View Model Object
        /// </summary>
        public CustomerViewModel()
        {
            _customerlist = MockData.GetCustomers();
            _customer = new Customer { DataContext = this };
        }

        #region Private Methods

        /// <summary>
        /// Close the Form
        /// </summary>
        private void CloseForm(bool isCancel=false)
        {
            if (isCancel)
            {
                SelectedCustomer = null;
            }

            if (_customer != null)
                _customer.Close();
        }

        #endregion

        #region Public Method

        public void ShowCustomer()
        {
           _customer.ShowDialog();
        }

        #endregion

    }
}
