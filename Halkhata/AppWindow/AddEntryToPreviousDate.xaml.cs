using Halkhata.Database;
using Halkhata.UC;
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
using System.Windows.Shapes;

namespace Halkhata.AppWindow
{
    /// <summary>
    /// Interaction logic for AddEntryToPreviousDate.xaml
    /// </summary>
    public partial class AddEntryToPreviousDate : Window
    {
        public AddEntryToPreviousDate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlDatabase.Instance.Update_Table_Expences(Login.UserName, spenton.Text, double.Parse(amount.Text), datepicker.SelectedDate.Value.ToString("yyyy-MM-dd"));
        }

        private void datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datepicker.SelectedDate.HasValue)
            {
                if (datepicker.SelectedDate.Value < DateTime.Now)
                {
                    addbutton.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Select a Previous date");
                }
            }
        }
    }
}
