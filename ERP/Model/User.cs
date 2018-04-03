using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string login { get; set; }
        public SecureString password { get; set; }
        public string forename { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string colour { get; set; }
        public string homePage { get; set; }
        public string fullName
        {
            get { return forename + " " + surname; }
        }

        public string initials
        {
            get { return forename.Substring(0, 1) + surname.Substring(0, 1); }
        }

        public bool selected { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateModified { get; set; }
        public DateTime? lastLogin { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
