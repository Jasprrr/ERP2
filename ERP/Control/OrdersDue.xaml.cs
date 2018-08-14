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
    /// Interaction logic for OrdersDue.xaml
    /// </summary>
    public partial class OrdersDue : UserControl
    {
        public OrdersDue()
        {
            orders = new List<Order>
            {
                new Order() { accountName="Schools Mailing", worksOrderNumber=120258 },
                new Order() { accountName="BIE Magnum", worksOrderNumber=120258 },
                new Order() { accountName="Big Boss Big Company", worksOrderNumber=120258 },
                new Order() { accountName="Communication Cambridge", worksOrderNumber=120258 },
                new Order() { accountName="Fusion Classroom Design", worksOrderNumber=120258 },
                new Order() { accountName="Gardner Education", worksOrderNumber=120258 },
                new Order() { accountName="AMS Education", worksOrderNumber=120258 },
                new Order() { accountName="Go Bounce Extreme Trampoline Park", worksOrderNumber=120258 },
                new Order() { accountName="Badger Learning", worksOrderNumber=120258 }
            };

            InitializeComponent();
        }

        private List<Order> _orders;
        public List<Order> orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
    }
}
