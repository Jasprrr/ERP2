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
    /// Interaction logic for AccountsOnHold.xaml
    /// </summary>
    public partial class AccountsOnHold : UserControl
    {
        public AccountsOnHold()
        {
            accountsOnHold = new List<Account>
            {
                new Account() { accountName="Schools Mailing" },
                new Account() { accountName="BIE Magnum" },
                new Account() { accountName="Big Boss Big Company" },
                new Account() { accountName="Communication Cambridge" },
                new Account() { accountName="Fusion Classroom Design" },
                new Account() { accountName="Gardner Education" },
                new Account() { accountName="AMS Education" },
                new Account() { accountName="Go Bounce Extreme Trampoline Park" },
                new Account() { accountName="Badger Learning" },
            };

            InitializeComponent();
        }

        private List<Account> _accountsOnHold;
        public List<Account> accountsOnHold
        {
            get { return _accountsOnHold; }
            set { _accountsOnHold = value; }
        }
    }
}
