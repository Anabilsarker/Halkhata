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
using ZstdSharp.Unsafe;

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
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                if (((TabItem)e.AddedItems[0]).Header.ToString() == "Transactaion")
                {
                    transaction.Content = new Transaction();
                }
                else if (((TabItem)e.AddedItems[0]).Header.ToString() == "Expenses")
                {
                    
                }
                else if (((TabItem)e.AddedItems[0]).Header.ToString() == "Loan")
                {

                }
            }
        }
    }
}
