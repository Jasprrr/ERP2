using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int orderID { get; set; }
        public int quoteID { get; set; }
        public int userID { get; set; }
        public bool selected { get; set; }
        public decimal estimatedTime { get; set; }
        public decimal actualTime { get; set; }
        public decimal materialCost { get; set; }
        public decimal subcontractCost { get; set; }
        public decimal carriageCost { get; set; }
        public decimal subtotal { get; set; }
        public string customerReference { get; set; }
        public int leadTime { get; set; }
        public int leadType { get; set; }
        public string Status { get; set; }
        public string description { get; set; }
        public string carriageOption { get; set; }
        public string carriageNotes { get; set; }
        public DateTime? dateDue { get; set; }
        public bool reviewed { get; set; }
        public int docketNumber { get; set; }
        public int worksOrderNumber { get; set; }
        public int worksOrderNumberSuffix { get; set; }
        public int worksOrderNumberYear { get; set; }
        public string notes { get; set; }
        public string accountNumber { get; set; }
        public bool confirmation { get; set; }
        public DateTime? dateConfirmed { get; set; }

        public int accountID { get; set; }
        public string accountName { get; set; }
        public string accountRating { get; set; }
        public int contactID { get; set; }
        public string contactName { get; set; }

        public string billingAddress1 { get; set; }
        public string billingAddress2 { get; set; }
        public string billingCity { get; set; }
        public string billingCounty { get; set; }
        public string billingCountry { get; set; }
        public string billingPostcode { get; set; }

        public string shippingAddress1 { get; set; }
        public string shippingAddress2 { get; set; }
        public string shippingCity { get; set; }
        public string shippingCounty { get; set; }
        public string shippingCountry { get; set; }
        public string shippingPostcode { get; set; }

        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
