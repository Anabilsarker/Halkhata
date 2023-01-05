using Halkhata.Database;
using Halkhata.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Halkhata.UC
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : UserControl
    {
        public static AdminPanel Instance { get { return _instance; } }
        private static AdminPanel _instance = null;
        public ObservableCollection<UserData> userData = new ObservableCollection<UserData>();
        public AdminPanel()
        {
            InitializeComponent();
            requestedloans.ItemsSource = userData;
            users.ItemsSource = userData;
            _instance = this;
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            usersscroll.Visibility = Visibility.Visible;
            requestedloansscroll.Visibility = Visibility.Collapsed;
            userData.Clear();
            MySqlDatabase.Instance.Read_Table_User();
        }

        private void RequestLoan_Click(object sender, RoutedEventArgs e)
        {
            requestedloansscroll.Visibility = Visibility.Visible;
            usersscroll.Visibility = Visibility.Collapsed;
            userData.Clear();
            MySqlDatabase.Instance.Read_Table_Loan();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.mainwindow.Content = new Login();
        }
    }
}
