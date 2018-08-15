using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class CalendarDay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
                
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DateTime date { get; set; }
        public bool isToday
        {
            get
            {
                return date == DateTime.Today ? true : false;
            }
        }
        public List<ToDo> todo { get; set; }
    }
}
