using System.IO;
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

namespace WpfRoutedEvent2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string nameFile = "username.txt";

        public MainWindow()
        {
            InitializeComponent();
            retButton.IsEnabled = false;
        }

        private void SetButton()
        {
            using var sw = new StreamWriter(nameFile);
            sw.WriteLine(setText.Text);
            sw.Close();
            retButton.IsEnabled = true;
        }

        private void RetButton()
        {
            StreamReader sr = new StreamReader(nameFile);
            retLabel.Content = sr.ReadToEnd();
            sr.Close();
        }

        private void GridClick(object sender, RoutedEventArgs e)
        {
            var feSource = e.Source as FrameworkElement;
            try
            {
                switch (feSource?.Name)
                {
                    case "setButton":
                        SetButton();
                        break;
                    case "retButton":
                        RetButton();
                        break;
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}