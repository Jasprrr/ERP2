using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class ToDo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime dueDate { get; set; }
        public string account { get; set; }
        public string description { get; set; }
        public string taskType { get; set; }
        public bool complete { get; set; }
        public string userID { get; set; }
        public string user { get; set; }

        public string userInitials {
            get
            {
                if (todoUsers.Count() > 1)
                {
                    return todoUsers.Count().ToString();
                }
                else if (todoUsers.Count() == 1){
                    return todoUsers.FirstOrDefault().Substring(0,2);
                }
                return null;
            }
        }
        public List<string> todoUsers
        {
            get
            {
                if (user != null)
                {
                    return user.Split(',').ToList();
                }
                else
                {
                    return null;
                }
            }
        }
        public List<string> todoUserIDs
        {
            get
            {
                if (userID != null)
                {
                    return userID.Split(',').ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
