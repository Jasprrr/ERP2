using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class ToDo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; set; }
        public DateTime dueDate { get; set; }
        public int accountID { get; set; }
        public string account { get; set; }

        public string description { get; set; }
        public string taskType { get; set; }
        public bool complete { get; set; }
        public string userID { get; set; }
        public string user { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
