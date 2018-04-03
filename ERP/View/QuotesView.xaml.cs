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
using System;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for QuotesView.xaml
    /// </summary>
    public partial class QuotesView : Window
    {
        public QuotesView()
        {
            _quoteItemList = new ObservableCollection<QuoteItem>();
            _quoteList = new ObservableCollection<Quote>();
            InitializeComponent();
            _quoteItemList.Add(new QuoteItem() { itemCode = "123-ABC", itemCost = 250, quantity = 4, line = 1, batchNumber="789-XYZ" });
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

        private ObservableCollection<Quote> _quoteList;
        public ObservableCollection<Quote> quoteList
        {
            get { return _quoteList ?? (_quoteList = new ObservableCollection<Quote>()); }
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.Print(selectedItem.accountName.ToString());
            Dispatcher.BeginInvoke(new Action(() =>
            {
                var editwindow = new AccountView();
                editwindow.Show();
            }));
        }
    }
}
