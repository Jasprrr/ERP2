using ERP.Models;
using ERP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ERP.Controllers;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for AccountsView.xaml
    /// </summary>
    public partial class AccountsView : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public AccountsView(string search = null)
        {
            InitializeComponent();

            accountList = AccountsController.GetAccounts(search);
        }

        private Account _selectedAccount;
        public Account selectedAccount
        {
            get { return _selectedAccount; }
            set { if (value != null) { _selectedAccount = value; OnPropertyChanged("selectedAccount"); } }
        }

        private ObservableCollection<Account> _accountList;
        public ObservableCollection<Account> accountList
        {
            get { return _accountList ?? (_accountList = new ObservableCollection<Account>()); }
            set { _accountList = value; OnPropertyChanged("accountList"); }
        }

        public int recordCount
        {
            get { return accountList.Count(); }
        }

        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (selectedAccount != null)
            {
                PreviewDrawer.IsRightDrawerOpen = true;
            }
        }

        private void EditAccount_Click(object sender, RoutedEventArgs e)
        {
            var editAccount = new AccountView(selectedAccount.accountID);
            editAccount.Show();
        }

        private void NewAccount_Click(object sender, RoutedEventArgs e)
        {
            var newAccount = new AccountView();
            newAccount.Show();
        }

        private void RefreshAccounts_Click(object sender, RoutedEventArgs e)
        {
            accountList = AccountsController.GetAccounts();
        }
    }
}
