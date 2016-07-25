using System.Collections.ObjectModel;
using System.Windows.Input;
using CStore.Model;
using CStore.ViewModel.Base;
using CStore.ViewModel.Enum;

namespace CStore.ViewModel
{
    /// <summary>
    /// This partial class has the definition of Binding that has Properties & Commands of ViewModel.
    /// </summary>
    partial class MainWindowViewModel
    {
        #region Properties 
       /// <summary>
       /// Gets and Set the items
       /// </summary>
        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set 
            {
                _items = value;
                RaisePropertyChanged("Items"); 
            }
        }
        
        /// <summary>
        /// Gets and Set the selected Item
        /// </summary>
        private Item _selectedProduct;
        public Item SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct"); 
            }
        }

        /// <summary>
        /// Gets and Set the selected Customer
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

        /// <summary>
        /// Gets and Set the Visibility
        /// </summary>
        private bool _isVisible;
        public bool IsVisible
        {
            get { return this._isVisible; }
            set
            {
                if (this._isVisible != value)
                {
                    this._isVisible = value;
                    this.RaisePropertyChanged("IsVisible");
                }
            }
        }

        /// <summary>
        /// Represents the Data member price
        /// </summary>
        private double _totalAmount;
        public double TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                RaisePropertyChanged("TotalAmount");
            }
        }
        
        #endregion

        #region Commands

        /// <summary>
        /// Gets the command object of Add Product
        /// </summary>
        private ICommand _customercommand;
        public ICommand CustomerCommand
        {
            get
            {
                return _customercommand ?? (_customercommand = new Command(p => GetCustomer(), q => true));
            }
        }

        /// <summary>
        /// Gets the command object of Add Product
        /// </summary>
        private ICommand _addProductcommand;
        public ICommand AddProductCommand
        {
            get
            {
                return _addProductcommand ?? (_addProductcommand = new Command(p => this.Add(ProductCategary.ByCode), q => CanExecuteAdd()));
            }
        }

        /// <summary>
        /// Gets the command object  
        /// </summary>
        private ICommand _hotdogitemcommand;
        public ICommand HotDogItemCommand
        {
            get
            {
                return _hotdogitemcommand ?? (_hotdogitemcommand = new Command(p => this.Add(ProductCategary.HotDog), q => CanExecuteAdd()));
            }
        }

        /// <summary>
        /// Gets the command object  
        /// </summary>
        private ICommand _slusheeitemcommand;
        public ICommand SlusheeItemCommand
        {
            get
            {
                return _slusheeitemcommand ?? (_slusheeitemcommand = new Command(p => this.Add(ProductCategary.Slushee), q => CanExecuteAdd()));
            }
        }

        /// <summary>
        /// Gets the command object 
        /// </summary>
        private ICommand _colaItemcommand;
        public ICommand ColaItemCommand
        {
            get
            {
                return _colaItemcommand ?? (_colaItemcommand = new Command(p => this.Add(ProductCategary.Cola), q => CanExecuteAdd()));
            }
        }

        /// <summary>
        /// Gets the command object 
        /// </summary>
        private ICommand _corndogItemcommand;
        public ICommand CornDogItemCommand
        {
            get
            {
                return _corndogItemcommand ?? (_corndogItemcommand = new Command(p => this.Add(ProductCategary.CornDog), q => CanExecuteAdd()));
            }
        }

        /// <summary>
        /// Gets the command object 
        /// </summary>
        private ICommand _cheeseBurgeritemcommand;
        public ICommand CheeseBurgerItemCommand
        {
            get
            {
                return _cheeseBurgeritemcommand ?? (_cheeseBurgeritemcommand = new Command(p => this.Add(ProductCategary.CheeseBurger), q => CanExecuteAdd()));
            }
        }
        
        /// <summary>
        /// Gets the command object 
        /// </summary>
        private ICommand _chipsItemcommand;
        public ICommand ChipsItemCommand
        {
            get
            {
                return _chipsItemcommand ?? (_chipsItemcommand = new Command(p => this.Add(ProductCategary.Chips), q => CanExecuteAdd()));
            }
        }
        
        /// <summary>
        /// Gets the command object 
        /// </summary>
        private ICommand _clearcommand;
        public ICommand ClearDataGridCommand
        {
            get
            {
                return _clearcommand ?? (_clearcommand = new Command(p => this.Clear(), q => CanExecuteClear()));
            }
        }

        #endregion
 
    }
}
