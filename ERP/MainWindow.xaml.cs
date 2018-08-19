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

        public MainWindow()
        {
            InitializeComponent();
            //Debug.Print(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            //SQLiteConnection.CreateFile("ERPData.sqlite");
            //SQLiteConnection.CreateFile(@"C:\users\Jasper\Desktop\test.sqlite");
            //SetUpDb();
            //_navigationMenu = new ObservableCollection<NavigationItem>();

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.primaryColour))
            {
                new PaletteHelper().ReplacePrimaryColor(Properties.Settings.Default.primaryColour);

            }
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.accentColour))
            {
                new PaletteHelper().ReplaceAccentColor(Properties.Settings.Default.accentColour);
            }

            new PaletteHelper().SetLightDark(Properties.Settings.Default.darkTheme);

            navigationMenu.Add(new NavigationItem { title = "Home", icon = "Home", page = "Views/HomeView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Calendar", icon = "Calendar", page = "Views/CalendarView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Tasks", icon = "Flag", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Customers", icon = "Domain", page = "Views/AccountsView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Contacts", icon = "AccountMultiple", page = "Views/AccountsView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Suppliers", icon = "Palette", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Standard items", icon = "Wrench", page = "Views/CalendarView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Quotes", icon = "FormatQuoteClose", page = "Views/TestView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Orders", icon = "Send", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Deliveries", icon = "Truck", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Invoices", icon = "BookVariant", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Credits", icon = "CreditCard", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Purchases", icon = "Basket", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Stock", icon = "Widgets", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "NCRs", icon = "Alert", page = "Views/TasksView.xaml" });
            navigationMenu.Add(new NavigationItem { title = "Reports", icon = "Finance", page = "Views/TasksView.xaml" });
        }

        #region Variables

        public NavigationService mainFrameNS;

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

        private bool _menuExpanded;
        public bool menuExpanded
        {
            get { return _menuExpanded; }
            set { _menuExpanded = value; OnPropertyChanged("menuExpanded"); }
        }

        private string _search;
        public string search
        {
            get { return _search; }
            set { _search = value; OnPropertyChanged("search"); }
        }
        #endregion

        #region Events
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationMenu.Width = menuExpanded == true ? 200 : 64;
        }

        private void NavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigate();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri("Views/SettingsView.xaml", UriKind.Relative));

        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            Navigate();
        }

        private void NewQuote_Click(object sender, RoutedEventArgs e)
        {
            var QuoteWindow = new QuoteView();
            QuoteWindow.Show();
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

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Navigate()
        {
            switch (selectedNavigationItem.title)
            {
                case "Home":

                    break;
                case "Calendar":
                    break;
                case "Tasks":
                    break;
                case "Customers":
                    MainFrame.Navigate(new AccountsView(search));
                    break;
                case "Contacts":
                    break;
                case "Suppliers":
                    break;
                case "Standard":
                    break;
                case "Quotes":
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
                default:
                    break;
            }
        }
    }
}