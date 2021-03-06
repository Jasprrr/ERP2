﻿using ERP.Controllers;
using ERP.Models;
using System;
using System.Collections.Generic;
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

namespace ERP.Control
{
    /// <summary>
    /// Interaction logic for AccountsOnHold.xaml
    /// </summary>
    public partial class AccountsOnHold : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AccountsOnHold()
        {
            InitializeComponent();
            accountsOnHold = AccountsController.GetAccountsOnHold();
        }

        private List<Account> _accountsOnHold;
        public List<Account> accountsOnHold
        {
            get { return _accountsOnHold; }
            set { _accountsOnHold = value; OnPropertyChanged("accountsOnHold"); }
        }
    }
}
