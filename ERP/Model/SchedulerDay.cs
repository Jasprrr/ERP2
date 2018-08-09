using ERP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class SchedulerDay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
                
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DateTime date { get; set; }
        public bool isToday { get; set; }
        public List<ToDo> todo { get; set; }
    }
}
