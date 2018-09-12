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
    /// Interaction logic for RelatedTodoItem.xaml
    /// </summary>
    public partial class RelatedTodoItem : UserControl
    {
        public RelatedTodoItem()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler CompleteTodo;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CompleteTodo?.Invoke(this, new RoutedEventArgs());
        }
    }
}
