using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class QuoteMaterial : INotifyPropertyChanged
    {
        public int quoteMaterialID { get; set; }
        public int quoteID { get; set; }
        public string supplier { get; set; }
        public int supplierID { get; set; }
        public decimal materialCost { get; set; }
        public double rate { get; set; }
        public decimal materialTotal { get; set; }
        public string notes { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
