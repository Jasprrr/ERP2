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
            selectedQuote = new Quote() { quoteID = 1, dateCreated = DateTime.Now, quoteCost = 35, userName = "Jasper", accountName = "Jasper Co.", billingAddress1 = "123 Fake Street" };

            _accountList = new ObservableCollection<Account>();
            _accountList.Add(new Account() { accountID = 1, accountName = "123" });
            _accountList.Add(new Account() { accountID = 1, accountName = "123" });

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

            _quoteItemList = new ObservableCollection<QuoteItem>();
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 1, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 1, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 2, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 2, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 3, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 3, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 4, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 4, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 5, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 5, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 6, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 6, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 7, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 7, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 8, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 8, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 9, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 9, internalDescription = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { quoteItemID = 10, itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 10, internalDescription = "789-XYZ" });

            _standardItems = new ObservableCollection<QuoteItem>();
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 1, internalDescription = "Test internal description", externalDescription = "Test external description" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 2, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 3, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 4, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 5, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 6, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 7, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 8, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 9, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 10, internalDescription = "Test internal description", externalDescription = "Test external description;" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 50, quantity = 4, line = 11, internalDescription = "Test internal description", externalDescription = "Test external description;" });

            _quoteMaterialList = new ObservableCollection<QuoteMaterial>();
            _quoteMaterialList.Add(new QuoteMaterial() { quoteMaterialID = 1, supplier = "Tim Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { quoteMaterialID = 2, supplier = "Bob Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { quoteMaterialID = 3, supplier = "Tom Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { quoteMaterialID = 4, supplier = "Rob Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { quoteMaterialID = 5, supplier = "Sam Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { quoteMaterialID = 6, supplier = "Jim Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });

            _quoteSubcontractorList = new ObservableCollection<QuoteSubcontractor>();
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Tim Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Bob Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Tom Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Rob Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Sam Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Jim Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });

            _todoList = new ObservableCollection<ToDo>();
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 1, 1), account = "Acc 01", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Tim" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 2, 1), account = "Acc 02", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Bob" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 3, 1), account = "Acc 03", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Rob, Bob, Tim" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 4, 1), account = "Acc 04", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Jim, Rob, Bob" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 5, 1), account = "Acc 05", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Sam, Jim, Rob" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 6, 1), account = "Acc 06", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Tim, Sam, Jim" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 7, 1), account = "Acc 07", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Bob, Tim, Sam" });

            InitializeComponent();
        }

        #region Variables
        private Delete _deleteObject;
        public Delete deleteObject
        {
            get { return _deleteObject; }
            set { if(value != null) { _deleteObject = value;  OnPropertyChanged("deleteObject"); } }
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
            get { return _userList ?? (_userList = new ObservableCollection<User>()); }
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
            set { if (value != null) { _selectedAccount = value; OnPropertyChanged("selectedAccount"); } }
        }

        private Contact _selectedContact;
        public Contact selectedContact
        {
            get { return _selectedContact; }
            set { if (value != null) { _selectedContact = value; OnPropertyChanged("selectedContact"); } }
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
                        selectedItem.itemCost = _selectedStandardItem.itemCost;

                        OnPropertyChanged("selectedItem");
                    }
                }
            }
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

        private ObservableCollection<QuoteMaterial> _quoteMaterialList;
        public ObservableCollection<QuoteMaterial> quoteMaterialList
        {
            get { return _quoteMaterialList ?? (_quoteMaterialList = new ObservableCollection<QuoteMaterial>()); }
        }

        private QuoteMaterial _selectedMaterial;
        public QuoteMaterial selectedMaterial
        {
            get { return _selectedMaterial; }
            set { if (value != null) { _selectedMaterial = value; } }
        }

        private ObservableCollection<QuoteSubcontractor> _quoteSubcontractorList;
        public ObservableCollection<QuoteSubcontractor> quoteSubcontractorList
        {
            get { return _quoteSubcontractorList ?? (_quoteSubcontractorList = new ObservableCollection<QuoteSubcontractor>()); }
        }

        private QuoteSubcontractor _selectedSubcontractor;
        public QuoteSubcontractor selectedSubcontractor
        {
            get { return _selectedSubcontractor; }
            set { if (value != null) { _selectedSubcontractor = value; } }
        }

        private Department _selectedDepartment;
        public Department selectedDepartment
        {
            get { return _selectedDepartment; }
            set { if (value != null) { _selectedDepartment = value; } }
        }

        private static ObservableCollection<Department> _departments;
        public static ObservableCollection<Department> departments
        {
            get { return _departments ?? (_departments = new ObservableCollection<Department>()); }
        }

        private static ObservableCollection<QuoteItem> _standardItems;
        public static ObservableCollection<QuoteItem> standardItems
        {
            get { return _standardItems ?? (_standardItems = new ObservableCollection<QuoteItem>()); }
        }
        #endregion

        #region Events
        //Item
        private void EditQuoteItem_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.Tag != null)
            {
                selectedItem = quoteItemList.Single(x => x.quoteItemID == (int)button.Tag);
            }
            else
            {
                selectedItem = new QuoteItem();
            }
            ItemDialog.IsOpen = true;
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
            quoteItemList.Remove(quoteItemList.SingleOrDefault(x => x.quoteItemID == selectedItem.quoteItemID));

            if (selectedItem.quoteItemID == 0)
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
            deleteObject = new Delete();
            var button = sender as Button;
                        
            if (ItemDialog.IsOpen == true)
            {
                ItemDialog.IsOpen = false;
            }

            deleteObject.id = button.Tag != null ? (int)button.Tag : 0;
            deleteObject.type = "Item";

            DeleteDialog.IsOpen = true;
        }

        //Time
        private void EditQuoteTime_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.Tag != null)
            {
                selectedTime = quoteTimeList.Single(x => x.quoteTimeID == (int)button.Tag);
            }
            else
            {
                selectedTime = new QuoteTime();
            }

            TimeDialog.IsOpen = true;
        }

        private void TimeDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTime.nominalCode = selectedDepartment.nominalCode;
            selectedTime.initialCost = selectedDepartment.initalCost;
            selectedTime.rateCost = selectedDepartment.rateCost;
            OnPropertyChanged("selectedTime");
        }

        private void SaveTime_Click(object sender, RoutedEventArgs e)
        {
            quoteTimeList.Remove(quoteTimeList.SingleOrDefault(x => x.quoteTimeID == selectedTime.quoteTimeID));

            if (selectedTime.quoteTimeID == 0)
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
        private void EditQuoteMaterial_Click(object sender, RoutedEventArgs e)
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
            MaterialDialog.IsOpen = true;
        }

        private void SaveMaterial_Click(object sender, RoutedEventArgs e)
        {
            quoteMaterialList.Remove(quoteMaterialList.SingleOrDefault(x => x.quoteMaterialID == selectedMaterial.quoteMaterialID));

            if (selectedMaterial.quoteMaterialID == 0)
            {
                //selectedTime.quoteID
            }

            quoteMaterialList.Add(selectedMaterial);
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
        private void EditQuoteSubcontractor_Click(object sender, RoutedEventArgs e)
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
            SubcontractorDialog.IsOpen = true;
        }

        private void SaveSubcontractor_Click(object sender, RoutedEventArgs e)
        {
            quoteSubcontractorList.Remove(quoteSubcontractorList.SingleOrDefault(x => x.quoteSubcontractorID == selectedSubcontractor.quoteSubcontractorID));

            if (selectedSubcontractor.quoteSubcontractorID == 0)
            {
                //selectedTime.quoteID
            }

            quoteSubcontractorList.Add(selectedSubcontractor);
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
            DeleteDialog.IsOpen = true;
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
            //todoList.Remove(quoteSubcontractorList.SingleOrDefault(x => x.quoteSubcontractorID == selectedSubcontractor.quoteSubcontractorID));

            //if (selectedSubcontractor.quoteSubcontractorID == 0)
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
                switch (deleteObject.type)
                {
                    case "Quote":
                        break;
                    case "Item":
                        quoteItemList.Remove(quoteItemList.SingleOrDefault(x => x.quoteItemID == deleteObject.id));
                        break;
                    case "Time":
                        quoteTimeList.Remove(quoteTimeList.SingleOrDefault(x => x.quoteTimeID == deleteObject.id));
                        break;
                    case "Material":
                        quoteMaterialList.Remove(quoteMaterialList.SingleOrDefault(x => x.quoteMaterialID == deleteObject.id));
                        break;
                    case "Subcontractor":
                        quoteSubcontractorList.Remove(quoteSubcontractorList.SingleOrDefault(x => x.quoteSubcontractorID == deleteObject.id));
                        break;
                    case "Task":
                        break;
                }
            }
            else
            {
                switch (deleteObject.type)
                {
                    case "Quote":
                        break;
                    case "Item":
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
    }
}
