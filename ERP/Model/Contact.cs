using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class Contact
    {
        public int contactID { get; set; }
        public string forename { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
        public string mobile { get; set; }
        public string primaryEmail { get; set; }
        public string secondaryEmail { get; set; }
        public int accountID { get; set; }
        public bool favourite { get; set; }
        public bool accounts { get; set; }
        public string fullName
        {
            get { return forename + " " + surname; }
        }
    }
}
