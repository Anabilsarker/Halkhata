using System.Windows.Controls;
using System.Windows.Media;

namespace Halkhata.UC
{
    /// <summary>
    /// Interaction logic for TabbedMenu.xaml
    /// </summary>
    public partial class TabbedMenu : UserControl
    {
        public static TabbedMenu Instance { get { return _instance; } }
        private static TabbedMenu _instance = null;
        public TabbedMenu()
        {
            InitializeComponent();
            _instance = this;
            Transaction_Click(null, null);
        }

        private void Transaction_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            presentContent.Content = new Transaction();

            transaction_button.Width = 160;
            transaction_button.Background = (Brush)new BrushConverter().ConvertFrom("#FF2196F3");
            transaction_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF2196F3");

            expenses_button.Width = 150;
            expenses_button.Background = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
            expenses_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#62B9FF");

            loan_button.Width = 150;
            loan_button.Background = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
            loan_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
        }

        private void Expenses_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            presentContent.Content = new Expenses();

            expenses_button.Width = 160;
            expenses_button.Background = (Brush)new BrushConverter().ConvertFrom("#FF2196F3");
            expenses_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF2196F3");

            transaction_button.Width = 150;
            transaction_button.Background = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
            transaction_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#62B9FF");

            loan_button.Width = 150;
            loan_button.Background = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
            loan_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
        }

        private void Loan_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            presentContent.Content = new Loan();

            loan_button.Width = 160;
            loan_button.Background = (Brush)new BrushConverter().ConvertFrom("#FF2196F3");
            loan_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF2196F3");

            transaction_button.Width = 150;
            transaction_button.Background = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
            transaction_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#62B9FF");

            expenses_button.Width = 150;
            expenses_button.Background = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
            expenses_button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#62B9FF");
        }

        private void Logout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.mainwindow.Content = new Login();
        }
    }
}
