using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemWithOOP
{
    class Accounts
    {
        // Properties for account details
        private static string accountNumber ;
        private static int AccountCounter=0;
        private string name;
        private string nationalID;
        private string password;
        private string phoneNumber;
        private double balance;
        private bool isActivity;
        private string type;
        private string address;

        // Properties for account details
        public string Name { get { return name; } set { name = value; } }
        public string NationalID { get { return nationalID; } set { nationalID = value; } }
        public string Password { set {password = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public double Balance1 { get { return balance; } set { balance = value; } }
        public bool IsActivity1 { get { return isActivity; } set { isActivity = value; } }
        public string AccountNumber1 { get { return accountNumber; } set { accountNumber = value; } }
        public string Type1 { get { return type; } set { type = value; } }
        public string Address1 { get { return address; } set { address = value; } }

        // Defualt Constructor
        public Accounts()
        {
            Name = "Unknown";
            NationalID = "0000000000";
            Password = "password123";
            PhoneNumber = "000-000-0000";
            Balance = 0.0;
            IsActivity = true;
            AccountCounter++;
            AccountNumber = GetAccountNumber;

        }
        // Constructor with parameters
        public Accounts(string name, string nationalID, string password, string phoneNumber)
        {
            Name = name;
            NationalID = nationalID;
            Password = password;
            PhoneNumber = phoneNumber;
            Balance = 0.0;
            IsActivity = true;
            AccountCounter++;
            AccountNumber = GetAccountNumber;
        }

        public static string GetAccountNumber
        {
            get { return "ABC" + AccountCounter; } 
        }





    }
}
