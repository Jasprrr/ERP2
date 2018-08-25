using ERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public static class ContactsController
    {
        private static string connString = string.Format("Data Source={0}", @"C:\users\Jasper\Desktop\test.sqlite");

        public static ObservableCollection<Contact> GetContacts()
        {
            ObservableCollection<Contact> q = new ObservableCollection<Contact>();

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                
                SQLiteCommand command;

                command = new SQLiteCommand("SELECT Account_ID, First_Name, Last_Name, Phone_1, Phone_2, Mobile " +
                                            "FROM Contacts " +
                                            "ORDER BY First_Name ASC", conn);

                //"INNER JOIN Accounts ON Contacts.Account_ID = Accounts.Account_ID" + ", Accounts.Account_Name ""

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    q.Add(new Contact()
                    {
                        //contactID = int.Parse(reader["Contact_ID"].ToString()),
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        //accountName = reader["Account_Name"].ToString(),
                        firstName = reader["First_Name"].ToString(),
                        lastName = reader["Last_Name"].ToString(),
                        phone1 = reader["Phone_1"].ToString(),
                        phone2 = reader["Phone_2"].ToString(),
                        mobile = reader["Mobile"].ToString()
                    });
                    q.OrderBy(Contact => Contact.firstName);
                }

                conn.Close();
            }
            return q;
        }

    }
}
