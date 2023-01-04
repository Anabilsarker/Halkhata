using Halkhata.AppWindow;
using Halkhata.Database;
using System.Windows.Controls;

namespace Halkhata.UC
{
    /// <summary>
    /// Interaction logic for Expenses.xaml
    /// </summary>
    public partial class Expenses : UserControl
    {
        public Expenses()
        {
            InitializeComponent();
            expenses.ItemsSource = Transaction.Instance.itemData;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string FormattedDate;
                string[] date = e.AddedItems[0].ToString().Split(' ')[0].Split('/');
                FormattedDate = $"{date[2]}-{date[0]}-{date[1]}";
                Transaction.Instance.itemData.Clear();
                MySqlDatabase.Instance.GetExpencesByDate(FormattedDate);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new AddEntryToPreviousDate().Show();
        }
    }
}
