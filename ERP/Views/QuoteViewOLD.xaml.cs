using ERP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class QuoteView : Window
    {
        public QuoteView()
        {
            _departments = new ObservableCollection<Department>();
            _departments.Add(new Department() { departmentID = 1, department = "Masking", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 2, department = "Wet Paint", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 3, department = "Powder coating", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 4, department = "Fine paint", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 5, department = "CNC machine room", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 6, department = "Anodising", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 7, department = "Alocrom", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 8, department = "Iridite", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 9, department = "Laser engraving", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 10, department = "Engraving", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 11, department = "Printing", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });

            _quoteItemList = new ObservableCollection<QuoteItem>();
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 1, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 2, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 3, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 4, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 5, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 6, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 7, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 8, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 9, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 10, batchNumber = "789-XYZ" });
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 11, batchNumber = "789-XYZ" });

            _standardItems = new ObservableCollection<QuoteItem>();
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 1, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 2, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 3, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 4, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 5, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 6, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 7, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 8, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 9, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 10, batchNumber = "789-XYZ" });
            _standardItems.Add(new QuoteItem() { itemCode = "321-XYZ", itemCost = 250, quantity = 4, line = 11, batchNumber = "789-XYZ" });

            _quoteMaterialList = new ObservableCollection<QuoteMaterial>();
            _quoteMaterialList.Add(new QuoteMaterial() { supplier = "Tim Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { supplier = "Bob Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { supplier = "Tom Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { supplier = "Rob Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { supplier = "Sam Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteMaterialList.Add(new QuoteMaterial() { supplier = "Jim Co.", materialCost = 100, rate = 35, notes = "Lorem ipsum." });

            _quoteSubcontractorList = new ObservableCollection<QuoteSubcontractor>();
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Tim Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Bob Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Tom Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Rob Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Sam Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });
            _quoteSubcontractorList.Add(new QuoteSubcontractor() { supplier = "Jim Co.", subcontractorCost = 100, rate = 35, notes = "Lorem ipsum." });

            InitializeComponent();
        }

        private ObservableCollection<QuoteSubcontractor> _quoteSubcontractorList;
        public ObservableCollection<QuoteSubcontractor> quoteSubcontractorList
        {
            get { return _quoteSubcontractorList ?? (_quoteSubcontractorList = new ObservableCollection<QuoteSubcontractor>()); }
        }

        private ObservableCollection<QuoteMaterial> _quoteMaterialList;
        public ObservableCollection<QuoteMaterial> quoteMaterialList
        {
            get { return _quoteMaterialList ?? (_quoteMaterialList = new ObservableCollection<QuoteMaterial>()); }
        }
        
        private ObservableCollection<QuoteTime> _quoteTimeList;
        public ObservableCollection<QuoteTime> quoteTimeList
        {
            get { return _quoteTimeList ?? (_quoteTimeList = new ObservableCollection<QuoteTime>()); }
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

        private ObservableCollection<QuoteItem> _quoteItemList;
        public ObservableCollection<QuoteItem> quoteItemList
        {
            get { return _quoteItemList ?? (_quoteItemList = new ObservableCollection<QuoteItem>()); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string theValue = button.Tag.ToString();
            Debug.Print(theValue);
            var newWindow = new AccountView();
            newWindow.Show();
        }

        private void EditQuoteItem_Click(object sender, RoutedEventArgs e)
        {
            MainDrawer.IsRightDrawerOpen = true;
            if (DrawerFrame.CanGoBack)
            {
                DrawerFrame.RemoveBackEntry();
            }
            DrawerFrame.Navigate(new QuoteItemView());
        }

        private void editQuoteTime_Click(object sender, RoutedEventArgs e)
        {
            MainDrawer.IsRightDrawerOpen = true;
            if (DrawerFrame.CanGoBack)
            {
                DrawerFrame.RemoveBackEntry();
            }
            DrawerFrame.Navigate(new QuoteTimeView());
        }

        private void editQuoteMaterial_Click(object sender, RoutedEventArgs e)
        {
            MainDrawer.IsRightDrawerOpen = true;
            if (DrawerFrame.CanGoBack)
            {
                DrawerFrame.RemoveBackEntry();
            }
            DrawerFrame.Navigate(new QuoteMaterialView());
        }

        private void editQuoteSubcontractor_Click(object sender, RoutedEventArgs e)
        {
            MainDrawer.IsRightDrawerOpen = true;
            if (DrawerFrame.CanGoBack)
            {
                DrawerFrame.RemoveBackEntry();
            }
            DrawerFrame.Navigate(new QuoteSubcontractorView());
        }
    }
}
