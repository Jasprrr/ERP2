﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Todo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int todoID { get; set; }
        public DateTime todoDate { get; set; }
        public int accountID { get; set; }
        public string account { get; set; }
        public int supplierID { get; set; }
        public string supplier { get; set; }
        public int quoteID { get; set; }
        public int orderID { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public bool completed { get; set; }
        public DateTime dateCompleted { get; set; }
        public DateTime dateModified { get; set; }
        public DateTime dateCreated { get; set; }
        public int userID { get; set; }
        public string user { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
