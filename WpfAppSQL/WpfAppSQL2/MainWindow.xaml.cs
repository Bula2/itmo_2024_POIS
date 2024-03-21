using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using WpfAppSQL2.Models;

namespace WpfAppSQL2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataBase dataBase;

        public MainWindow()
        {
            InitializeComponent();
            dataBase = new DataBase();
        }

        private async void ProductCountButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var commandResult = await dataBase.ExecuteScalarMethodAsync("SELECT COUNT(*) FROM Products");
                MessageBox.Show("Количество продуктов: " + commandResult?.ToString() ?? 0.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void ProductNamesButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var commandResult = await dataBase.ExecuteReaderMethodAsync<ProductShort>("SELECT top 20 ProductName FROM Products");
                dataGrid.ItemsSource = commandResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void ProductInfoButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var commandResult = await dataBase.ExecuteReaderMethodAsync<Product>("SELECT top 20 ProductName, UnitPrice, QuantityPerUnit FROM Products");
                dataGridInfo.ItemsSource = commandResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void CommitButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                await dataBase.ExecuteCommandAsync("INSERT INTO Products (ProductName, UnitPrice, QuantityPerUnit) VALUES('Wrong size', 12, '1 boxes')", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void RollbackButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                await dataBase.ExecuteCommandAsync("INSERT INTO Products (ProductName, UnitPrice, QuantityPerUnit) VALUES('Wrong size', 12, '1 boxes')", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
