using ERP.Models;
using ERP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
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

namespace ERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Debug.Print(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            //SQLiteConnection.CreateFile("ERPData.sqlite");
            //SQLiteConnection.CreateFile(@"C:\users\Jasper\Desktop\test.sqlite");
            //SetUpDb();
            //_navMenu = new ObservableCollection<NavigationItem>();
            InitializeComponent();
            _navMenu.Add(new NavigationItem { NavTitle = "Home", NavIcon = "Home", NavPage = "Views/HomeView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Tasks", NavIcon = "CalendarCheck", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Customers", NavIcon = "Domain", NavPage = "Views/AccountsView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Suppliers", NavIcon = "Palette", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Standard Items", NavIcon = "Wrench", NavPage = "Views/CalendarView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Quotes", NavIcon = "FormatQuoteClose", NavPage = "Views/TestView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Orders", NavIcon = "Send", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Deliveries", NavIcon = "Truck", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Invoices", NavIcon = "BookVariant", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Credits", NavIcon = "CreditCard", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Purchases", NavIcon = "Basket", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Stock", NavIcon = "Widgets", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "NCRs", NavIcon = "Alert", NavPage = "Views/TasksView.xaml" });
            _navMenu.Add(new NavigationItem { NavTitle = "Reports", NavIcon = "Finance", NavPage = "Views/TasksView.xaml" });
        }

        private ObservableCollection<NavigationItem> _navMenu;
        public ObservableCollection<NavigationItem> navMenu
        {
            get { return _navMenu ?? (_navMenu = new ObservableCollection<NavigationItem>()); }
        }
        
        private NavigationItem _selectedItem;
        public NavigationItem selectedItem
        {
            get { return _selectedItem; }
            set { if (_selectedItem != value) { _selectedItem = value; } }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainFrame.Navigate(new Uri(selectedItem.NavPage.ToString(), UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var QuoteWindow = new QuoteView();
            QuoteWindow.Show();
        }
    }
}
