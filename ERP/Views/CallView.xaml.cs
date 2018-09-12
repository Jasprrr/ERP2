using System.Windows;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for CallView.xaml
    /// </summary>
    public partial class CallView : Window
    {
        public CallView(long callID = 0, long accountID = 0)
        {
            if (callID > 0)
            {
                //TODO: Get call
            }
            if (accountID > 0)
            {
                //TODO: Get account
            }
            InitializeComponent();
        }
    }
}
