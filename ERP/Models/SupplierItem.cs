using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    class SupplierItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int supplierItemID { get; set; }
        public int supplierID { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public decimal costPerUnit { get; set; }
        public string notes { get; set; }
        public bool coshhItem { get; set; }
        public string coshhNumber { get; set; }
        public DateTime? assessmentDate { get; set; }
        public int departmentID { get; set; }
        public DateTime? expiryDate { get; set; }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
