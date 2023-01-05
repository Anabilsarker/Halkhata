using Halkhata.Database;
using Halkhata.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Loan.xaml
    /// </summary>
    public partial class Loan : UserControl
    {
        public static Loan Instance { get { return _instance; } }
        private static Loan _instance = null;
        public ObservableCollection<UserData> userData = new ObservableCollection<UserData>();
        public Loan()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (loanrequestreason.Text != "" || double.Parse(loanrequestamount.Text) != double.NaN || loancategory.SelectedValue != null)
                {
                    MySqlDatabase.Instance.Update_Table_Loan(Login.UserName, loanrequestreason.Text, double.Parse(loanrequestamount.Text), loancategory.Text);
                    MessageBox.Show("Successfully requested for loan");
                }
                else
                {
                    MessageBox.Show("Please Input correct value");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Valid information");
            }
        }
    }
}
