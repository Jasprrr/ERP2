using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERP.Control
{
    /// <summary>
    /// Interaction logic for PurchaseOrdersDue.xaml
    /// </summary>
    public partial class PurchaseOrdersDue : UserControl
    {
        public PurchaseOrdersDue()
        {
            purchaseOrders = new List<PurchaseOrder>
            {
                new PurchaseOrder() { supplierName="Schools Mailing", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="BIE Magnum", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="Big Boss Big Company", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="Communication Cambridge", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="Fusion Classroom Design", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="Gardner Education", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="AMS Education", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="Go Bounce Extreme Trampoline Park", purchaseOrderID=120258 },
                new PurchaseOrder() { supplierName="Badger Learning", purchaseOrderID=120258 }
            };

            InitializeComponent();
        }

        private List<PurchaseOrder> _purchaseOrders;
        public List<PurchaseOrder> purchaseOrders
        {
            get { return _purchaseOrders; }
            set { _purchaseOrders = value; }
        }
    }
}
