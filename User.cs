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
        string BankName = "MiniBank";

        // Static field to keep track of the number of users
        private static int userCount = 0;

        // Static property to get the number of users
        public static int UserCount
        {
            get { return userCount; }
        }

        // Static constructor to To welcome the user upon entering the site
        static User()
        {
            Console.WriteLine("Welcome to MiniBank! We are glad to have you here.");
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
        public User(string name, string nationalID, double initialBalance, string phone, string address, string bankName = "MiniBank")
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

        // Method to deposit money
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount:C} to account {AccountNumber}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        // Method to withdraw money
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C} from account {AccountNumber}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be positive and less than or equal to the current balance.");
            }
        }

        // Update phone
        public void UpdatePhone(string newPhone)
        {
            if (!string.IsNullOrEmpty(newPhone))
            {
                PhoneNumber = newPhone;
                Console.WriteLine($"Phone number updated to {PhoneNumber} for account {AccountNumber}.");
            }
            else
            {
                Console.WriteLine("Invalid phone number.");
            }
        }

        // Update address
        public void UpdateAddress(string newAddress)
        {
            if (!string.IsNullOrEmpty(newAddress))
            {
                Address = newAddress;
                Console.WriteLine($"Address updated to {Address} for account {AccountNumber}.");
            }
            else
            {
                Console.WriteLine("Invalid address.");
            }
        }

        // Request Loan
        public void RequestLoan(double amount)
        {
            Console.WriteLine($"Succesfully submit your loan request");
        }

    }
}
