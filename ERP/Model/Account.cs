using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string accountCode { get; set; }

        public string Initials
        {
            get
            {
                return name.Substring(0, 1);
            }
        }
        

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
