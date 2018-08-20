using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using ERP.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ERP.Controllers
{
    internal static class AccountsController
    {
        private static string connString = string.Format("Data Source={0}", @"C:\users\Jasper\Desktop\test.sqlite");

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
                    q = new Account()
                    {
                        accountID = int.Parse(reader["Account_ID"].ToString()),
                        accountName = reader["Account_Name"].ToString(),
                        user = reader["User_Name"].ToString(),
                        accountCode = reader["Account_Code"].ToString(),
                        dateCreated = (DateTime)reader["Date_Created"],
                        dateModified = (DateTime)reader["Date_Modified"],
                        description = reader["Description"].ToString(),
                        phone1 = reader["Phone1"].ToString(),
                        phone2 = reader["Phone2"].ToString(),
                        email = reader["Email"].ToString(),
                        status = reader["Status"].ToString(),
                        defaultCarriage = reader["Default_Carriage"].ToString(),
                        defaultNominalCode = (int)reader["Default_Nominal_Code"],
                        registrationNumber = reader["Registration_Number"].ToString(),
                        taxCode = reader["Tax_Code"].ToString(),
                        VATNumber = reader["VAT_Number"].ToString(),
                        tradingSince = (DateTime)reader["Trading_Since"],
                        onHold = (bool)reader["On_Hold"],
                        onHoldReason = reader["On_Hold_Reason"].ToString(),
                        onHoldDate = (DateTime)reader["Date_Created"],
                        lastCreditCheck = (DateTime)reader["Last_Credit_Check"],
                        nextCreditCheck = (DateTime)reader["Next_Credit_Check"],
                        leadSource = reader["Lead_Source"].ToString(),
                        prepayment = (bool)reader["Prepayment"],
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
                        registeredCountry = reader["Registered_Country"].ToString(),
                        registeredPostcode = reader["Registered_Postcode"].ToString()
                    };
                }
            }
            return q;
        }

        public static int UpdateAccount(Account account)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();

                SQLiteCommand command;

                command = new SQLiteCommand("UPDATE Accounts " +
                                            "SET Account_ID=@accountID " +
                                                "Date_Modified=@dateModified" +
                                                "Description=@description" +
                                                "Phone1=@phone1" +
                                                "Phone2=@phone2" +
                                                "Email=@email" +
                                                "Status=@status" +
                                                "Default_Carriage=@defaultCarriage" +
                                                "Default_Nominal_Code=@defaultNominalCode" +
                                                "Registration_Number=@registrationNumber" +
                                                "Tax_Code=@taxCode" +
                                                "VAT_Number=@VATNumber" +
                                                "Trading_Since=@tradingSince" +
                                                "On_Hold=@onHold" +
                                                "On_Hold_Reason=@onHoldReason" +
                                                "Last_Credit_Check=@lastCreditCheck" +
                                                "Next_Credit_Check=@nextCreditCheck" +
                                                "Lead_Source=@leadSource" +
                                                "Prepayment=@prepayment" +
                                                "Billing_Address_1=@billingAddress1" +
                                                "Billing_Address_2=@billingAddress1" +
                                                "Billing_City=@billingCity" +
                                                "Billing_County=@billing_County" +
                                                "Billing_Country=@billingCountry" +
                                                "Billing_Postcode=@billingPostcode" +
                                                "Shipping_Address_1=@shippingAddress_1" +
                                                "Shipping_Address_2=@shippingAddress_2" +
                                                "Shipping_City=@shippingCity" +
                                                "Shipping_County=@shippingCounty" +
                                                "Shipping_Country=@shippingCountry" +
                                                "Shipping_Postcode=@shippingPostcode" +
                                                "Registered_Address_1=@registeredAddress_1" +
                                                "Registered_Address_2=@registeredAddress_2" +
                                                "Registered_City=@registeredCity" +
                                                "Registered_County=@registeredCounty" +
                                                "Registered_Country=@registeredCountry" +
                                                "Registered_Postcode=@registeredPostcode" +
                                            "WHERE Account_ID Like @accountID", conn);
                command.Parameters.AddWithValue("@accountID", account.accountID);
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
                command.Parameters.AddWithValue("@accountID", account.accountID);
                command.Parameters.AddWithValue("@accountID", account.accountID);
                command.Parameters.AddWithValue("@accountID", account.accountID);
                command.Parameters.AddWithValue("@accountID", account.accountID);
                command.Parameters.AddWithValue("@accountID", account.accountID);
                command.Parameters.AddWithValue("@accountID", account.accountID);
            }

            return 1;
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
