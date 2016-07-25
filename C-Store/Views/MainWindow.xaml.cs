using System.Windows;
using CStore.ViewModel;

namespace CStore.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel();
            this.DataContext = vm;
        }
    }
}
