using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using ERP.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using System.Diagnostics;
using System.Windows;
using System.IO;

namespace ERP.Controllers
{
    internal static class AccountsController
    {
        private static string connString = string.Format("Data Source={0}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\test.sqlite"));

        public static ObservableCollection<Account> GetAccounts(string search = null)
        {
            ObservableCollection<Account> q = new ObservableCollection<Account>();

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
                    q.Add(new Account()
                    {
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        accountName = reader["Account_Name"].ToString(),
                        accountCode = reader["Account_Code"].ToString(),
                        description = reader["Description"].ToString(),
                        phone1 = reader["Phone_1"].ToString(),
                        phone2 = reader["Phone_2"].ToString(),
                        email = reader["Email"].ToString(),
                        status = reader["Status"].ToString()
                    });
                }
                conn.Close();
            }
            return q;
        }

        public static List<Account> GetAccountsOnHold()
        {
            List<Account> q = new List<Account>();

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();

                SQLiteCommand command;

                command = new SQLiteCommand("SELECT * FROM Accounts WHERE On_Hold = True", conn);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    q.Add(new Account()
                    {
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        accountName = reader["Account_Name"].ToString(),
                        accountCode = reader["Account_Code"].ToString(),
                        description = reader["Description"].ToString(),
                        phone1 = reader["Phone_1"].ToString(),
                        phone2 = reader["Phone_2"].ToString(),
                        email = reader["Email"].ToString(),
                        status = reader["Status"].ToString()
                    });
                }

                conn.Close();
            }
            return q;
        }

        public static Account GetAccount(int accountID)
        {
            Account q = new Account();

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();

                SQLiteCommand command;

                command = new SQLiteCommand("SELECT * FROM Accounts WHERE Account_ID Like @accountID", conn);
                command.Parameters.AddWithValue("@accountID", accountID);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine(reader["Trading_Since"].ToString());

                    q = new Account()
                    {
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        accountName = reader["Account_Name"].ToString(),
                        user = reader["User_Name"].ToString(),
                        accountCode = reader["Account_Code"].ToString(),
                        dateModified = DateTime.Parse(reader["Date_Modified"].ToString()),
                        dateCreated = DateTime.Parse(reader["Date_Created"].ToString()),
                        description = reader["Description"].ToString(),
                        phone1 = reader["Phone_1"].ToString(),
                        phone2 = reader["Phone_2"].ToString(),
                        email = reader["Email"].ToString(),
                        status = reader["Status"].ToString(),
                        defaultCarriage = reader["Default_Carriage"].ToString(),
                        defaultNominalCode = int.Parse(reader["Default_Nominal_Code"].ToString()),
                        registrationNumber = reader["Registration_Number"].ToString(),
                        taxCode = reader["Tax_Code"].ToString(),
                        VATNumber = reader["VAT_Number"].ToString(),
                        tradingSince = string.IsNullOrWhiteSpace(reader["Trading_Since"].ToString()) ? (DateTime?)null : DateTime.Parse(reader["Trading_Since"].ToString()),
                        onHold = bool.Parse(reader["On_Hold"].ToString()),
                        onHoldReason = reader["On_Hold_Reason"].ToString(),
                        onHoldDate = string.IsNullOrWhiteSpace(reader["On_Hold_Date"].ToString()) ? (DateTime?)null : DateTime.Parse(reader["On_Hold_Date"].ToString()),
                        lastCreditCheck = string.IsNullOrWhiteSpace(reader["Last_Credit_Check"].ToString()) ? (DateTime?)null : DateTime.Parse(reader["Last_Credit_Check"].ToString()),
                        nextCreditCheck = string.IsNullOrWhiteSpace(reader["Next_Credit_Check"].ToString()) ? (DateTime?)null : DateTime.Parse(reader["Next_Credit_Check"].ToString()),
                        leadSource = reader["Lead_Source"].ToString(),
                        prepayment = bool.Parse(reader["Prepayment"].ToString()),
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
                        registeredAddress1 = reader["Registered_Address_1"].ToString(),
                        registeredAddress2 = reader["Registered_Address_2"].ToString(),
                        registeredCity = reader["Registered_City"].ToString(),
                        registeredCounty = reader["Registered_County"].ToString(),
                        registeredPostcode = reader["Registered_Postcode"].ToString()
                    };
                }
                conn.Close();
            }
            return q;
        }

        public static int UpsertAccount(Account account)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();

                SQLiteCommand command;
                if (account.accountID == 0)
                {
                    command = new SQLiteCommand("INSERT INTO Accounts " +
                                                "(Account_Name, Date_Modified, Description, Phone_1, Phone_2, Email, Status, Default_Carriage, Default_Nominal_Code, Registration_Number, Tax_Code, VAT_Number, Trading_Since, On_Hold, On_Hold_Reason, On_Hold_Date, Last_Credit_Check, Next_Credit_Check, Lead_Source, Prepayment, Billing_Address_1, Billing_Address_2, Billing_City, Billing_County, Billing_Country, Billing_Postcode, Shipping_Address_1, Shipping_Address_2, Shipping_City, Shipping_County, Shipping_Country, Shipping_Postcode, Registered_Address_1, Registered_Address_2, Registered_City, Registered_County, Registered_Postcode) " +
                                                "VALUES (@accountName, @dateModified, @description, @phone1, @phone2, @email, @status, @defaultCarriage, @defaultNominalCode, @registrationNumber, @taxCode, @VATNumber, @tradingSince, @onHold, @onHoldReason, @onHoldDate, @lastCreditCheck, @nextCreditCheck, @leadSource, @prepayment, @billingAddress1, @billingAddress1, @billingCity, @billingCounty, @billingCountry, @billingPostcode, @shippingAddress1, @shippingAddress2, @shippingCity, @shippingCounty, @shippingCountry, @shippingPostcode, @registeredAddress1, @registeredAddress2, @registeredCity, @registeredCounty, @registeredPostcode)", conn);
                }
                else
                {
                    command = new SQLiteCommand("UPDATE Accounts " +
                                                "SET Account_Name=@accountName, " +
                                                    "Account_Code=@accountCode, " + 
                                                    "Date_Modified=@dateModified, " +
                                                    "Description=@description, " +
                                                    "Phone_1=@phone1, " +
                                                    "Phone_2=@phone2, " +
                                                    "Email=@email, " +
                                                    "Status=@status, " +
                                                    "Default_Carriage=@defaultCarriage, " +
                                                    "Default_Nominal_Code=@defaultNominalCode, " +
                                                    "Registration_Number=@registrationNumber, " +
                                                    "Tax_Code=@taxCode, " +
                                                    "VAT_Number=@VATNumber, " +
                                                    "Trading_Since=@tradingSince, " +
                                                    "On_Hold=@onHold, " +
                                                    "On_Hold_Reason=@onHoldReason, " +
                                                    "On_Hold_Date=@onHoldDate, " +
                                                    "Last_Credit_Check=@lastCreditCheck, " +
                                                    "Next_Credit_Check=@nextCreditCheck, " +
                                                    "Lead_Source=@leadSource, " +
                                                    "Prepayment=@prepayment, " +
                                                    "Billing_Address_1=@billingAddress1, " +
                                                    "Billing_Address_2=@billingAddress1, " +
                                                    "Billing_City=@billingCity, " +
                                                    "Billing_County=@billingCounty, " +
                                                    "Billing_Country=@billingCountry, " +
                                                    "Billing_Postcode=@billingPostcode, " +
                                                    "Shipping_Address_1=@shippingAddress1, " +
                                                    "Shipping_Address_2=@shippingAddress2, " +
                                                    "Shipping_City=@shippingCity, " +
                                                    "Shipping_County=@shippingCounty, " +
                                                    "Shipping_Country=@shippingCountry, " +
                                                    "Shipping_Postcode=@shippingPostcode, " +
                                                    "Registered_Address_1=@registeredAddress1, " +
                                                    "Registered_Address_2=@registeredAddress2, " +
                                                    "Registered_City=@registeredCity, " +
                                                    "Registered_County=@registeredCounty " +
                                                "WHERE Account_ID = @accountID", conn);
                    command.Parameters.AddWithValue("@accountID", account.accountID);
                }

                command.Parameters.AddWithValue("@accountName", account.accountName);
                command.Parameters.AddWithValue("@accountCode", account.accountCode);
                command.Parameters.AddWithValue("@dateModified", DateTime.Now);
                command.Parameters.AddWithValue("@description", account.description);
                command.Parameters.AddWithValue("@phone1", account.phone1);
                command.Parameters.AddWithValue("@phone2", account.phone2);
                command.Parameters.AddWithValue("@email", account.email);
                command.Parameters.AddWithValue("@status", account.status);
                command.Parameters.AddWithValue("@defaultCarriage", account.defaultCarriage);
                command.Parameters.AddWithValue("@defaultNominalCode", account.defaultNominalCode);
                command.Parameters.AddWithValue("@registrationNumber", account.registrationNumber);
                command.Parameters.AddWithValue("@taxCode", account.taxCode);
                command.Parameters.AddWithValue("@VATNumber", account.VATNumber);
                command.Parameters.AddWithValue("@tradingSince", string.IsNullOrWhiteSpace(account.tradingSince.ToString()) ? null : account.tradingSince);
                command.Parameters.AddWithValue("@onHold", account.onHold);
                command.Parameters.AddWithValue("@onHoldReason", account.onHoldReason);
                command.Parameters.AddWithValue("@onHoldDate", string.IsNullOrWhiteSpace(account.onHoldDate.ToString()) ? null : account.onHoldDate);
                command.Parameters.AddWithValue("@lastCreditCheck", string.IsNullOrWhiteSpace(account.lastCreditCheck.ToString()) ? null : account.lastCreditCheck);
                command.Parameters.AddWithValue("@nextCreditCheck", string.IsNullOrWhiteSpace(account.nextCreditCheck.ToString()) ? null : account.nextCreditCheck);
                command.Parameters.AddWithValue("@leadSource", account.leadSource);
                command.Parameters.AddWithValue("@prepayment", account.prepayment);
                command.Parameters.AddWithValue("@billingAddress1", account.billingAddress1);
                command.Parameters.AddWithValue("@billingAddress2", account.billingAddress2);
                command.Parameters.AddWithValue("@billingCity", account.billingCity);
                command.Parameters.AddWithValue("@billingCounty", account.billingCounty);
                command.Parameters.AddWithValue("@billingCountry", account.billingCountry);
                command.Parameters.AddWithValue("@billingPostcode", account.billingPostcode);
                command.Parameters.AddWithValue("@shippingAddress1", account.shippingAddress1);
                command.Parameters.AddWithValue("@shippingAddress2", account.shippingAddress2);
                command.Parameters.AddWithValue("@shippingCity", account.shippingCity);
                command.Parameters.AddWithValue("@shippingCounty", account.shippingCounty);
                command.Parameters.AddWithValue("@shippingCountry", account.shippingCountry);
                command.Parameters.AddWithValue("@shippingPostcode", account.shippingPostcode);
                command.Parameters.AddWithValue("@shippingCity", account.shippingCity);
                command.Parameters.AddWithValue("@shippingCounty", account.shippingCounty);
                command.Parameters.AddWithValue("@shippingCounty", account.shippingCounty);
                command.Parameters.AddWithValue("@shippingCountry", account.shippingCountry);
                command.Parameters.AddWithValue("@registeredAddress1", account.registeredAddress1);
                command.Parameters.AddWithValue("@registeredAddress2", account.registeredAddress2);
                command.Parameters.AddWithValue("@registeredCity", account.registeredCity);
                command.Parameters.AddWithValue("@registeredCounty", account.registeredCounty);
                command.Parameters.AddWithValue("@registeredCountry", account.registeredCountry);
                command.Parameters.AddWithValue("@registeredPostcode", account.registeredPostcode);

                result = command.ExecuteNonQuery();
                conn.Close();
            }

            return result;
        }
        //accountID = int.Parse(reader["Account_ID"].ToString()),
        //accountName = reader["Account_Name"].ToString()
        //user = reader["User_Name"].ToString(),
        //accountCode = reader["Account_Code"].ToString(),
        //dateCreated = (DateTime)reader["Date_Created"],
        //dateModified = (DateTime)reader["Date_Modified"],
        //description = reader["Description"].ToString(),
        //phone1 = reader["Phone1"].ToString(),
        //phone2 = reader["Phone2"].ToString(),
        //email = reader["Email"].ToString(),
        //status = reader["Status"].ToString(),
        //defaultCarriage = reader["Default_Carriage"].ToString(),
        //defaultNominalCode = (int)reader["Default_Nominal_Code"],
        //registrationNumber = reader["Registration_Number"].ToString(),
        //taxCode = reader["Tax_Code"].ToString(),
        //VATNumber = reader["VAT_Number"].ToString(),
        //tradingSince = (DateTime)reader["Trading_Since"],
        //onHold = (bool)reader["On_Hold"],
        //onHoldReason = reader["On_Hold_Reason"].ToString(),
        //onHoldDate = (DateTime)reader["Date_Created"],
        //lastCreditCheck = (DateTime)reader["Last_Credit_Check"],
        //nextCreditCheck = (DateTime)reader["Next_Credit_Check"],
        //leadSource = reader["Lead_Source"].ToString(),
        //prepayment = (bool)reader["Prepayment"],
        //billingAddress1 = reader["Billing_Address_1"].ToString(),
        //billingAddress2 = reader["Billing_Address_2"].ToString(),
        //billingCity = reader["Billing_City"].ToString(),
        //billingCounty = reader["Billing_County"].ToString(),
        //billingCountry = reader["Billing_Country"].ToString(),
        //billingPostcode = reader["Billing_Postcode"].ToString(),
        //shippingAddress1 = reader["Shipping_Address_1"].ToString(),
        //shippingAddress2 = reader["Shipping_Address_2"].ToString(),
        //shippingCity = reader["Shipping_City"].ToString(),
        //shippingCounty = reader["Shipping_County"].ToString(),
        //shippingCountry = reader["Shipping_Country"].ToString(),
        //shippingPostcode = reader["Shipping_Postcode"].ToString(),
        //registeredAddress1 = reader["Registered_Address_1"].ToString(),
        //registeredAddress2 = reader["Registered_Address_2"].ToString(),
        //registeredCity = reader["Registered_City"].ToString(),
        //registeredCounty = reader["Registered_County"].ToString(),
        //registeredCountry = reader["Registered_Country"].ToString(),
        //registeredPostcode = reader["Registered_Postcode"].ToString()
    }
}
