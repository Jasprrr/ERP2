using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    //[Table("Quote")]
    public class Quote : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int quoteID { get; set; }
        public int? accountID { get; set; }
        public string accountName { get; set; }
        public string accountRating { get; set; }
        public int? contactID { get; set; }
        public string contactName { get; set; }

        public string description { get; set; }
        public string purchaseOrder { get; set; }
        public decimal? leadTime { get; set; }
        public DateTime? dueDate { get; set; }
        public double? successChance { get; set; }

        public string carriageOption { get; set; }
        public string carriageNotes { get; set; }
        public decimal carriageCost { get; set; }

        public decimal cost { get; set; }
        public decimal VAT { get; set; }
        public decimal total { get; set; }

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

        public int userID { get; set; }
        public string user { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public bool selected { get; set; }

        public bool locked { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
