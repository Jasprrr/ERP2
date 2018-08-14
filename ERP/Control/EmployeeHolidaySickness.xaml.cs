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
    /// Interaction logic for EmployeeHolidaySickness.xaml
    /// </summary>
    public partial class EmployeeHolidaySickness : UserControl
    {
        public EmployeeHolidaySickness()
        {
            employees = new List<employeeHolidaySickness>
            {
                new employeeHolidaySickness() { employeeName="Jasper Friend", type="Holiday" },
                new employeeHolidaySickness() { employeeName="Luke Harvey", type="Sickness" },
                new employeeHolidaySickness() { employeeName="Rob Connor", type="Holiday" },
                new employeeHolidaySickness() { employeeName="Sarah Rodgerson", type="Holiday" },
                new employeeHolidaySickness() { employeeName="Luke Harvey", type="Sickness" },
                new employeeHolidaySickness() { employeeName="Rob Connor", type="Holiday" },
            };

            InitializeComponent();
        }

        public class employeeHolidaySickness
        {
            public string employeeName { get; set; }
            public string type { get; set; }
        }

        private List<employeeHolidaySickness> _employees;
        public List<employeeHolidaySickness> employees
        {
            get { return _employees; }
            set { _employees = value; }
        }
    }
}