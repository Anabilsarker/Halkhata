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
using Halkhata.Database;
using Halkhata.UC;
using MaterialDesignThemes.Wpf;

namespace Halkhata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get { return _instance; } }
        private static MainWindow _instance = null;
        public MainWindow()
        {
            InitializeComponent();
            _instance = this;
            //MongoDatabase.InitMongo();
        }
    }
}
