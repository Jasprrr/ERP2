using ERP.Model;
using ERP.View;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERP.View
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

        public AccountsView()
        {
            selectedAccount = new Account();
            InitializeComponent();
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
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
        }

        public int recordCount
        {
            get { return accountList.Count(); }
        }

        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(selectedAccount != null)
            {
                PreviewDrawer.IsRightDrawerOpen = true;
            }
        }

        private void EditAccount_Click(object sender, RoutedEventArgs e)
        {
            var editwindow = new AccountView();
            editwindow.Show();
        }
    }
}
