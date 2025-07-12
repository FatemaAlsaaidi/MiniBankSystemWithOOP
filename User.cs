using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemWithOOP
{
    class User
    {
        
        // Fields with encapsulation
        public int AccountNumber { get; private set; }
        public string Name { get; private set; }
        public string NationalID { get; private set; }
        public double Balance { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public bool HasActiveLoan { get; private set; }
        public double LoanAmount { get; private set; }
        public double LoanInterestRate { get; private set; }

        // Static fields with the namw of Bank
        object BankName = "MiniBank";

        // Static field to keep track of the number of users
        private static int userCount = 0;

        // Static property to get the number of users
        public static int UserCount
        {
            get { return userCount; }
        }

        // Default Constructor
        public User()
        {
            AccountNumber = 0;
            Name = "Unknown";
            NationalID = "00000000000";
            Balance = 0.0;
            PhoneNumber = "000-000-0000";
            Address = "Unknown";
            HasActiveLoan = false;
            LoanAmount = 0;
            LoanInterestRate = 0;
        }

        // Parameterized Constructor
        public User(string name, string nationalID, double initialBalance, string phone, string address, object bankName)
        {
            // Increment user count when a new user is created
            userCount++;

            AccountNumber = userCount;
            Name = name;
            NationalID = nationalID;
            Balance = initialBalance;
            PhoneNumber = phone;
            Address = address;
            HasActiveLoan = false;
            LoanAmount = 0;
            LoanInterestRate = 0;
            BankName = bankName;
        }
    }
}
