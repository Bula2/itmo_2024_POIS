using System.Windows;

namespace WpfRoutedEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxFirstTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            MessageBox.Show("Event by textbox");
            e.Handled = (radButton1.IsChecked ?? false);
        }

        private void GridTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            MessageBox.Show("Event by Grid");
            e.Handled = (radButton2.IsChecked ?? false);
        }

        private void WindowTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            MessageBox.Show("Event by Window");
            e.Handled = (radButton3.IsChecked ?? false);
        }
    }
}