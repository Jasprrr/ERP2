using ERP.Models;
using ERP.Views;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static RoutedCommand SearchBoxFocus = new RoutedCommand();
        private void SearchBoxFocusExecuted(object sender, ExecutedRoutedEventArgs e) { SearchBox.Focus(); }

        public MainWindow()
        {
            //Debug.WriteLine(AppDomain.CurrentDomain.BaseDirectory.ToString());
            InitializeComponent();
            //Debug.Print(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            //SQLiteConnection.CreateFile("ERPData.sqlite");
            //SQLiteConnection.CreateFile(@"C:\users\Jasper\Desktop\test.sqlite");
            //SetUpDb();
            //_navigationMenu = new ObservableCollection<NavigationItem>();

            SearchBoxFocus.InputGestures.Add(new KeyGesture(Key.F, ModifierKeys.Control));

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.primaryColour))
            {
                new PaletteHelper().ReplacePrimaryColor(Properties.Settings.Default.primaryColour);

            }
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.accentColour))
            {
                new PaletteHelper().ReplaceAccentColor(Properties.Settings.Default.accentColour);
            }

            new PaletteHelper().SetLightDark(Properties.Settings.Default.darkTheme);

            navigationMenu.Add(new NavigationItem { title = "Home", icon = "Home" });
            navigationMenu.Add(new NavigationItem { title = "Calendar", icon = "Calendar" });
            navigationMenu.Add(new NavigationItem { title = "Tasks", icon = "Flag" });
            navigationMenu.Add(new NavigationItem { title = "Customers", icon = "Domain" });
            navigationMenu.Add(new NavigationItem { title = "Contacts", icon = "AccountMultiple" });
            navigationMenu.Add(new NavigationItem { title = "Suppliers", icon = "Palette" });
            navigationMenu.Add(new NavigationItem { title = "Supplier contacts", icon = "AccountMultipleOutline" });
            navigationMenu.Add(new NavigationItem { title = "Supplier items", icon = "Package" });
            navigationMenu.Add(new NavigationItem { title = "Standard items", icon = "Wrench" });
            navigationMenu.Add(new NavigationItem { title = "Quotes", icon = "FormatQuoteClose" });
            navigationMenu.Add(new NavigationItem { title = "Orders", icon = "Send" });
            navigationMenu.Add(new NavigationItem { title = "Deliveries", icon = "Truck" });
            navigationMenu.Add(new NavigationItem { title = "Invoices", icon = "BookVariant" });
            navigationMenu.Add(new NavigationItem { title = "Credits", icon = "CreditCard" });
            navigationMenu.Add(new NavigationItem { title = "Purchases", icon = "Basket" });
            navigationMenu.Add(new NavigationItem { title = "Stock", icon = "Widgets" });
            navigationMenu.Add(new NavigationItem { title = "NCRs", icon = "Alert" });
            navigationMenu.Add(new NavigationItem { title = "Reports", icon = "Finance" });
            navigationMenu.Add(new NavigationItem { title = "Settings", icon = "Settings" });

            _todoList = new ObservableCollection<Todo>();
            _todoList.Add(new Todo() { todoID = 1, startDate = new DateTime(2008, 1, 1), account = "Acc 01", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 2, startDate = new DateTime(2008, 2, 1), account = "Acc 02", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 3, startDate = new DateTime(2008, 3, 1), account = "Acc 03", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 4, startDate = new DateTime(2008, 4, 1), account = "Acc 04", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 5, startDate = new DateTime(2008, 5, 1), account = "Acc 05", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 6, startDate = new DateTime(2008, 6, 1), account = "Acc 06", subject = "Lorem ipsum.", completed = false });
            _todoList.Add(new Todo() { todoID = 7, startDate = new DateTime(2008, 7, 1), account = "Acc 07", subject = "Lorem ipsum.", completed = false });
        }

        #region Variables
        private ObservableCollection<NavigationItem> _navigationMenu;
        public ObservableCollection<NavigationItem> navigationMenu
        {
            get { return _navigationMenu ?? (_navigationMenu = new ObservableCollection<NavigationItem>()); }
        }

        private NavigationItem _selectedNavigationItem;
        public NavigationItem selectedNavigationItem
        {
            get { return _selectedNavigationItem; }
            set { if (_selectedNavigationItem != value) { _selectedNavigationItem = value; OnPropertyChanged("selectedNavigationItem"); Debug.WriteLine("Reached"); } }
        }

        private ObservableCollection<Todo> _todoList;
        public ObservableCollection<Todo> todoList
        {
            get { return _todoList; }
            set { _todoList = value;  OnPropertyChanged("todoList"); }
        }

        private bool _menuExpanded;
        public bool menuExpanded
        {
            get { return _menuExpanded; }
            set { _menuExpanded = value; OnPropertyChanged("menuExpanded"); }
        }

        private string _searchTerm;
        public string searchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; OnPropertyChanged("searchTerm"); }
        }
        #endregion

        #region Events
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationMenu.Width = menuExpanded == true ? 200 : 64;
        }

        private void NavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigate(selectedNavigationItem.title);
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewQuote_Click(object sender, RoutedEventArgs e)
        {
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            var QuoteWindow = new QuoteView();
            QuoteWindow.Show();
        }

        private void NewCall_Click(object sender, RoutedEventArgs e)
        {
            var QuoteWindow = new QuoteView();
            QuoteWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
        
        private void Navigate(string page, string searchFor = null)
        {
            switch (page)
            {
                case "Home":
                    MainFrame.Navigate(new HomeView());
                    break;
                case "Calendar":
                    MainFrame.Navigate(new CalendarView());
                    break;
                case "Tasks":
                    MainFrame.Navigate(new TodosView());
                    break;
                case "Customers":
                    MainFrame.Navigate(new AccountsView(searchFor));
                    break;
                case "Contacts":
                    MainFrame.Navigate(new ContactsView());
                    break;
                case "Suppliers":
                    MainFrame.Navigate(new SuppliersView());
                    break;
                case "Supplier contacts":
                    MainFrame.Navigate(new SupplierContactsView());
                    break;
                case "Supplier items":
                    MainFrame.Navigate(new SupplierItemsView());
                    break;
                case "Standard items":
                    MainFrame.Navigate(new StandardItemsView());
                    break;
                case "Quotes":
                    MainFrame.Navigate(new TestView());
                    break;
                case "Orders":
                    break;
                case "Deliveries":
                    break;
                case "Invoices":
                    break;
                case "Credits":
                    break;
                case "Purchases":
                    break;
                case "Stock":
                    break;
                case "NCRs":
                    break;
                case "Reports":
                    break;
                case "Settings":
                    MainFrame.Navigate(new SettingsView());
                    break;
                default:
                    break;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Navigate(selectedNavigationItem.title, searchTerm);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Drawer.IsRightDrawerOpen = !Drawer.IsRightDrawerOpen;
        }
    }
}