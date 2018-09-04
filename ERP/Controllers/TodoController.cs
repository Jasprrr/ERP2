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
    public static class TodoController
    {
        private static string connString = string.Format("Data Source={0}", @"C:\users\Jasper\Desktop\test.sqlite");

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
                    string sql = _sql.Substring(0, _sql.Length - 5) + ") ORDER BY Todo_Date ASC";
                    command = new SQLiteCommand(sql, conn);
                }
                
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    q.Add(new Todo()
                    {
                        todoID = int.Parse(reader["Todo_ID"].ToString()),
                        todoDate = DateTime.Parse(reader["Todo_Date"].ToString()),
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        account = reader["Account_Name"].ToString(),
                        supplierID = int.Parse(reader["Supplier_ID"].ToString()),
                        supplier = reader["Supplier_Name"].ToString(),
                        subject = reader["Subject"].ToString(),
                        description = reader["Description"].ToString(),
                        completed = bool.Parse(reader["Completed"].ToString()),
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
