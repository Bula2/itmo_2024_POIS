using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using WpfAppSQL3;
using WpfAppSQL3.Models;

namespace WpfAppSQL3
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

        private async void ExpensiveProductButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var commandResult = await dataBase.ExecuteProcAsync<ExpensiveProducts>("Ten Most Expensive Products");
                dataGrid.ItemsSource = commandResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void AddTableButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                await dataBase.ExecuteCommandAsync("CREATE TABLE SalesPersons ([SalesPersonID] [int] IDENTITY(1,1) NOT NULL, [FirstName] [nvarchar](50) NULL, [LastName] [nvarchar](50) NULL)", false);
                MessageBox.Show("Таблица добавлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void SelectWithParamsButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var commandResult = await dataBase
                    .ExecuteReaderMethodAsync<Customer>("SELECT CustomerID, CompanyName, City FROM Customers WHERE City = @City", new Dictionary<string, object>() { { "@City", "Berlin" } });
                dataGridInfo.ItemsSource = commandResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void ProcedureWithParamsButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var commandResult = await dataBase
                    .ExecuteProcAsync<SalesByYear>("Sales By Year",
                    new Dictionary<string, object>() { { "@Beginning_Date", "1996-01-01" }, { "@Ending_Date", "1997-01-01" } });
                dataGridProcedure.ItemsSource = commandResult;
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
