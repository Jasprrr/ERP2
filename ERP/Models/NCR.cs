using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    class NCR : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int ncrID { get; set; }
        public string category { get; set; }
        public int supplierID { get; set; }
        public string supplierName { get; set; }
        public int accountID { get; set; }
        public string accountName { get; set; }
        public int orderID { get; set; }
        public int purchaseOrderID { get; set; }
        public string customerReference { get; set; }
        public string documentReference { get; set; }
        public string documentHyperlink { get; set; }
        public string itemCode { get; set; }
        public string description { get; set; }
        public string containment { get; set; }
        public string disposition { get; set; }
        public DateTime? dateRaised { get; set; }
        public string raisedBy { get; set; }
        public string cause { get; set; }
        public string actionProposed { get; set; }
        public DateTime? targetDate { get; set; }
        public string actionTaken { get; set; }
        public DateTime? dateVerified { get; set; }
        public bool actionEffective { get; set; }
        public string verifiedBy { get; set; }
        public string personResponsible { get; set; }
        public string materialCost { get; set; }
        public decimal labourCost { get; set; }
        public decimal replacementHours { get; set; }
        public decimal grandTotal { get; set; }
        public int correctiveOrderID { get; set; }
        public int quantity { get; set; }
        public DateTime? despatchDate { get; set; }
        public bool isSupplier { get; set; }
        public string severity { get; set; }
        public int userID { get; set; }
        public string user { get; set; }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
