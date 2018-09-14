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
using System.Windows.Forms;
using ERP.Controllers;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class AccountView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AccountView(int accountID = 0)
        {
            //Debug.Print(accountID.ToString());
            _todoList = new ObservableCollection<Todo>();
            _contactList = new ObservableCollection<Contact>();
            _activityList = new ObservableCollection<Activity>();
            selectedAccount = new Account();
            InitializeComponent();

            selectedAccount = AccountsController.GetAccount(accountID);

            _contactList.Add(new Contact() { firstName = "Jasper", lastName = "Friend", email1 = "jasper@schoolsmailing.co.uk", phone1 = "0117 9584 972", favourite = true });
            _contactList.Add(new Contact() { firstName = "Josh", lastName = "Kaner", email1 = "josh@schoolsmailing.co.uk", phone1 = "0117 9584 972", accounts = true });
            _contactList.Add(new Contact() { firstName = "Sarah", lastName = "Rodgerson" });
            _contactList.Add(new Contact() { firstName = "Luke", lastName = "Harvey", email1 = "luke@schoolsmailing.co.uk" });

            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#f44336", icon = "Phone", header = "Steve Stevenson", subheader = "Left message", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#ff9800", icon = "Send", header = "180231", subheader = "In progress", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#f44336", icon = "FormatQuoteClose", header = "9001", subheader = "Awaiting despatch", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#4caf50", icon = "CalendarCheck", header = "Speak to Steve about quote 9001", subheader = DateTime.Today.ToString() });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#f44336", icon = "Phone", header = "Jasper Friend", subheader = "Left message", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#ff9800", icon = "Send", header = "180231", subheader = "In progress", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#f44336", icon = "FormatQuoteClose", header = "9001", subheader = "Awaiting despatch", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#4caf50", icon = "CalendarCheck", header = "Book in order 180231", subheader = DateTime.Today.ToString() });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#f44336", icon = "Phone", header = "Jasper Friend", subheader = "Left message", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#ff9800", icon = "Send", header = "180231", subheader = "In progress", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#f44336", icon = "FormatQuoteClose", header = "9001", subheader = "Awaiting despatch", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { user = "Jasper Friend", activityDate = DateTime.Today, colour = "#4caf50", icon = "CalendarCheck", header = "Lorem ipsum", subheader = DateTime.Today.ToString() });

            //_activityList.Add(new Activity() { activityDate = new DateTime(2018, 2, 2, 9, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2058, 2, 2, 10, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2038, 7, 7, 11, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Quisque tempus ac lacus non pulvinar. Ut malesuada ipsum at condimentum ullamcorper. Nunc tristique vel turpis sit amet convallis. Aenean dapibus mi eu elit bibendum lobortis. Praesent at eros sagittis, hendrerit nisi non, vehicula felis. Fusce placerat nisi vel sapien scelerisque, et congue leo aliquam. Curabitur placerat velit quis eros porttitor ultricies. Integer sit amet egestas felis, quis ultrices elit. Vivamus tristique, felis gravida convallis gravida, nisi metus tincidunt lacus, quis ullamcorper arcu augue ut enim. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 6, 6, 12, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Pellentesque congue maximus odio, ut maximus dui rhoncus sit amet. Praesent tellus tellus, gravida sit amet enim tempor, molestie vehicula velit. Suspendisse nec neque vitae mi ultricies ullamcorper. Quisque pharetra eros ut metus fermentum mattis. Donec dignissim dolor lacus. Integer vel libero a nulla gravida ultrices vel eu nisl. Donec scelerisque diam ligula, scelerisque vestibulum lacus suscipit a. Pellentesque aliquet euismod dui in luctus. Morbi nec laoreet sapien. Sed odio elit, porta non porttitor vel, sollicitudin a magna. Sed mollis, ipsum ut imperdiet feugiat, nibh ipsum sodales quam, et consectetur ante sapien at ex. Cras accumsan mauris ut augue condimentum ultricies. Nam felis tortor, imperdiet at nisl nec, maximus porta nisi. Suspendisse et condimentum ipsum. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 3, 3, 13, 30, 0), activityID = 2, user = "Jasper Friend", contact = "Jasper Friend", colour = "#4caf50", activity = "order", icon = "Send", description = "Integer turpis velit, pharetra eget dictum at, aliquam quis felis. Morbi non metus nisl. Praesent tempor ante nec sem mollis, in volutpat mauris tincidunt. Vivamus rhoncus, metus a suscipit convallis, diam diam aliquam velit, at fermentum quam ex vitae ex. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 4, 4, 14, 30, 0), activityID = 4, user = "Jasper Friend", contact = "Jasper Friend", colour = "#2196f3", activity = "quote", icon = "FormatQuoteClose", description = "lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 5, 5, 15, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Fusce scelerisque dapibus ipsum, vitae auctor lectus sollicitudin at. In sed magna imperdiet, commodo magna id, aliquam sapien." });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2018, 2, 2, 9, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2058, 2, 2, 10, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2038, 7, 7, 11, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Quisque tempus ac lacus non pulvinar. Ut malesuada ipsum at condimentum ullamcorper. Nunc tristique vel turpis sit amet convallis. Aenean dapibus mi eu elit bibendum lobortis. Praesent at eros sagittis, hendrerit nisi non, vehicula felis. Fusce placerat nisi vel sapien scelerisque, et congue leo aliquam. Curabitur placerat velit quis eros porttitor ultricies. Integer sit amet egestas felis, quis ultrices elit. Vivamus tristique, felis gravida convallis gravida, nisi metus tincidunt lacus, quis ullamcorper arcu augue ut enim. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 6, 6, 12, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Pellentesque congue maximus odio, ut maximus dui rhoncus sit amet. Praesent tellus tellus, gravida sit amet enim tempor, molestie vehicula velit. Suspendisse nec neque vitae mi ultricies ullamcorper. Quisque pharetra eros ut metus fermentum mattis. Donec dignissim dolor lacus. Integer vel libero a nulla gravida ultrices vel eu nisl. Donec scelerisque diam ligula, scelerisque vestibulum lacus suscipit a. Pellentesque aliquet euismod dui in luctus. Morbi nec laoreet sapien. Sed odio elit, porta non porttitor vel, sollicitudin a magna. Sed mollis, ipsum ut imperdiet feugiat, nibh ipsum sodales quam, et consectetur ante sapien at ex. Cras accumsan mauris ut augue condimentum ultricies. Nam felis tortor, imperdiet at nisl nec, maximus porta nisi. Suspendisse et condimentum ipsum. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 3, 3, 13, 30, 0), activityID = 2, user = "Jasper Friend", contact = "Jasper Friend", colour = "#4caf50", activity = "order", icon = "Send", description = "Integer turpis velit, pharetra eget dictum at, aliquam quis felis. Morbi non metus nisl. Praesent tempor ante nec sem mollis, in volutpat mauris tincidunt. Vivamus rhoncus, metus a suscipit convallis, diam diam aliquam velit, at fermentum quam ex vitae ex. " });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 4, 4, 14, 30, 0), activityID = 4, user = "Jasper Friend", contact = "Jasper Friend", colour = "#2196f3", activity = "quote", icon = "FormatQuoteClose", description = "lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            //_activityList.Add(new Activity() { activityDate = new DateTime(2008, 5, 5, 15, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Fusce scelerisque dapibus ipsum, vitae auctor lectus sollicitudin at. In sed magna imperdiet, commodo magna id, aliquam sapien." });
        }

        private ObservableCollection<Activity> _activityList;
        public ObservableCollection<Activity> activityList
        {
            get { return _activityList ?? (_activityList = new ObservableCollection<Activity>()); }
        }

        private ObservableCollection<Todo> _todoList;
        public ObservableCollection<Todo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<Todo>()); }
        }

        private ObservableCollection<Contact> _contactList;
        public ObservableCollection<Contact> contactList
        {
            get { return _contactList ?? (_contactList = new ObservableCollection<Contact>()); }
        }

        private Account _selectedAccount;
        public Account selectedAccount
        {
            get { return _selectedAccount; }
            set { _selectedAccount = value; OnPropertyChanged("selectedAccount"); Debug.WriteLine("Account changed"); }
        }

        private Account _selectedItem;
        public Account selectedItem
        {
            get { return _selectedItem; }
            set { if (value != null) { _selectedItem = value; } }
        }

        private ObservableCollection<Account> _accountList;
        public ObservableCollection<Account> accountList
        {
            get { return _accountList ?? (_accountList = new ObservableCollection<Account>()); }
        }

        public int recordCount
        {
            get { return accountList.Count(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            string theValue = button.Tag.ToString();
            Debug.Print(theValue);
            var newWindow = new AccountView();
            newWindow.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AccountsController.UpsertAccount(selectedAccount);
            var messageQueue = SnackBar2.MessageQueue;
            Task.Factory.StartNew(() => messageQueue.Enqueue("Saved"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void ContactList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("Views/ContactPreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void TaskList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("Views/TaskPreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void QuoteList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("Views/QuotePreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void OrderList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("Views/OrderPreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            //var taskWindow = new TaskView();
            //taskWindow.Show();
        }

        private void NewCall_Click(object sender, RoutedEventArgs e)
        {
            var callWindow = new CallView();
            callWindow.Show();
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images|*.png;*.jpg;*.gif;*.bmp";
            dialog.Title = "Select image";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalOffset > 0)
            {
                AddressShadow.Visibility = Visibility.Visible;
            }
            else
            {
                AddressShadow.Visibility = Visibility.Collapsed;
            }
        }
    }
}
