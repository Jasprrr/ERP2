using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class PurchaseOrder
    {
        public int purchaseOrderID { get; set; }
        public string purchaseCode { get; set; }
        public int orderID { get; set; }
        public int userID { get; set; }
        public decimal carriageCost { get; set; }
        public decimal grandTotal { get; set; }
        public decimal subtotal { get; set; }
        public decimal VAT { get; set; }

        public int supplierID { get; set; }
        public string supplierName { get; set; }
        public int contactID { get; set; }
        public string contactName { get; set; }

        public DateTime dateDue { get; set; }
        public string invoiceReference { get; set; }
        public string department { get; set; }
        public bool conformanceCertificate { get; set; }

        public bool approved { get; set; }
        public DateTime? dateApproved { get; set; }
        public string approvedBy { get; set; }
        public string description { get; set; }

        public string billingAddress1 { get; set; }
        public string billingAddress2 { get; set; }
        public string billingTown { get; set; }
        public string billingCity { get; set; }
        public string billingCounty { get; set; }
        public string billingCountry { get; set; }
        public string billingPostcode { get; set; }

        public string shippingAddress1 { get; set; }
        public string shippingAddress2 { get; set; }
        public string shippingTown { get; set; }
        public string shippingCity { get; set; }
        public string shippingCounty { get; set; }
        public string shippingCountry { get; set; }
        public string shippingPostcode { get; set; }

        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
