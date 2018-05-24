using ERP.Model;
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

namespace ERP.View
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
            _quoteItemList.Add(new QuoteItem() { ID = 1, itemCode = "123-ABC", cost = 250, quantity = 4, line = 1, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 2, itemCode = "123-ABC", cost = 250, quantity = 4, line = 2, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 3, itemCode = "123-ABC", cost = 250, quantity = 4, line = 3, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 4, itemCode = "123-ABC", cost = 250, quantity = 4, line = 4, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 5, itemCode = "123-ABC", cost = 250, quantity = 4, line = 5, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 6, itemCode = "123-ABC", cost = 250, quantity = 4, line = 6, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 7, itemCode = "123-ABC", cost = 250, quantity = 4, line = 7, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 8, itemCode = "123-ABC", cost = 250, quantity = 4, line = 8, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 9, itemCode = "123-ABC", cost = 250, quantity = 4, line = 9, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { ID = 10, itemCode = "123-ABC", cost = 250, quantity = 4, line = 10, internalDescription = "789-XYZ" });

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
            _todoList.Add(new ToDo() { ID = 1, dueDate = new DateTime(2008, 1, 1), account = "Acc 01", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Tim" });
            _todoList.Add(new ToDo() { ID = 2, dueDate = new DateTime(2008, 2, 1), account = "Acc 02", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Bob" });
            _todoList.Add(new ToDo() { ID = 3, dueDate = new DateTime(2008, 3, 1), account = "Acc 03", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "RobTim" });
            _todoList.Add(new ToDo() { ID = 4, dueDate = new DateTime(2008, 4, 1), account = "Acc 04", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Jim, Rob, Bob" });
            _todoList.Add(new ToDo() { ID = 5, dueDate = new DateTime(2008, 5, 1), account = "Acc 05", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Sam, Jim, Rob" });
            _todoList.Add(new ToDo() { ID = 6, dueDate = new DateTime(2008, 6, 1), account = "Acc 06", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Tim, Sam, Jim" });
            _todoList.Add(new ToDo() { ID = 7, dueDate = new DateTime(2008, 7, 1), account = "Acc 07", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Bob, Tim, Sam" });

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
        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.Tag != null)
            {
                selectedItem = quoteItemList.Single(x => x.ID == (int)button.Tag);
            }
            else
            {
                selectedItem = new QuoteItem();
            }
            ItemDialog.IsOpen = true;
        }

        private void CloseItem_Click(object sender, RoutedEventArgs e)
        {
            ItemDialog.IsOpen = false;
        }

        private void ItemInternalDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ItemInternalDescription.Text != "" &&
                ItemExternalDescription.Text == "")
            {
                ItemExternalDescription.Text = ItemInternalDescription.Text;
            }
        }

        private void ItemExternalDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ItemExternalDescription.Text != "" &&
                ItemInternalDescription.Text == "")
            {
                ItemInternalDescription.Text = ItemExternalDescription.Text;
            }
        }

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

            ItemDialog.IsOpen = false;
        }

        private void UploadItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            deleteObject = new Delete();
            var button = sender as Button;
            
            deleteObject.id = button.Tag != null ? (int)button.Tag : 0;
            deleteObject.type = "Item";
            deleteObject.dialogOpen = ItemDialog.IsOpen;

            ItemDialog.IsOpen = false;

            DeleteDialog.IsOpen = true;
        }

        //Time
        private void EditTime_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.Tag != null)
            {
                selectedTime = quoteTimeList.Single(x => x.ID == (int)button.Tag);
            }
            else
            {
                selectedTime = new QuoteTime();
            }

            TimeDialog.IsOpen = true;
        }

        private void CloseTime_Click(object sender, RoutedEventArgs e)
        {
            TimeDialog.IsOpen = false;
        }

        private void TimeDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveTime_Click(object sender, RoutedEventArgs e)
        {
            quoteTimeList.Remove(quoteTimeList.SingleOrDefault(x => x.ID == selectedTime.ID));

            if (selectedTime.ID == 0)
            {
                selectedTime.quoteID = selectedQuote.quoteID;
                if (quoteTimeList.Count > 1)
                {
                    selectedTime.line = 1 + quoteTimeList.Max(x => x.line);
                }
                else
                {
                    selectedTime.line = 1;
                }
            }

            quoteTimeList.Add(selectedTime);
            quoteTimeList.OrderBy(x => x.line);

            TimeDialog.IsOpen = false;
        }

        private void DeleteTime_Click(object sender, RoutedEventArgs e)
        {
            deleteObject = new Delete();
            var button = sender as Button;

            if (TimeDialog.IsOpen == true)
            {
                TimeDialog.IsOpen = false;
            }
            deleteObject.id = button.Tag != null ? (int)button.Tag : 0;
            deleteObject.type = "Time";
            DeleteDialog.IsOpen = true;
        }

        //Material
        private void EditMaterial_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.Tag != null)
            {
                selectedMaterial = quoteMaterialList.Single(x => x.ID == (int)button.Tag);
            }
            else
            {
                selectedMaterial = new QuoteMaterial();
            }
            MaterialDialog.IsOpen = true;
        }

        private void CloseMaterial_Click(object sender, RoutedEventArgs e)
        {
            MaterialDialog.IsOpen = false;
        }

        private void SaveMaterial_Click(object sender, RoutedEventArgs e)
        {
            quoteMaterialList.Remove(quoteMaterialList.SingleOrDefault(x => x.ID == selectedMaterial.ID));

            if (selectedMaterial.ID == 0)
            {
                selectedMaterial.quoteID = selectedQuote.quoteID;
            }

            quoteMaterialList.Add(selectedMaterial);
            quoteMaterialList.OrderBy(x => x.supplier);

            MaterialDialog.IsOpen = false;
        }

        private void DeleteMaterial_Click(object sender, RoutedEventArgs e)
        {
            deleteObject = new Delete();
            var button = sender as Button;

            if (MaterialDialog.IsOpen == true)
            {
                MaterialDialog.IsOpen = false;
            }
            deleteObject.id = button.Tag != null ? (int)button.Tag : 0;
            deleteObject.type = "Material";
            DeleteDialog.IsOpen = true;
        }

        //Subcontractor
        private void EditSubcontractor_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.Tag != null)
            {
                selectedSubcontractor = quoteSubcontractorList.Single(x => x.ID == (int)button.Tag);
            }
            else
            {
                selectedSubcontractor = new QuoteSubcontractor();
            }
            SubcontractorDialog.IsOpen = true;
        }

        private void CloseSubcontractor_Click(object sender, RoutedEventArgs e)
        {
            SubcontractorDialog.IsOpen = false;
        }

        private void SaveSubcontractor_Click(object sender, RoutedEventArgs e)
        {
            quoteSubcontractorList.Remove(quoteSubcontractorList.SingleOrDefault(x => x.ID == selectedSubcontractor.ID));

            if (selectedSubcontractor.ID == 0)
            {
                selectedSubcontractor.quoteID = selectedQuote.quoteID;
            }

            quoteSubcontractorList.Add(selectedSubcontractor);
            quoteSubcontractorList.OrderBy(x => x.supplier);

            SubcontractorDialog.IsOpen = false;
        }

        private void DeleteSubcontractor_Click(object sender, RoutedEventArgs e)
        {
            deleteObject = new Delete();
            var button = sender as Button;

            if (SubcontractorDialog.IsOpen == true)
            {
                SubcontractorDialog.IsOpen = false;
            }
            deleteObject.id = button.Tag != null ? (int)button.Tag : 0;
            deleteObject.type = "Subcontractor";
        }

        //Task
        private void EditTaskItem_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var button = sender as Button;

            if (button.Tag != null)
            {
                value = (int)button.Tag;
            }
            else
            {
                value = 0;
            }
            TaskDialog.IsOpen = true;
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
            UserDialog.IsOpen = true;
        }

        private void DeleteDialog_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter.ToString() == "true")
            {

            }
            else
            {
                switch (deleteObject.type)
                {
                    case "Quote":
                        break;
                    case "Item":
                        quoteItemList.Remove(quoteItemList.SingleOrDefault(x => x.ID == selectedItem.ID));
                        ItemDialog.IsOpen = true;
                        break;
                    case "Time":
                        TimeDialog.IsOpen = true;
                        break;
                    case "Material":
                        MaterialDialog.IsOpen = true;
                        break;
                    case "Subcontractor":
                        SubcontractorDialog.IsOpen = true;
                        break;
                    case "Task":
                        TaskDialog.IsOpen = true;
                        break;
                }
            }
        }

        private DispatcherTimer loginTimer;

        private void loginTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                loginTimer.Stop();
                progressBar.Visibility = Visibility.Collapsed;
            }));
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
            if (magicTransitioner.SelectedIndex == 1)
            {
                magicTransitioner.SelectedIndex = 0;
            }
            else
            {
                magicTransitioner.SelectedIndex = 1;
            }
        }
    }
}
