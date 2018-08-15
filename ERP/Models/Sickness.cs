using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    class Sickness : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int sicknessID { get; set; }
        public int employeeID { get; set; }
        public int userID { get; set; }
        public string user { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public decimal totalTime { get; set; }
        public string description { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
