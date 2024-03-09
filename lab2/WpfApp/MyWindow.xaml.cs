using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        private readonly string _logPath = "log.txt";

        public MyWindow()
        {
            InitializeComponent();
        }

        private void NewWindowsButtonClick(object sender, RoutedEventArgs e)
        {
            var ownerWindow = (MainWindow)Owner;
            ownerWindow.txtBlock.Text = newWindowsTextBlock.Text;
            Log();
        }

        private void Log()
        {
            using var writer = new StreamWriter(_logPath, true);
            writer.WriteLine("Внесено {0}: {1} ", newWindowsTextBlock.Text,
            DateTime.Now.ToShortDateString() + ", время: " +
            DateTime.Now.ToLongTimeString());
            writer.Flush();
        }
    }
}
