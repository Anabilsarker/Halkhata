using Halkhata.Database;
using Halkhata.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Halkhata.UC
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : UserControl
    {
        public static Transaction Instance { get { return _instance; } }
        private static Transaction _instance = null;
        public ObservableCollection<ItemData> itemData = new ObservableCollection<ItemData>();
        public Transaction()
        {
            InitializeComponent();
            transaction.ItemsSource = itemData;
            _instance = this;
            itemData.Clear();
            MySqlDatabase.Instance.Read_Table_Expences(Login.UserName);
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            MySqlDatabase.Instance.Update_Table_Expences(Login.UserName, spenton.Text, double.Parse(amount.Text), DateTime.Now.ToString("yyyy-MM-dd"));
            itemData.Clear();
            MySqlDatabase.Instance.Read_Table_Expences(Login.UserName);
        }
    }
}
