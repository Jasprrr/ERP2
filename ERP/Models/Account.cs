using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int accountID { get; set; }
        public int userID { get; set; }
        public string user { get; set; }
        public string accountName { get; set; }
        public string accountCode { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public string description { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string defaultCarriage { get; set; }
        public int defaultNominalCode { get; set; }
        public string registrationNumber { get; set; }
        public string taxCode { get; set; }
        public string VATNumber { get; set; }
        public DateTime? tradingSince { get; set; }
        public bool onHold { get; set; }
        public string onHoldReason { get; set; }
        public DateTime? onHoldDate { get; set; }
        public DateTime? lastCreditCheck { get; set; }
        public DateTime? nextCreditCheck { get; set; }
        public string leadSource { get; set; }
        public bool prepayment { get; set; }
        public bool delete { get; set; }

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

        public string registeredAddress1 { get; set; }
        public string registeredAddress2 { get; set; }
        public string registeredCity { get; set; }
        public string registeredCounty { get; set; }
        public string registeredCountry { get; set; }
        public string registeredPostcode { get; set; }
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
