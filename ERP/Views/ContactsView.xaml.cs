using ERP.Controllers;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ContactsView()
        {
            InitializeComponent();
            contactList = ContactsController.GetContacts();
        }

        private ObservableCollection<Contact> _contactList;
        public ObservableCollection<Contact> contactList
        {
            get { return _contactList; }
            set { _contactList = value; OnPropertyChanged("contactList"); }
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditContact_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
