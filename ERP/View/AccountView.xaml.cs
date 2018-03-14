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
using ERP.Model;
using System.Collections.ObjectModel;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class AccountView : Window
    {
        public AccountView(int accountID)
        {
            Debug.Print(accountID.ToString());
            _todoList = new ObservableCollection<ToDo>();
            InitializeComponent();
            _accountList.Add(new Account() { accountCode = "TIMC", name = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", name = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", name = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", name = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", name = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", name = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", name = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", name = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", name = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", name = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", name = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", name = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", name = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", name = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", name = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", name = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", name = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", name = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", name = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", name = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });
            _accountList.Add(new Account() { accountCode = "TIMC", name = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", name = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", name = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", name = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", name = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });

            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 1, 1), account = "Acc 01", description = "Lorem ipsum.", complete = false });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 2, 1), account = "Acc 02", description = "Lorem ipsum.", complete = false });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 3, 1), account = "Acc 03", description = "Lorem ipsum.", complete = false });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 4, 1), account = "Acc 04", description = "Lorem ipsum.", complete = false });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 5, 1), account = "Acc 05", description = "Lorem ipsum.", complete = false });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 6, 1), account = "Acc 06", description = "Lorem ipsum.", complete = false });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 7, 1), account = "Acc 07", description = "Lorem ipsum.", complete = false });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 8, 1), account = "Acc 08", description = "Lorem ipsum.", complete = false });
        }

        private ObservableCollection<ToDo> _todoList;
        public ObservableCollection<ToDo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<ToDo>()); }
        }

        private Account _selectedItem;
        public Account selectedItem
        {
            get { return _selectedItem; }
            set { if (value != null) { _selectedItem = value; } }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string theValue = button.Tag.ToString();
            Debug.Print(theValue);
            var newWindow = new AccountView(1);
            newWindow.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void saveCommand_Click(object sender, RoutedEventArgs e)
        {
            //use the message queue to send a message.
            var messageQueue = SnackbarThree.MessageQueue;
            var message = "Saved";

            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }
    }
}
