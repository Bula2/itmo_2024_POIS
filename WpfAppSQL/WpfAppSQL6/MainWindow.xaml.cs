using System.Data;
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
using WpfAppSQL6.NorthwindDataSetTableAdapters;

namespace WpfAppSQL6
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

        private void WriteXMLButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var northWindDataset = new NorthwindDataSet();
                var tableAdapter = new CustomersTableAdapter();
                tableAdapter.Fill(northWindDataset.Customers);

                northWindDataset.WriteXml("Northwind.xml");
                MessageBox.Show("Data save as XML");

                northWindDataset.WriteXmlSchema("Northwind.xsd");
                MessageBox.Show("Schema save as XML");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReadXMLMLButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet northWindDataset = new DataSet();
                northWindDataset.ReadXmlSchema("Northwind.xsd");
                northWindDataset.ReadXml("Northwind.xml");

                dataGrid.ItemsSource = northWindDataset.Tables["Customers"]?.DefaultView;



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