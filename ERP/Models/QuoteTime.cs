using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class QuoteTime : INotifyPropertyChanged
    {
        int _timeID;
        public int timeID
        {
            get { return _timeID; }
            set { _timeID = value; OnPropertyChanged("timeID"); }
        }

        int _quoteID;
        public int quoteID
        {
            get { return _quoteID; }
            set { _quoteID = value; OnPropertyChanged("quoteID"); }
        }

        int _line;
        public int line
        {
            get { return _line; }
            set { _line = value; OnPropertyChanged("line"); }
        }

        int _nominalCode;
        public int nominalCode
        {
            get { return _nominalCode; }
            set { _nominalCode = value; OnPropertyChanged("nominalCode"); }
        }

        string _department;
        public string department
        {
            get { return _department; }
            set { _department = value; OnPropertyChanged("department"); }
        }

        decimal _estimatedTime;
        public decimal estimatedTime
        {
            get { return _estimatedTime; }
            set { _estimatedTime = value; OnPropertyChanged("estimatedTime"); }
        }
        
        string _notes;
        public string notes
        {
            get { return _notes; }
            set { _notes = value; OnPropertyChanged("notes"); }
        }

        public string nominalCodeWithDepartment
        {
            get { return nominalCode + " " + department; }
        }

        decimal _rate;
        public decimal rate
        {
            get { return _rate; }
            set { _rate = value; OnPropertyChanged("rate"); }
        }

        decimal _cost;
        public decimal cost
        {
            get { return _cost; }
            set { _cost = value; OnPropertyChanged("cost"); }
        }

        decimal _total;
        public decimal total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged("total"); }
        }

        bool _selected;
        public bool selected
        {
            get { return _selected; }
            set { _selected = value; OnPropertyChanged("selected"); }
        }


        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
