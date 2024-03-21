using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfAppSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            var connectionStringSettings = ConfigurationManager.ConnectionStrings["DBConnect.Northwind"];
            connection = new SqlConnection(connectionStringSettings.ConnectionString);

            connection.StateChange += new StateChangeEventHandler(ConnectionStateChange);

        }

        private async void OpenButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();

                    MessageBox.Show("Соединение с базой данных " +
                       connection.Database + " выполнено успешно " + "\nСервер: " +
                       connection.DataSource);
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void CloseButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    await connection.CloseAsync();
                    MessageBox.Show("Соединение с базой данных " +
                       connection.Database + " разорвано успешно " + "\nСервер: " +
                       connection.DataSource);
                }
                else
                    MessageBox.Show("Соединение с базой данных уже разорвано");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            //подключитьсяКБД
            if (!openButton.Dispatcher.CheckAccess())
            {
                // Если нет, используем метод Dispatcher.Invoke или Dispatcher.BeginInvoke
                openButton.Dispatcher.Invoke(() =>
                {
                    // Здесь можно изменить свойства элемента управления WPF
                    openButton.IsEnabled = connection.State == ConnectionState.Closed;
                });
            }
            else
            {
                // Если код уже выполняется в потоке пользовательского интерфейса, просто изменяем свойства как обычно
                openButton.IsEnabled = connection.State == ConnectionState.Closed;
            }

            if (!closeButton.Dispatcher.CheckAccess())
            {
                // Если нет, используем метод Dispatcher.Invoke или Dispatcher.BeginInvoke
                closeButton.Dispatcher.Invoke(() =>
                {
                    // Здесь можно изменить свойства элемента управления WPF
                    closeButton.IsEnabled = connection.State == ConnectionState.Open;
                });
            }
            else
            {
                // Если код уже выполняется в потоке пользовательского интерфейса, просто изменяем свойства как обычно
                closeButton.IsEnabled = connection.State == ConnectionState.Open;
            }
        }


    }
}
