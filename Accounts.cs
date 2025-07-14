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
        public static string AccountNumber ;
        private static int AccountCounter=0;
        public string Name { get; set;}
        private string NationalID;
        private string Password;
        public string PhoneNumber;
        private double Balance;
        public bool IsActivity;
        public string Type;
        public string Address;

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
