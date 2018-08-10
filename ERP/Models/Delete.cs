using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Delete : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string fieldName { get; set; }
        public bool dialogOpen { get; set; }
        public string deleteString {
            get
            {
                return "Are you sure you want to delete this " + type + "?";
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
