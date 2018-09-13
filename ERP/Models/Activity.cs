using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Activity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public int activityID { get; set; }
        public string icon { get; set; }
        public string activity { get; set; }
        public string header { get; set; }
        public string subheader { get; set; }
        public string description { get; set; }
        public string colour { get; set; }
        public DateTime activityDate { get; set; }
        public string user { get; set; }

        public string activityDescription
        {
            get
            {
                switch (activity)
                {
                    case "call":
                        return description;
                    case "Task":
                        return description;
                    case "quote":
                        return activityID.ToString();
                    case "order":
                        return activityID.ToString();
                    default:
                        return "";
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
