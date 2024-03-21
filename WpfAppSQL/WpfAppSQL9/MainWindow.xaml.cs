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

namespace WpfAppSQL9
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

        private async void CustomerButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new SchoolContext();
                await context.Database.EnsureCreatedAsync();
                // Получаем все отделы из базы данных
                var departments = context.Department.ToList();

                dataGrid.ItemsSource = departments;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void AddItemButtonClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new SchoolContext();
                await context.Database.EnsureCreatedAsync();
                var departments = context.Department.AddAsync(new Models.Department()
                {
                    Name = "Test For Lab",
                    StartDate = DateTime.Parse("2024-01-01"),
                    DepartmentAdministrator = context.Person.FirstOrDefault(),
                    DepartmentID = context.Department.Select(x => x.DepartmentID).Max() + 1,
                    Budget = 10
                });

                await context.SaveChangesAsync();

                MessageBox.Show("Добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void SelectCustomersAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new SchoolContext();
                await context.Database.EnsureCreatedAsync();
                var query = from b in context.Customer
                            orderby b.Name
                            select b;

                dataGrid.ItemsSource = query.ToList();


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
               /* var commandResult = await dataBase
                    .ExecuteProcAsync<SalesByYear>("Sales By Year",
                    new Dictionary<string, object>() { { "@Beginning_Date", "1996-01-01" }, { "@Ending_Date", "1997-01-01" } });
                dataGridProcedure.ItemsSource = commandResult;*/
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