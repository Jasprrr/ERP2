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
            _departments.Add(new Department() { departmentID = 3, department = "Powder Coating", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 4, department = "Fine Paint", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 5, department = "CNC Machine Room", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 6, department = "Anodising", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 7, department = "Alocrom", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 8, department = "Iridite", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
            _departments.Add(new Department() { departmentID = 9, department = "Laser Engraving", nominalCode = 4060, defaultRate = (decimal)35.00, initalCost = 0 });
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

            InitializeComponent();
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
    }
}
