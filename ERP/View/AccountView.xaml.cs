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
using System.Net.Mail;
using System.Net;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class AccountView : Window
    {
        public AccountView()
        {
            //Debug.Print(accountID.ToString());
            _todoList = new ObservableCollection<ToDo>();
            _contactList = new ObservableCollection<Contact>();
            _activityList = new ObservableCollection<Activity>();
            InitializeComponent();

            _accountList.Add(new Account() { accountCode = "TIMC", accountName = "Tim Co.", email = "tim@tim.co", telephone = "0800 000 001" });
            _accountList.Add(new Account() { accountCode = "BOBC", accountName = "Bob Co.", email = "bob@bob.co", telephone = "0800 000 002" });
            _accountList.Add(new Account() { accountCode = "ROBC", accountName = "Rob Co.", email = "rob@rob.co", telephone = "0800 000 003" });
            _accountList.Add(new Account() { accountCode = "JIMC", accountName = "Jim Co.", email = "jim@jim.co", telephone = "0800 000 004" });
            _accountList.Add(new Account() { accountCode = "SAMC", accountName = "Sam Co.", email = "sam@sam.co", telephone = "0800 000 005" });

            _contactList.Add(new Contact() { forename = "Jasper", surname = "Friend", primaryEmail = "jasper@schoolsmailing.co.uk", telephone = "0117 9584 972", favourite = true });
            _contactList.Add(new Contact() { forename = "Josh", surname = "Kaner", primaryEmail = "josh@schoolsmailing.co.uk", telephone = "0117 9584 972", accounts = true });
            _contactList.Add(new Contact() { forename = "Sarah", surname = "Rodgerson" });
            _contactList.Add(new Contact() { forename = "Luke", surname = "Harvey", primaryEmail = "luke@schoolsmailing.co.uk" });

            _activityList.Add(new Activity() { activityDate = new DateTime(2018, 2, 2, 9, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2058, 2, 2, 10, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2038, 7, 7, 11, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Quisque tempus ac lacus non pulvinar. Ut malesuada ipsum at condimentum ullamcorper. Nunc tristique vel turpis sit amet convallis. Aenean dapibus mi eu elit bibendum lobortis. Praesent at eros sagittis, hendrerit nisi non, vehicula felis. Fusce placerat nisi vel sapien scelerisque, et congue leo aliquam. Curabitur placerat velit quis eros porttitor ultricies. Integer sit amet egestas felis, quis ultrices elit. Vivamus tristique, felis gravida convallis gravida, nisi metus tincidunt lacus, quis ullamcorper arcu augue ut enim. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 6, 6, 12, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Pellentesque congue maximus odio, ut maximus dui rhoncus sit amet. Praesent tellus tellus, gravida sit amet enim tempor, molestie vehicula velit. Suspendisse nec neque vitae mi ultricies ullamcorper. Quisque pharetra eros ut metus fermentum mattis. Donec dignissim dolor lacus. Integer vel libero a nulla gravida ultrices vel eu nisl. Donec scelerisque diam ligula, scelerisque vestibulum lacus suscipit a. Pellentesque aliquet euismod dui in luctus. Morbi nec laoreet sapien. Sed odio elit, porta non porttitor vel, sollicitudin a magna. Sed mollis, ipsum ut imperdiet feugiat, nibh ipsum sodales quam, et consectetur ante sapien at ex. Cras accumsan mauris ut augue condimentum ultricies. Nam felis tortor, imperdiet at nisl nec, maximus porta nisi. Suspendisse et condimentum ipsum. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 3, 3, 13, 30, 0), activityID = 2, user = "Jasper Friend", contact = "Jasper Friend", colour = "#4caf50", activity = "order", icon = "Send", description = "Integer turpis velit, pharetra eget dictum at, aliquam quis felis. Morbi non metus nisl. Praesent tempor ante nec sem mollis, in volutpat mauris tincidunt. Vivamus rhoncus, metus a suscipit convallis, diam diam aliquam velit, at fermentum quam ex vitae ex. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 4, 4, 14, 30, 0), activityID = 4, user = "Jasper Friend", contact = "Jasper Friend", colour = "#2196f3", activity = "quote", icon = "FormatQuoteClose", description = "lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 5, 5, 15, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Fusce scelerisque dapibus ipsum, vitae auctor lectus sollicitudin at. In sed magna imperdiet, commodo magna id, aliquam sapien." });
            _activityList.Add(new Activity() { activityDate = new DateTime(2018, 2, 2, 9, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2058, 2, 2, 10, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean non risus maximus, dictum neque vel, varius dolor. Pellentesque accumsan venenatis velit quis vulputate. Vestibulum ornare massa ac lacus lobortis, id mollis leo iaculis. Maecenas faucibus facilisis dolor, id aliquet lectus laoreet at. Praesent sit amet quam quis massa sollicitudin facilisis non sed neque. Donec tincidunt tellus at lobortis iaculis. Vestibulum iaculis nibh et dui tincidunt interdum. Vestibulum eget eros tortor. Proin eu lobortis nulla, vel consequat nisi. Morbi ante velit, posuere vel odio vitae, consequat lobortis odio. Sed euismod tempus volutpat. Suspendisse suscipit massa eu lorem pretium accumsan. Aliquam erat volutpat. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2038, 7, 7, 11, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Quisque tempus ac lacus non pulvinar. Ut malesuada ipsum at condimentum ullamcorper. Nunc tristique vel turpis sit amet convallis. Aenean dapibus mi eu elit bibendum lobortis. Praesent at eros sagittis, hendrerit nisi non, vehicula felis. Fusce placerat nisi vel sapien scelerisque, et congue leo aliquam. Curabitur placerat velit quis eros porttitor ultricies. Integer sit amet egestas felis, quis ultrices elit. Vivamus tristique, felis gravida convallis gravida, nisi metus tincidunt lacus, quis ullamcorper arcu augue ut enim. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 6, 6, 12, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#f44336", activity = "call", icon = "Phone", description = "Pellentesque congue maximus odio, ut maximus dui rhoncus sit amet. Praesent tellus tellus, gravida sit amet enim tempor, molestie vehicula velit. Suspendisse nec neque vitae mi ultricies ullamcorper. Quisque pharetra eros ut metus fermentum mattis. Donec dignissim dolor lacus. Integer vel libero a nulla gravida ultrices vel eu nisl. Donec scelerisque diam ligula, scelerisque vestibulum lacus suscipit a. Pellentesque aliquet euismod dui in luctus. Morbi nec laoreet sapien. Sed odio elit, porta non porttitor vel, sollicitudin a magna. Sed mollis, ipsum ut imperdiet feugiat, nibh ipsum sodales quam, et consectetur ante sapien at ex. Cras accumsan mauris ut augue condimentum ultricies. Nam felis tortor, imperdiet at nisl nec, maximus porta nisi. Suspendisse et condimentum ipsum. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 3, 3, 13, 30, 0), activityID = 2, user = "Jasper Friend", contact = "Jasper Friend", colour = "#4caf50", activity = "order", icon = "Send", description = "Integer turpis velit, pharetra eget dictum at, aliquam quis felis. Morbi non metus nisl. Praesent tempor ante nec sem mollis, in volutpat mauris tincidunt. Vivamus rhoncus, metus a suscipit convallis, diam diam aliquam velit, at fermentum quam ex vitae ex. " });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 4, 4, 14, 30, 0), activityID = 4, user = "Jasper Friend", contact = "Jasper Friend", colour = "#2196f3", activity = "quote", icon = "FormatQuoteClose", description = "lorem ipsum dolor sit amet, consectetur adipiscing elit." });
            _activityList.Add(new Activity() { activityDate = new DateTime(2008, 5, 5, 15, 30, 0), activityID = 1, user = "Jasper Friend", contact = "Jasper Friend", colour = "#ff9800", activity = "Task", icon = "CalendarCheck", description = "Fusce scelerisque dapibus ipsum, vitae auctor lectus sollicitudin at. In sed magna imperdiet, commodo magna id, aliquam sapien." });

            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 2, 2), account = "Acc 02", description = "Fusce scelerisque dapibus ipsum, vitae auctor lectus sollicitudin at. In sed magna imperdiet, commodo magna id, aliquam sapien.", complete = false, taskType = "Task", user = "Bob" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 3, 3), account = "Acc 03", description = "Fusce scelerisque dapibus ipsum, vitae auctor lectus sollicitudin at. In sed magna imperdiet, commodo magna id, aliquam sapien.", complete = false, taskType = "Task", user = "Rob" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 3, 3), account = "Acc 04", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Jim" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 5, 5), account = "Acc 05", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Sam" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 6, 6), account = "Acc 06", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Tim" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 7, 7), account = "Acc 07", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Bob" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 8, 8), account = "Acc 08", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Rob" });
            _todoList.Add(new ToDo() { dueDate = new DateTime(2008, 4, 9), account = "Acc 04", description = "Lorem ipsum.", complete = false, taskType = "Task", user = "Jim" });
        }

        private ObservableCollection<Activity> _activityList;
        public ObservableCollection<Activity> activityList
        {
            get { return _activityList ?? (_activityList = new ObservableCollection<Activity>()); }
        }

        private ObservableCollection<ToDo> _todoList;
        public ObservableCollection<ToDo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<ToDo>()); }
        }

        private ObservableCollection<Contact> _contactList;
        public ObservableCollection<Contact> contactList
        {
            get { return _contactList ?? (_contactList = new ObservableCollection<Contact>()); }
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
            var button = sender as Button;
            string theValue = button.Tag.ToString();
            Debug.Print(theValue);
            var newWindow = new AccountView();
            newWindow.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var messageQueue = SnackBar2.MessageQueue;
            Task.Factory.StartNew(() => messageQueue.Enqueue("Saved"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void ContactList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("View/ContactPreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void TaskList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("View/TaskPreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void QuoteList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("View/QuotePreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void OrderList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PreviewFrame.Navigate(new Uri("View/OrderPreview.xaml", UriKind.Relative));
            PreviewDialog.IsOpen = !PreviewDialog.IsOpen;
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            var taskWindow = new TaskView();
            taskWindow.Show();
        }

        private void NewCall_Click(object sender, RoutedEventArgs e)
        {
            var callWindow = new CallView();
            callWindow.Show();
        }
    }
}
