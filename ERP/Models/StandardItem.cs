using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    class StandardItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int standardItemID { get; set; }
        public string itemCode { get; set; }
        public string internalDescription { get; set; }
        public string externalDescription { get; set; }
        public string notes { get; set; }
        public int nominalCode { get; set; }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
