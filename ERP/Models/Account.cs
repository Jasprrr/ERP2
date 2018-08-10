using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int accountID { get; set; }
        public string accountName { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string accountCode { get; set; }

        public string Initials
        {
            get
            {
                return accountName.Substring(0, 1);
            }
        }
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
