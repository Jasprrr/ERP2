using ERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Net.Mail;
using System.Net;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for QuoteView.xaml
    /// </summary>
    public partial class QuoteView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public QuoteView()
        {
            stepperQuoteCreated = new StepperData() { stage = 1, label = "Quote Created" };
            stepperQuoteClosed = new StepperData() { stage = 1, label = "Quote Closed" };

            selectedQuote = new Quote() { quoteID = 939, dateCreated = DateTime.Now, cost = 35, accountName = "Jasper Co.", billingAddress1 = "123 Fake Street" };

            _accountList = new ObservableCollection<Account>();
            _accountList.Add(new Account() { accountID = 1, accountName = "Bob Co." });
            _accountList.Add(new Account() { accountID = 1, accountName = "Tim Co." });
            _accountList.Add(new Account() { accountID = 1, accountName = "Rob Co." });
            _accountList.Add(new Account() { accountID = 1, accountName = "Sam Co." });

            _contactList = new ObservableCollection<Contact>();
            _contactList.Add(new Contact() { contactID = 1, accountID = 1, firstName = "Jasper", lastName = "Friend" });
            _contactList.Add(new Contact() { contactID = 1, accountID = 1, firstName = "Repsaj", lastName = "Dneirf" });

            _departments = new ObservableCollection<Department>();
            _departments.Add(new Department() { departmentID = 1, department = "Masking", nominalCode = 4000, rateCost = (decimal)1.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 2, department = "Wet Paint", nominalCode = 4010, rateCost = (decimal)2.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 3, department = "Powder coating", nominalCode = 4020, rateCost = (decimal)3.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 4, department = "Fine paint", nominalCode = 4030, rateCost = (decimal)4.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 5, department = "CNC machine room", nominalCode = 4040, rateCost = (decimal)5.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 6, department = "Anodising", nominalCode = 4050, rateCost = (decimal)6.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 7, department = "Alocrom", nominalCode = 4060, rateCost = (decimal)7.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 8, department = "Iridite", nominalCode = 4070, rateCost = (decimal)8.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 9, department = "Laser engraving", nominalCode = 4080, rateCost = (decimal)9.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 10, department = "Engraving", nominalCode = 4090, rateCost = (decimal)10.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 11, department = "Printing", nominalCode = 4099, rateCost = (decimal)11.00, initalCost = 0 });

            timeList = new ObservableCollection<QuoteTime>();
            timeList.Add(new QuoteTime() { selected = true, timeID = 1, line = 1, department = "Masking", rate = 60, cost = 60, total = 60, estimatedTime = (decimal)1.2, dateCreated = DateTime.Now, dateModified = DateTime.Now, nominalCode = 4010 });
            timeList.Add(new QuoteTime() { selected = false, timeID = 2, line = 2, department = "Alocrom", rate = 60, cost = 60, total = 60, estimatedTime = (decimal)3.4, dateCreated = DateTime.Now, dateModified = DateTime.Now, nominalCode = 4020 });
            timeList.Add(new QuoteTime() { selected = true, timeID = 3, line = 3, department = "Iridite", rate = 60, cost = 60, total = 60, estimatedTime = (decimal)5.6, dateCreated = DateTime.Now, dateModified = DateTime.Now, nominalCode = 4030 });
            timeList.Add(new QuoteTime() { selected = false, timeID = 4, line = 4, department = "Printing", rate = 60, cost = 60, total = 60, estimatedTime = (decimal)7.8, dateCreated = DateTime.Now, dateModified = DateTime.Now, nominalCode = 4040 });
            timeList.Add(new QuoteTime() { selected = true, timeID = 5, line = 5, department = "Engraving", rate = 60, cost = 60, total = 60, estimatedTime = (decimal)9.0, dateCreated = DateTime.Now, dateModified = DateTime.Now, nominalCode = 4050 });

            _userList = new ObservableCollection<User>();
            _userList.Add(new User() { firstName = "Jasper", lastName = "Friend" });

            _itemList = new ObservableCollection<QuoteItem>();
            _itemList.Add(new QuoteItem() { ID = 1, itemCode = "0A001-1585", cost = 50, quantity = 1, line = 1, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 2, itemCode = "0A020-0229", cost = 150, quantity = 2, line = 2, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 3, itemCode = "0A058-0437", cost = 250, quantity = 3, line = 3, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 4, itemCode = "0A058-0451", cost = 350, quantity = 4, line = 4, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 5, itemCode = "0A061-0205", cost = 450, quantity = 5, line = 5, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 6, itemCode = "0A061-0209", cost = 20, quantity = 6, line = 6, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 7, itemCode = "0A063-0369", cost = 30, quantity = 7, line = 7, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 8, itemCode = "0A063-0561", cost = 250, quantity = 8, line = 8, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 9, itemCode = "0A066-0515", cost = 250, quantity = 9, line = 9, internalDescription = "789-XYZ" });
            _itemList.Add(new QuoteItem() { ID = 10, itemCode = "0A069-0167", cost = 250, quantity = 10, line = 10, internalDescription = "789-XYZ" });

            _standardItems = new ObservableCollection<QuoteItem>();
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 1, internalDescription = "Test internal description", externalDescription = "Test external description" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 2, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 3, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 4, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 5, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 6, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 7, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 8, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 9, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 10, internalDescription = "Test internal description", externalDescription = "Test external description;" });

            _todoList = new ObservableCollection<Todo>();
            _todoList.Add(new Todo() { todoID = 1, startDate = new DateTime(2008, 1, 1), account = "Acc 01", subject = "Lorem ipsum.", completed = false, contact="Jasper Friend" });
            _todoList.Add(new Todo() { todoID = 2, startDate = new DateTime(2008, 2, 1), account = "Acc 02", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 3, startDate = new DateTime(2008, 3, 1), account = "Acc 03", subject = "Lorem ipsum.", completed = false, contact="Jasper Friend" });
            _todoList.Add(new Todo() { todoID = 4, startDate = new DateTime(2008, 4, 1), account = "Acc 04", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 5, startDate = new DateTime(2008, 5, 1), account = "Acc 05", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 6, startDate = new DateTime(2008, 6, 1), account = "Acc 06", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 7, startDate = new DateTime(2008, 7, 1), account = "Acc 07", subject = "Lorem ipsum.", completed = false, contact = "Jasper Friend" });

            InitializeComponent();
        }

        private void SetUp()
        {
            //TODO: Get Departments
            //TODO: Get SupplierList
            //TODO: Get AccountList
            //TODO: Get ContactList
            //TODO: Get UserList
            //TODO: Get ItemList
            //TODO: Get TimeList
            //TODO: Get MaterialList
            //TODO: Get SubcontractorList
            //TODO: Get TaskList
        }

        #region Variables

        private StepperData _stepperQuoteCreated;
        public StepperData stepperQuoteCreated
        {
            get { return _stepperQuoteCreated ?? (_stepperQuoteCreated = new StepperData()); }
            set { if (value != null) { _stepperQuoteCreated = value; OnPropertyChanged("stepperQuoteCreated"); } }
        }

        private StepperData _stepperQuoteClosed;
        public StepperData stepperQuoteClosed
        {
            get { return _stepperQuoteClosed ?? (_stepperQuoteClosed = new StepperData()); }
            set { if (value != null) { _stepperQuoteClosed = value; OnPropertyChanged("stepperQuoteClosed"); } }
        }

        private ObservableCollection<Account> _accountList;
        public ObservableCollection<Account> accountList
        {
            get { return _accountList ?? (_accountList = new ObservableCollection<Account>()); }
        }

        private ObservableCollection<Contact> _contactList;
        public ObservableCollection<Contact> contactList
        {
            get { return _contactList ?? (_contactList = new ObservableCollection<Contact>()); }
        }

        private ObservableCollection<User> _userList;
        public ObservableCollection<User> userList
        {
            get { return _userList ?? (_userList = new ObservableCollection<User>()); }
        }

        private ObservableCollection<User> _userTaskList;
        public ObservableCollection<User> userTaskList
        {
            get { return _userTaskList ?? (_userTaskList = new ObservableCollection<User>()); }
        }

        private Quote _selectedQuote;
        public Quote selectedQuote
        {
            get { return _selectedQuote; }
            set { if (value != null) { _selectedQuote = value; OnPropertyChanged("selectedQuote"); } }
        }

        private Account _selectedAccount;
        public Account selectedAccount
        {
            get { return _selectedAccount; }
            set { if (value != null) { _selectedAccount = value; OnPropertyChanged("selectedAccount"); selectedQuote.accountName = selectedAccount.accountName; OnPropertyChanged("selectedQuote"); } }
        }

        private Contact _selectedContact;
        public Contact selectedContact
        {
            get { return _selectedContact; }
            set { if (value != null) { _selectedContact = value; OnPropertyChanged("selectedContact"); } }
        }

        private ObservableCollection<Todo> _todoList;
        public ObservableCollection<Todo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<Todo>()); }
        }

        private Todo _selectedToDo;
        public Todo selectedToDo
        {
            get { return _selectedToDo; }
            set { if (value != null) { _selectedToDo = value; } }
        }

        //Items
        private ObservableCollection<QuoteItem> _itemList;
        public ObservableCollection<QuoteItem> itemList
        {
            get { return _itemList ?? (_itemList = new ObservableCollection<QuoteItem>()); }
        }

        private int _selectedItem;
        public int selectedItem
        {
            get { return _selectedItem; }
            set { if (value != null) { _selectedItem = value; OnPropertyChanged("selectedItem"); } }
        }

        //Times
        private ObservableCollection<QuoteTime> _timeList;
        public ObservableCollection<QuoteTime> timeList
        {
            get { return _timeList; }
            set { if (value != null) { _timeList = value; OnPropertyChanged("timeList"); } }
        }

        private int _selectedTime;
        public int selectedTime
        {
            get { return _selectedTime; }
            set { _selectedTime = value; OnPropertyChanged("selectedTime"); }
        }

        //Standard Items
        private static ObservableCollection<QuoteItem> _standardItems;
        public static ObservableCollection<QuoteItem> standardItems
        {
            get { return _standardItems ?? (_standardItems = new ObservableCollection<QuoteItem>()); }
        }

        private QuoteItem _selectedStandardItem;
        public QuoteItem selectedStandardItem
        {
            get { return _selectedStandardItem; }
            set
            {
                if (value != null)
                {
                    _selectedStandardItem = value;
                    OnPropertyChanged("selectedStandardItem");
                }
            }
        }

        //Departments
        private static ObservableCollection<Department> _departments;
        public static ObservableCollection<Department> departments
        {
            get { return _departments ?? (_departments = new ObservableCollection<Department>()); }
        }

        private Department _selectedItemDepartment;
        public Department selectedItemDepartment
        {
            get { return _selectedItemDepartment; }
            set
            {
                if (value != null)
                {
                    _selectedItemDepartment = value;
                    OnPropertyChanged("selectedItemDepartment");
                }
            }
        }

        private Department _selectedTimeDepartment;
        public Department selectedTimeDepartment
        {
            get { return _selectedTimeDepartment; }
            set
            {
                if (value != null)
                {
                    _selectedTimeDepartment = value;
                    OnPropertyChanged("selectedTimeDepartment");
                }
            }
        }
        #endregion

        #region Events

        #endregion
        private void DeleteDialog_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Stepper_Click(object sender, RoutedEventArgs e)
        {
            if (stepperQuoteClosed.stage == 1 || stepperQuoteClosed.stage == 3)
            {
                stepperQuoteClosed.stage = 2;
                stepperQuoteClosed.label = "Closed Won";
                OnPropertyChanged("stepperQuoteClosed");
            }
            else if (stepperQuoteClosed.stage == 2)
            {
                stepperQuoteClosed.stage = 3;
                stepperQuoteClosed.label = "Closed Lost";
                OnPropertyChanged("stepperQuoteClosed");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        //---------------------------------------------------------------

        private void NewTime_Click(object sender, RoutedEventArgs e)
        {
            timeList.Add(new QuoteTime() { nominalCode = selectedAccount != null ? selectedAccount.defaultNominalCode : 4000, line = timeList.Max(p => p.line) + 1 });
        }

        private void EditTime_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow row = TimeList.ItemContainerGenerator.ContainerFromIndex(selectedTime) as DataGridRow;
            if (row != null)
            {
                row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void DeleteTime_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog.IsOpen = !DeleteDialog.IsOpen;
        }

        private void NewItem_Click(object sender, RoutedEventArgs e)
        {
            itemList.Add(new QuoteItem() { nominalCode = selectedAccount != null ? selectedAccount.defaultNominalCode : 4000, line = itemList.Max(p => p.line) + 1 });
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow row = ItemList.ItemContainerGenerator.ContainerFromIndex(selectedItem) as DataGridRow;
            if (row != null)
            {
                row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void RefreshItems_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog.IsOpen = true;
        }

        private void RelatedCallItem_EditCall(object sender, RoutedEventArgs e)
        {
            //TODO: Edit call
        }

        private void RelatedTodoItem_CompleteTodo(object sender, RoutedEventArgs e)
        {
            //TODO: Complete todo
        }

        private void RelatedOrderItem_EditOrder(object sender, RoutedEventArgs e)
        {
            //TODO: Edit order
        }

        private void NewTodo_Click(object sender, RoutedEventArgs e)
        {
            var TodoWindow = new TodoView();
            TodoWindow.Show();
        }

        private void NewCalls_Click(object sender, RoutedEventArgs e)
        {
            var CallWindow = new CallView();
            CallWindow.Show();
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            //var OrderWindow = new OrderView();
            //OrderWindow.Show();
        }
    }
}
