using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class QuoteItem : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int quoteID { get; set; }
        public int line { get; set; }
        public string itemCode { get; set; }
        public int nominalCode { get; set; }
        public string department { get; set; }
        public string batchNumber { get; set; }
        public string externalDescription { get; set; }
        public string internalDescription { get; set; }
        public string comments { get; set; }

        public string nominalCodeWithDepartment
        {
            get { return nominalCode + " " + department; }
        }

        public int quantity { get; set; }
        public decimal cost { get; set; }
        public decimal total
        {
            get
            {
                if (quantity == 0 || cost == 0)
                {
                    return 0;
                }
                else
                {
                    return quantity * cost;
                }
            }
        }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
        public bool visisbility { get; set; }
        public bool selected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
