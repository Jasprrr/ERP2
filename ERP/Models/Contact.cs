using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int contactID { get; set; }
        public int accountID { get; set; }
        public string accountName { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string mobile { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string description { get; set; }
        public bool favourite { get; set; }
        public bool accounts { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }

        public string fullName
        {
            get { return firstName + " " + lastName; }
        }
    }
}
