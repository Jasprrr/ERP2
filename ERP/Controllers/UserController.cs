using ERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public static class UserController
    {
        private static string connString = string.Format("Data Source={0}", @"C:\users\Jasper\Desktop\test.sqlite");

        //private static byte[] GenerateSaltedHash(string password, string salt)
        //{
        //    HashAlgorithm hash = new SHA256Managed();

        //    byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
        //    byte[] saltBytes = Convert.FromBase64String(salt);

        //    byte[] passwordSaltByes = new byte[passwordBytes.Length + saltBytes.Length];
        //    salt.CopyTo()

        //    return q;
        //}

        public static bool UserLogin(string username, SecureString password)
        {

            return true;
        }

        public static ObservableCollection<Todo> GetTodos(ObservableCollection<User> users = null)
        {
            ObservableCollection<Todo> q = new ObservableCollection<Todo>();

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();

                SQLiteCommand command;

                if (users == null)
                {
                    command = new SQLiteCommand("SELECT * FROM Todo ORDER BY Todo_Date ASC", conn);
                }
                else
                {
                    string _sql = "SELECT * FROM Todo WHERE ";
                    foreach (User item in users)
                    {
                        string.Concat(_sql + "((User_ID) = {0}) AND ", item.userID);
                    }
                    string sql = _sql.Substring(0, _sql.Length - 3) + ") ORDER BY Todo_Date ASC";
                    command = new SQLiteCommand(sql, conn);
                }

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    q.Add(new Todo()
                    {
                        todoID = int.Parse(reader["Todo_ID"].ToString()),
                        todoDate = DateTime.Parse(reader["Due_Date"].ToString()),
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        account = reader["Account_Name"].ToString(),
                        supplierID = int.Parse(reader["Supplier_ID"].ToString()),
                        supplier = reader["Supplier_Name"].ToString(),
                        subject = reader["subject"].ToString(),
                        description = reader["Description"].ToString(),
                        completed = bool.Parse(reader["completed"].ToString()),
                        dateCompleted = DateTime.Parse(reader["Date_Completed"].ToString()),
                        dateModified = DateTime.Parse(reader["Date_Modified"].ToString()),
                        dateCreated = DateTime.Parse(reader["Date_Created"].ToString()),
                        user = reader["User"].ToString(),
                        userID = int.Parse(reader["User_ID"].ToString())
                    });
                }

                conn.Close();
            }
            return q;
        }

    }
}
