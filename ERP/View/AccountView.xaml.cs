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
using System.Diagnostics;
using MaterialDesignThemes.Wpf;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class AccountView : Window
    {
        public AccountView(int accountID)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Debug.Print(accountID.ToString());
            InitializeComponent();
        }
    }
}
