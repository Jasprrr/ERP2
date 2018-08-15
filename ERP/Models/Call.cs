using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    class Call : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int callID { get; set; }
        public string subject { get; set; }
        public int accountID { get; set; }
        public int contactID { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string purpose { get; set; }
        public int userID { get; set; }
        public string user { get; set; }
        public string outcome { get; set; }
        public string accountRating { get; set; }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
