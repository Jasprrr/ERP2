using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int userID { get; set; }
        public string login { get; set; }
        public SecureString password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string colour { get; set; }
        public string homePage { get; set; }
        public string primaryColour { get; set; }
        public string accentColour { get; set; }
        public bool darkTheme { get; set; }
        public bool adminUser { get; set; }

        public string fullName
        {
            get { return firstName + " " + lastName; }
        }

        public string initials
        {
            get { return firstName.Substring(0, 1) + lastName.Substring(0, 1); }
        }

        public DateTime? lastLogin { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
