using System;
using System.ComponentModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _path = "username.txt";
        private bool _isDataChanged = false;
        //public MyWindow myWindow;

        public MainWindow()
        {
            InitializeComponent();

            retLabel.Content = "Добрый день!";
        }

        private void SetButtonClick(object sender, RoutedEventArgs e)
        {
            using var streamWriter = new StreamWriter(_path);
            streamWriter.WriteLine(txtBlock.Text);

            retButton.IsEnabled = true;
            Top = 25;
            Left = 25;
        }


        private void RetButtonClick(object sender, RoutedEventArgs e)
        {
            using var streamReader = new StreamReader(_path);
            var user = streamReader.ReadToEnd();
            retLabel.Content = "Приветствую Вас, уважаемый " + user;
        }

        private void OnTextBoxValueChanged(object sender, TextChangedEventArgs e)
        {
            setButton.IsEnabled = true;
            _isDataChanged = true;
        }

        private void OnNewWindowButtonClick(object sender, RoutedEventArgs e)
        {
            var myWindow = new MyWindow()
            {
                Top = this.Top,
                Left = this.Left + this.Width,
                Owner = this,
            };

            myWindow.Show();

        }


        protected override void OnClosing(CancelEventArgs e)
        {
            if (_isDataChanged)
            {
                string msg = "Данные были изменены, но не сохранены!\n Закрыть окно без сохранения ? ";
                var result = MessageBox.Show(msg, "Контроль данных", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            
            base.OnClosing(e);
        }
    }
}