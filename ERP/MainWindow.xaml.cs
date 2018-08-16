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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainWindow()
        {
            menuExpanded = new bool();
            //Debug.Print(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            //SQLiteConnection.CreateFile("ERPData.sqlite");
            //SQLiteConnection.CreateFile(@"C:\users\Jasper\Desktop\test.sqlite");
            //SetUpDb();
            //_navMenu = new ObservableCollection<NavigationItem>();
            InitializeComponent();
            navMenu.Add(new NavigationItem { title = "Home", icon = "Home", page = "Views/HomeView.xaml" });
            navMenu.Add(new NavigationItem { title = "Calendar", icon = "Calendar", page = "Views/CalendarView.xaml" });
            navMenu.Add(new NavigationItem { title = "Tasks", icon = "Flag", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Customers", icon = "Domain", page = "Views/AccountsView.xaml" });
            navMenu.Add(new NavigationItem { title = "Suppliers", icon = "Palette", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Standard items", icon = "Wrench", page = "Views/CalendarView.xaml" });
            navMenu.Add(new NavigationItem { title = "Quotes", icon = "FormatQuoteClose", page = "Views/TestView.xaml" });
            navMenu.Add(new NavigationItem { title = "Orders", icon = "Send", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Deliveries", icon = "Truck", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Invoices", icon = "BookVariant", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Credits", icon = "CreditCard", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Purchases", icon = "Basket", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Stock", icon = "Widgets", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "NCRs", icon = "Alert", page = "Views/TasksView.xaml" });
            navMenu.Add(new NavigationItem { title = "Reports", icon = "Finance", page = "Views/TasksView.xaml" });
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
            MainFrame.Navigate(new Uri(selectedItem.page.ToString(), UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var QuoteWindow = new QuoteView();
            QuoteWindow.Show();
        }

        private bool _menuExpanded;
        public bool menuExpanded
        {
            get { return _menuExpanded; }
            set { _menuExpanded = value; OnPropertyChanged("menuExpanded"); }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationMenu.Width = menuExpanded == true ? 200 : 64;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Views/SettingsView.xaml", UriKind.Relative));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}