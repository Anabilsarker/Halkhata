﻿using Halkhata.Database;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.mainwindow.Content = new Login();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MySqlDatabase.Instance.Update_Table_User(email.Text, password.Text, name.Text, 0.0, 0.0, 0.0);
        }
    }
}
