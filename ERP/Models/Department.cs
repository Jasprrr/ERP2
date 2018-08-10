using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Department : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int departmentID { get; set; }
        public string department { get; set; }
        public int nominalCode { get; set; }
        public decimal initalCost { get; set; }
        public decimal rateCost { get; set; }

        public string nominalCodeWithDepartment
        {
            get { return nominalCode + " " + department; }
        }
    }
}
