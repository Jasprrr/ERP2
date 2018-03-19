using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class QuoteItem
    {
        public int quoteItemID { get; set; }
        public int quoteID { get; set; }
        public int line { get; set; }
        public string itemCode { get; set; }
        public int nominalCode { get; set; }
        public string batchNumber { get; set; }
        public string externalDescription { get; set; }
        public string internalDescription { get; set; }
        public string comments { get; set; }

        public int quantity { get; set; }
        public decimal itemCost { get; set; }
        public decimal itemTotal
        {
            get
            {
                if (quantity == 0 || itemCost == 0)
                {
                    return 0;
                }
                else
                {
                    return quantity * itemCost;
                }
            }
        }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
        public bool visisbility { get; set; }
        public bool selected { get; set; }
    }
}
