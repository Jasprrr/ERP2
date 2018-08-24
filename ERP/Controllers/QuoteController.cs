using ERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    internal static class QuoteController
    {
        private static string connString = string.Format("Data Source={0}", @"C:\users\Jasper\Desktop\test.sqlite");

        public static ObservableCollection<Quote> GetQuotes(string search = null)
        {
            ObservableCollection<Quote> q = new ObservableCollection<Quote>();

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();

                SQLiteCommand command;

                if (string.IsNullOrEmpty(search))
                {
                    command = new SQLiteCommand("SELECT * FROM Accounts", conn);
                }
                else
                {
                    command = new SQLiteCommand("SELECT * FROM Accounts WHERE Account_Name Like @accountName", conn);
                    command.Parameters.AddWithValue("@accountName", "%" + search + "%");
                }

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    q.Add(new Quote()
                    {
                        quoteID = int.Parse(reader["Quote_ID"].ToString()),
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        accountName = reader["Account_Name"].ToString(),
                        accountRating = reader["Account_Rating"].ToString(),
                        billingAddress1 = reader["Billing_Address_1"].ToString(),
                        billingAddress2 = reader["Billing_Address_2"].ToString(),
                        billingCity = reader["Billing_City"].ToString(),
                        billingCounty = reader["Billing_County"].ToString(),
                        billingCountry = reader["Billing_Country"].ToString(),
                        billingPostcode = reader["Billing_Postcode"].ToString(),
                        shippingAddress1 = reader["Shipping_Address_1"].ToString(),
                        shippingAddress2 = reader["Shipping_Address_2"].ToString(),
                        shippingCity = reader["Shipping_City"].ToString(),
                        shippingCounty = reader["Shipping_County"].ToString(),
                        shippingCountry = reader["Shipping_Country"].ToString(),
                        shippingPostcode = reader["Shipping_Postcode"].ToString(),
                        carriageCost = decimal.Parse(reader["Carriage_Cost"].ToString()),
                        carriageNotes = reader["Carriage_Notes"].ToString(),
                        carriageOption = reader["Carriage_Option"].ToString(),
                        contactID = int.Parse(reader["Contact_ID"].ToString()),
                        contactName = reader["Contact_Name"].ToString(),
                        cost = decimal.Parse(reader["Subtotal"].ToString()),
                        VAT = decimal.Parse(reader["VAT"].ToString()),
                        total = decimal.Parse(reader["Grand_Total"].ToString()),
                        dueDate = DateTime.Parse(reader["Due_Date"].ToString()),
                        leadTime = decimal.Parse(reader["Lead_Time"].ToString()),

                        description = reader["Description"].ToString(),

                        dateCreated = DateTime.Parse(reader["Date_Created"].ToString()),
                        dateModified = DateTime.Parse(reader["Date_Modified"].ToString()),
                    });
                }
                conn.Close();
            }
            return q;
        }
    }
}
