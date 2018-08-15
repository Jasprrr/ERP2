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
            selectedQuote = new Quote() { quoteID = 1, dateCreated = DateTime.Now, cost = 35, userName = "Jasper", accountName = "Jasper Co.", billingAddress1 = "123 Fake Street" };

            selectedQuote = new Quote() { quoteID = 1, dateCreated = DateTime.Now, cost = 35, userName = "Jasper", accountName = "Jasper Co.", billingAddress1 = "123 Fake Street" };

            _accountList = new ObservableCollection<Account>();
            _accountList.Add(new Account() { accountID = 1, accountName = "Bob Co." });
            _accountList.Add(new Account() { accountID = 1, accountName = "Tim Co." });
            _accountList.Add(new Account() { accountID = 1, accountName = "Rob Co." });
            _accountList.Add(new Account() { accountID = 1, accountName = "Sam Co." });

            _contactList = new ObservableCollection<Contact>();
            _contactList.Add(new Contact() { contactID = 1, accountID = 1, forename = "Jasper", surname = "Friend" });
            _contactList.Add(new Contact() { contactID = 1, accountID = 1, forename = "Repsaj", surname = "Dneirf" });

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

            _userList = new ObservableCollection<User>();
            _userList.Add(new User() { forename = "Jasper", surname = "Friend" });
            _userList.Add(new User() { forename = "Jasper", surname = "Friend" });
            _userList.Add(new User() { forename = "Jasper", surname = "Friend" });
            _userList.Add(new User() { forename = "Jasper", surname = "Friend" });
            _userList.Add(new User() { forename = "Jasper", surname = "Friend" });
            _userList.Add(new User() { forename = "Jasper", surname = "Friend" });

            _supplierList = new ObservableCollection<Supplier>();
            _supplierList.Add(new Supplier() { ID = 1, name = "Supplier 1" });
            _supplierList.Add(new Supplier() { ID = 2, name = "Supplier 2" });
            _supplierList.Add(new Supplier() { ID = 3, name = "Supplier 3" });
            _supplierList.Add(new Supplier() { ID = 4, name = "Supplier 4" });
            _supplierList.Add(new Supplier() { ID = 5, name = "Supplier 5" });

            _quoteItemList = new ObservableCollection<QuoteItem>();
            _quoteItemList.Add(new QuoteItem() { ID = 1, itemCode = "0A001-1585", cost = 50, quantity = 1, line = 1, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 2, itemCode = "0A020-0229", cost = 150, quantity = 2, line = 2, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 3, itemCode = "0A058-0437", cost = 250, quantity = 3, line = 3, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 4, itemCode = "0A058-0451", cost = 350, quantity = 4, line = 4, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 5, itemCode = "0A061-0205", cost = 450, quantity = 5, line = 5, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 6, itemCode = "0A061-0209", cost = 20, quantity = 6, line = 6, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 7, itemCode = "0A063-0369", cost = 30, quantity = 7, line = 7, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 8, itemCode = "0A063-0561", cost = 250, quantity = 8, line = 8, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 9, itemCode = "0A066-0515", cost = 250, quantity = 9, line = 9, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 10, itemCode = "0A069-0167", cost = 250, quantity = 10, line = 10, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 11, itemCode = "0A071-0399", cost = 250, quantity = 11, line = 11, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 12, itemCode = "0A071-0401", cost = 250, quantity = 12, line = 12, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 13, itemCode = "0A090-0453", cost = 250, quantity = 13, line = 13, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 14, itemCode = "0A099-0455", cost = 250, quantity = 14, line = 14, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 15, itemCode = "0A134-0541", cost = 250, quantity = 15, line = 15, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 16, itemCode = "0A134-0543", cost = 250, quantity = 16, line = 16, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 17, itemCode = "0A188-0361", cost = 250, quantity = 17, line = 17, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 18, itemCode = "0A188-0363", cost = 250, quantity = 18, line = 18, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 19, itemCode = "0A201-0663", cost = 250, quantity = 19, line = 19, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 20, itemCode = "0A201-0665", cost = 250, quantity = 20, line = 20, internalDescription = "789-XYZ" });

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
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", cost = 50, quantity = 4, line = 11, internalDescription = "Test internal description", externalDescription = "Test external description;" });

            _quoteMaterialList = new ObservableCollection<QuoteMaterial>();
            _quoteMaterialList.Add(new QuoteMaterial() { ID = 1, supplier = "Tim Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { ID = 2, supplier = "Bob Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { ID = 3, supplier = "Tom Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { ID = 4, supplier = "Rob Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { ID = 5, supplier = "Sam Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { ID = 6, supplier = "Jim Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });

            _quoteSubcontractorList = new ObservableCollection<QuoteSubcontractor>();
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { ID = 1, supplier = "Tim Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { ID = 2, supplier = "Bob Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { ID = 3, supplier = "Tom Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { ID = 4, supplier = "Rob Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { ID = 5, supplier = "Sam Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { ID = 6, supplier = "Jim Co.", cost = 100, rate = 35, notes = "Lorem ipsum." });

            _todoList = new ObservableCollection<ToDo>();
            _todoList.Add(new ToDo() { ID = 1, dueDate = new DateTime(2008, 1, 1), account = "Acc 01", description = "Lorem ipsum.", complete = false, taskType = "Task" });
            _todoList.Add(new ToDo() { ID = 2, dueDate = new DateTime(2008, 2, 1), account = "Acc 02", description = "Lorem ipsum.", complete = false, taskType = "Task" });
            _todoList.Add(new ToDo() { ID = 3, dueDate = new DateTime(2008, 3, 1), account = "Acc 03", description = "Lorem ipsum.", complete = false, taskType = "Task" });
            _todoList.Add(new ToDo() { ID = 4, dueDate = new DateTime(2008, 4, 1), account = "Acc 04", description = "Lorem ipsum.", complete = false, taskType = "Task" });
            _todoList.Add(new ToDo() { ID = 5, dueDate = new DateTime(2008, 5, 1), account = "Acc 05", description = "Lorem ipsum.", complete = false, taskType = "Task" });
            _todoList.Add(new ToDo() { ID = 6, dueDate = new DateTime(2008, 6, 1), account = "Acc 06", description = "Lorem ipsum.", complete = false, taskType = "Task" });
            _todoList.Add(new ToDo() { ID = 7, dueDate = new DateTime(2008, 7, 1), account = "Acc 07", description = "Lorem ipsum.", complete = false, taskType = "Task" });

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

        private Delete _deleteObject;
        public Delete deleteObject
        {
            get { return _deleteObject ?? (_deleteObject = new Delete()); }
            set { if (value != null) { _deleteObject = value; OnPropertyChanged("deleteObject"); } }
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

        private ObservableCollection<ToDo> _todoList;
        public ObservableCollection<ToDo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<ToDo>()); }
        }

        private ToDo _selectedToDo;
        public ToDo selectedToDo
        {
            get { return _selectedToDo; }
            set { if (value != null) { _selectedToDo = value; } }
        }

        //Items
        private ObservableCollection<QuoteItem> _quoteItemList;
        public ObservableCollection<QuoteItem> quoteItemList
        {
            get { return _quoteItemList ?? (_quoteItemList = new ObservableCollection<QuoteItem>()); }
        }

        private QuoteItem _selectedItem;
        public QuoteItem selectedItem
        {
            get { return _selectedItem; }
            set { if (value != null) { _selectedItem = value; OnPropertyChanged("selectedItem"); } }
        }

        //Times
        private ObservableCollection<QuoteTime> _quoteTimeList;
        public ObservableCollection<QuoteTime> quoteTimeList
        {
            get { return _quoteTimeList ?? (_quoteTimeList = new ObservableCollection<QuoteTime>()); }
        }

        private QuoteTime _selectedTime;
        public QuoteTime selectedTime
        {
            get { return _selectedTime; }
            set { if (value != null) { _selectedTime = value; } }
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

                    if (selectedItem.itemCode != _selectedStandardItem.itemCode)
                    {
                        selectedItem.itemCode = _selectedStandardItem.itemCode;
                        selectedItem.nominalCode = _selectedStandardItem.nominalCode;
                        selectedItem.externalDescription = _selectedStandardItem.externalDescription;
                        selectedItem.internalDescription = _selectedStandardItem.internalDescription;
                        selectedItem.cost = _selectedStandardItem.cost;

                        OnPropertyChanged("selectedItem");
                    }
                }
            }
        }

        //Materials
        private ObservableCollection<QuoteMaterial> _quoteMaterialList;
        public ObservableCollection<QuoteMaterial> quoteMaterialList
        {
            get { return _quoteMaterialList ?? (_quoteMaterialList = new ObservableCollection<QuoteMaterial>()); }
        }

        private QuoteMaterial _selectedMaterial;
        public QuoteMaterial selectedMaterial
        {
            get { return _selectedMaterial; }
            set { if (value != null) { _selectedMaterial = value; OnPropertyChanged("selectedMaterial"); } }
        }

        //Subcontractors
        private ObservableCollection<QuoteSubcontractor> _quoteSubcontractorList;
        public ObservableCollection<QuoteSubcontractor> quoteSubcontractorList
        {
            get { return _quoteSubcontractorList ?? (_quoteSubcontractorList = new ObservableCollection<QuoteSubcontractor>()); }
        }

        private QuoteSubcontractor _selectedSubcontractor;
        public QuoteSubcontractor selectedSubcontractor
        {
            get { return _selectedSubcontractor; }
            set { if (value != null) { _selectedSubcontractor = value; OnPropertyChanged("selectedSubcontractor"); } }
        }

        //Suppliers
        private ObservableCollection<Supplier> _supplierList;
        public ObservableCollection<Supplier> supplierList
        {
            get { return _supplierList ?? (_supplierList = new ObservableCollection<Supplier>()); }
        }

        private Supplier _selectedMaterialSupplier;
        public Supplier selectedMaterialSupplier
        {
            get { return _selectedMaterialSupplier; }
            set
            {
                if (value != null)
                {
                    _selectedMaterialSupplier = value;
                    OnPropertyChanged("selectedMaterialSupplier");
                }

                if (selectedMaterial.supplier != _selectedMaterialSupplier.name)
                {
                    selectedMaterial.supplier = _selectedMaterialSupplier.name;
                    selectedMaterial.supplierID = _selectedMaterialSupplier.ID;
                }
            }
        }

        private Supplier _selectedSubcontractorSupplier;
        public Supplier selectedSubcontractorSupplier
        {
            get { return _selectedSubcontractorSupplier; }
            set
            {
                if (value != null)
                {
                    _selectedSubcontractorSupplier = value;
                    OnPropertyChanged("selectedSubcontractorSupplier");
                }

                if (selectedSubcontractor.supplier != _selectedSubcontractorSupplier.name)
                {
                    selectedSubcontractor.supplier = _selectedSubcontractorSupplier.name;
                    selectedSubcontractor.supplierID = _selectedSubcontractorSupplier.ID;
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

                if (selectedItem.nominalCode != _selectedItemDepartment.nominalCode)
                {
                    selectedItem.nominalCode = _selectedItemDepartment.nominalCode;
                    selectedItem.department = _selectedItemDepartment.department;

                    OnPropertyChanged("selectedItem");
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

                if (selectedTime.nominalCode != _selectedTimeDepartment.nominalCode)
                {
                    selectedTime.nominalCode = _selectedTimeDepartment.nominalCode;
                    selectedTime.department = _selectedTimeDepartment.department;
                    selectedTime.cost = _selectedTimeDepartment.initalCost;
                    selectedTime.rate = _selectedTimeDepartment.rateCost;

                    OnPropertyChanged("selectedTime");
                }
            }
        }
        #endregion

        #region Events
        //Item

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            quoteItemList.Remove(quoteItemList.SingleOrDefault(x => x.ID == selectedItem.ID));

            if (selectedItem.ID == 0)
            {
                selectedItem.quoteID = selectedQuote.quoteID;
                selectedItem.line = quoteItemList.Max(x => x.line) + 1;
            }

            quoteItemList.Add(selectedItem);
            quoteItemList.OrderBy(x => x.line);
        }

        private void UploadItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteDialog.IsOpen = true;
        }
        
        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            //todoList.Remove(quoteSubcontractorList.SingleOrDefault(x => x.ID == selectedSubcontractor.ID));

            //if (selectedSubcontractor.ID == 0)
            //{
            //    //selectedTime.quoteID
            //}

            //quoteSubcontractorList.Add(selectedSubcontractor);
        }

        #endregion

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteDialog_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
        }

        private DispatcherTimer loginTimer = new DispatcherTimer();

        private void loginTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                loginTimer.Stop();
                loginTimer.IsEnabled = false;
                progressBar.Visibility = Visibility.Collapsed;
            }));
            var messageQueue = SnackBar.MessageQueue;
            Task.Factory.StartNew(() => messageQueue.Enqueue("Saved"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginTimer = new DispatcherTimer();
            loginTimer.Tick += loginTimer_Tick;
            loginTimer.Interval = new TimeSpan(0, 0, 5);
            loginTimer.Start();
            progressBar.Visibility = Visibility.Visible;
        }

        private void CompleteToDo_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Complete!");
            //var checkbox = sender as CheckBox;
            //int value = (int)checkbox.Tag;
            //if(value != 0)
            //{
            //    todoList.Remove(todoList.SingleOrDefault(x => x.ID == value));
            //}
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Selection Changed");
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
            if (loginTimer.IsEnabled == true)
            {
                loginTimer.Stop();
            }
            loginTimer = new DispatcherTimer();
            loginTimer.Tick += loginTimer_Tick;
            loginTimer.Interval = new TimeSpan(0, 0, 5);
            loginTimer.Start();

            progressBar.Visibility = Visibility.Visible;
        }

        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }
    }
}
