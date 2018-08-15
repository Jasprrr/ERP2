using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    class Accident : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int accidentID { get; set; }
        public int employeeID { get; set; }
        public DateTime? accidentDate { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int accidentTime { get; set; }
        public int userID { get; set; }
        public string user { get; set; }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
