using System.Windows;

namespace CStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Manages the unhandled execption
        /// </summary>
        private void ApplicationDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string message = e.Exception.Message;
            if (e.Exception.InnerException != null)
            {
                message = e.Exception.InnerException.Message;
            }
           
            MessageBox.Show(message, CStore.Properties.Resources.ApplicationTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
