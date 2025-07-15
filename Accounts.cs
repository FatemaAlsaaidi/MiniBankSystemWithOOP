using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemWithOOP
{
    class Accounts
    {
        // List for accounts object 
        static List<Accounts> accountsList = new List<Accounts>();
        // queue for account requests
        static Queue<Accounts> accountRequests = new Queue<Accounts>();



        // Constant admin information 
        public static string AdminNationalID = "111";
        public static string AdminPassword = "123";


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
        public string Password { get { return password; }  set {password = value; } }
        
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public double Balance1 { get { return balance; } set { balance = value; } }
        public bool IsActivity1 { get { return isActivity; } set { isActivity = value; } }
        public string AccountNumber1 { get { return accountNumber; } set { accountNumber = value; } }
        public string Type1 { get { return type; } set { type = value; } }
        public string Address1 { get { return address; } set { address = value; } }

        // Defualt Constructor
        public Accounts()
        {
            name = "Unknown";
            nationalID = "0000000000";
            password = "password123";
            phoneNumber = "000-000-0000";
            balance = 0.0;
            isActivity = true;
            type = "xxxxx";
            AccountCounter++;
            accountNumber = GetAccountNumber;

        }
        // Constructor with parameters
        public Accounts(string name0, string nationalID0, string password0, string phoneNumber0, string type0)
        {
            name = name0;
            nationalID = nationalID0;
            password = password0;
            phoneNumber = phoneNumber0;
            balance = 0.0;
            isActivity = false;
            type = type0;
            AccountCounter++;
            accountNumber = GetAccountNumber;
        }

        public static string GetAccountNumber
        {
            get { return "ABC" + AccountCounter; } 
        }


        // Create Request for Create Account  done by user, if request account is approved by admin, it will be added to the accounts list and if not it will be removed from the queue
        public static void SignUp(string name, string nationalID, string password, string phoneNumber, string type)
        {
            Accounts newAccount = new Accounts(name, nationalID, password, phoneNumber, type);
            // add the request account the queue
            accountRequests.Enqueue(newAccount);

        }

        public static void SignIn(string UserID, string UserPassword)
        {
            // Logic for user sign in
            Accounts account = accountsList.FirstOrDefault(a => a.NationalID == UserID && a.Password == UserPassword);
            if (account != null)
            {
                Console.WriteLine($"Welcome back, {account.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid account number or password.");
            }
        }

        // ========================================================================================== Features for user ==========================================================================================



        // ========================================================================================== Features for admin ==========================================================================================

        public static void AdminMenuOperations()
        {
            bool InAdminMenu = true;
            // while loop to display the mnue ewhile the flag is true
            while (InAdminMenu)
            {
                // display All Admin Menu
                Console.Clear();
                Console.WriteLine("\n------ Admin Menu ------");
                Console.WriteLine("1. Process Account Requests");
                Console.WriteLine("2. View Submitted Reviews");
                Console.WriteLine("3. View All Accounts");
                Console.WriteLine("4. View Pending Account Requests");
                Console.WriteLine("5. Search User account by user National ID");
                Console.WriteLine("6. Show Total Bank Balance");
                Console.WriteLine("7. Delete Account");
                Console.WriteLine("8. Show Top 3 Richest Customers");
                Console.WriteLine("9. Export All Account Info to a New File (CSV or txt)");
                Console.WriteLine("10. Process Loan Requests");
                Console.WriteLine("11. Average Of FeedBack Rate");
                Console.WriteLine("12. View User Transaction");
                Console.WriteLine("13. View and Process Appointment Requests");
                Console.WriteLine("14. Unlock User Account");
                Console.WriteLine("0. Return to Main Menu");
                Console.Write("Select option: ");
                string adminChoice = Console.ReadLine().Trim(); // Read user input from console
                Console.WriteLine();

                // use switch to select one of many code blocks to be executed
                switch (adminChoice)
                {
                    // case to Process Next Account Request
                    case "1":
                        ProcessAccountRequests();
                        Console.ReadLine();
                        break;
                    // case to View Submitted Reviews
                    /*case "2":
                        ViewReviews();
                        Console.ReadLine();
                        break;
                    // case to View All Accounts
                    case "3":
                        ViewAllAccounts();
                        Console.ReadLine();
                        break;
                    // case to View Pending Account Requests
                    case "4":
                        ViewPendingRequests();
                        Console.ReadLine();
                        break;
                    // Search user by enter user National ID
                    case "5":
                        int UserIndexID = EnterUserID();
                        SearchUserByNationalID(UserIndexID);
                        Console.ReadLine();
                        break;
                    // Show Total Bank Balance
                    case "6":
                        ShowTotalBankBalance();
                        Console.ReadLine();
                        break;
                    // Delete Account
                    case "7":
                        int deleteIndexID = EnterNationalID();
                        if (deleteIndexID != -1)
                        {
                            DeleteAccount(deleteIndexID);
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please check your National ID.");
                        }
                        Console.ReadLine();
                        break;
                    case "8":
                        ShowTop3RichestCustomers();
                        Console.ReadLine();
                        break;
                    // Export All Account Info to a New File (CSV or txt)
                    case "9":
                        ExportAccountsToFile(ExportFilePath);
                        Console.WriteLine($"All account information has been exported to {ExportFilePath}");
                        Console.ReadLine();
                        break;
                    // case to Process Loan Requests
                    case "10":
                        ProcessLoanRequests();
                        Console.ReadLine();
                        break;

                    // case to Average Of Transaction Rate
                    case "11":
                        Console.WriteLine("Calculating average transaction rate...");
                        // Ask to enter the type of tansaction for which to calculate the average rate
                        Console.WriteLine("Enter the type of transaction:");
                        Console.WriteLine("1. Request Creation Account");
                        Console.WriteLine("2. Updated Phone");
                        Console.WriteLine("3. Updated Address");
                        Console.WriteLine("4. Deposit");
                        Console.WriteLine("5. Withdraw");
                        Console.WriteLine("6. Submit Review");
                        Console.WriteLine("7. Transfer");
                        Console.WriteLine("8. Generate Monthly Statement");
                        Console.WriteLine("9. Request Loan");
                        Console.WriteLine("10. View Last Transactions");
                        Console.WriteLine("11. View Transactions After Date");
                        Console.WriteLine("0. Return to Admin Menu");

                        string transactionTypeChoice = Console.ReadLine();
                        string transactionType = "";
                        double averageRate = 0.0; // Initialize average rate variable
                        switch (transactionTypeChoice)

                        {
                            case "1":
                                transactionType = "Request Creation Account";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "2":
                                transactionType = "Updated Phone";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "3":
                                transactionType = "Updated Address";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "4":
                                transactionType = "Deposit";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "5":
                                transactionType = "Withdraw";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "6":
                                transactionType = "Submit Review";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "7":
                                transactionType = "Transfer";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "8":
                                transactionType = "Generate Monthly Statement";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "9":
                                transactionType = "Request Loan";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "10":
                                transactionType = "View Last Transactions";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            case "11":
                                transactionType = "View Transactions After Date";

                                // Call the function to calculate the average transaction rate
                                averageRate = CalculateAverageFeedback(transactionType);
                                Console.WriteLine($"The average transaction rate is: {averageRate}");
                                Console.ReadLine();

                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                continue; // Skip to the next iteration of the loop
                        }
                        break;

                    // case to View User Transaction
                    case "12":
                        // Ask the admin to enter the user National ID
                        int userIndexID = EnterUserID();
                        if (userIndexID != -1)
                        {
                            PrintAllTransactions(userIndexID);
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please check your National ID.");
                        }
                        Console.ReadLine();
                        break;
                    // case to View and Process Appointment Requests
                    case "13":
                        ProcessRequestAppointments();
                        Console.ReadLine();
                        break;

                    // case to Unlock User Account
                    case "14":
                        UnlockUserAccount();
                        Console.ReadLine();
                        break;
                    // case to Return to Main Menu
                    */
                    case "0":
                        InAdminMenu = false; // this will exit the loop and return
                        break;
                    // default case to display message to the admin if selected the wronge number
                    default:
                        Console.WriteLine("Wronge choice number, Try Agine!");
                        Console.ReadKey();
                        break;

                }
            }

        }
        // Process all account requests in the queue done by user , request account is approved by admin, it will be added to the accounts list and if not it will be removed from the queue

        public static void ProcessAccountRequests()
        {
            try
            {
                // check if there is request
                if (accountRequests.Count == 0)
                {
                    Console.WriteLine("No pending account requests.");
                    return;
                }
                while (accountRequests.Count > 0)
                {
                    Accounts account = accountRequests.Dequeue();
                    Console.WriteLine($"Processing account request for {account.Name} with National ID {account.NationalID}...");
                    Console.Write("Approve this account? (y/n): ");
                    string response = Console.ReadLine().ToLower();
                    if (response == "n" || response == "N")
                    {
                        Console.WriteLine($"Account request for {account.Name} has been rejected.");
                        continue; // Skip to the next request
                    }
                    // If approved, add the account to the accounts list
                    else
                    {
                        account.IsActivity1 = true; // Set the account as active
                        accountsList.Add(account);
                        Console.WriteLine($"Account for {account.Name} with Account Number {account.AccountNumber1} has been created.");

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing account requests: {ex.Message}");
            }
        }


    }
}
