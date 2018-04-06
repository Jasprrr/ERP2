using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class QuoteTime : INotifyPropertyChanged
    {
        public int quoteTimeID { get; set; }
        public int quoteID { get; set; }
        public string department { get; set; }
        public double estatimatedTime { get; set; }
        public int nominalCode { get; set; }
        public string notes { get; set; }
        public int line { get; set; }
        public decimal rateCost { get; set; }
        public decimal initialCost { get; set; }
        public decimal timeTotal { get; set; }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
