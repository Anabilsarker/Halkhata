using Halkhata.Database;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Halkhata.UC
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        MySqlDatabase db;
        public static string UserName { get; set; }
        public Login()
        {
            InitializeComponent();
            db = MySqlDatabase.Instance;
            db.Initialize_DB();
            db.Create_Table_User();
            db.Create_Table_Expences();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.mainwindow.Content = new SignUp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (db.Validate_User(email.Text, password.Password))
            {
                if (email.Text == "admin")
                {
                    MainWindow.Instance.mainwindow.Content = new AdminPanel();
                }
                else
                {
                    UserName = email.Text;
                    MainWindow.Instance.mainwindow.Content = new TabbedMenu();
                }
            }
        }
    }
}
