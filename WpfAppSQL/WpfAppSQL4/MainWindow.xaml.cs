using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppSQL4.Models;
using WpfAppSQL4.NorthwindDataSetTableAdapters;

namespace WpfAppSQL4
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

        private void ExpensiveProductButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var northWindDataset = new NorthwindDataSet();
                var tableAdapter = new CustomersTableAdapter();
                tableAdapter.Fill(northWindDataset.Customers);
                dataGrid.ItemsSource = tableAdapter.GetData();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DropTableButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SelectDataSetClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var northWindDataset = dataBase.ExecuteCommandWithAdapterAsync("Select * from Customers", "Customers");
                dataGrid.ItemsSource = northWindDataset.Tables["Customers"]?.DefaultView;

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