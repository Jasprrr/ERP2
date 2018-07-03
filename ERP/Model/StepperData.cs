using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class StepperData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int stage { get; set; }
        public string label { get; set; }
        public string errorLabel { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
