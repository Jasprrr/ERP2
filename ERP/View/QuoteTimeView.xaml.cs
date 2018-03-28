using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for QuoteTimeView.xaml
    /// </summary>
    public partial class QuoteTimeView : Page
    {
        public QuoteTimeView()
        {
            InitializeComponent();
        }

        public void Save()
        {
            Debug.Write("Saved");
        }
    }
}
