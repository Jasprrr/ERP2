using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Model
{
    public class User
    {
        public string forename { get; set; }
        public string surname { get; set; }
        public string initials
        {
            get { return forename.Substring(0, 1) + surname.Substring(0, 1); }
        }
    }
}
