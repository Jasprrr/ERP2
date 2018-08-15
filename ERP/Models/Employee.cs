using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public string jobTitle { get; set; }
        public string department { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public bool partTime { get; set; }
        public int departmentID { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string healthIssues { get; set; }
        public string emergencyContact { get; set; }
        public string emergencyPhone { get; set; }
        public int hours { get; set; }
        public string hoursNotes { get; set; }
        public int holidayTime { get; set; }
        public int holidayMaxAllowance { get; set; }
        public DateTime? holidayIncreaseDate { get; set; }

        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
    }
}
