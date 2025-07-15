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

        // Minimum Balance for accounts
        public static double MinimumBalance = 100.00;

        // Constant admin information 
        public static string AdminNationalID = "111";
        public static string AdminPassword = "123";

        // Fixed Currency Exchange Rates
        static readonly Dictionary<string, double> ExchangeRates = new Dictionary<string, double>
        {
            {"USD", 3.8},
            {"EUR", 4.1},
            {"OMR", 1.0},
            {"UAE", 10.0}
        };



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
                foreach (Accounts acc in accountsList)
                {
                    if (acc.NationalID == UserID && acc.Password == UserPassword)
                    {
                        Console.WriteLine($"Welcome {acc.Name}!");
                        // Call the user menu operations method with the index of the account
                        UserMenuOperations(accountsList.IndexOf(acc));
                        return; // Exit after successful sign in
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid account number or password.");
            }
        }

        // ========================================================================================== Features for user ==========================================================================================

        public static void UserMenuOperations(int IndexID)
        {
            bool inUserMenu = true;
            // while loop to display the mnue ewhile the flag is true 
            while (inUserMenu)
            {
                Console.Clear();
                Console.WriteLine("\n------ User Menu Operation ------");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. Submit Review/Complaint");
                Console.WriteLine("5. Transfer Money");
                Console.WriteLine("6. Undo Last Complaint");
                Console.WriteLine("7. Update Phone Number and Address");
                Console.WriteLine("8. View Transaction");
                Console.WriteLine("9. Request a Loan");
                Console.WriteLine("10. View Active Loan Information");
                Console.WriteLine("11. Book Appointment For Book Service");
                Console.WriteLine("0. Return to Main Menu");
                Console.Write("Select option: ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    // case to Deposit
                    case "1":

                        Console.WriteLine("Proceeding to deposit...");
                        Deposit(IndexID); // If user exists, proceed with deposit
                        Console.ReadLine(); // Wait for user input before continuing

                        break;
                    // case to Withdraw
                    case "2":

                        Console.WriteLine("Proceeding to withdraw...");
                        withdraw(IndexID); // If user exists, proceed with withdraw
                        Console.ReadLine(); // Wait for user input before continuing

                        break;
                    // case to View Balance
                    case "3":

                        Console.WriteLine("Proceeding to Check Balance...");
                        CheckBalance(IndexID); // If user exists, proceed with chech balance
                        Console.ReadLine(); // Wait for user input before continuing

                        break;
                    // case to Submit Review/Complaint
                    /*case "4":
                        SubmitReview();
                        Console.ReadLine();
                        break;
                    // Transfer Money
                    case "5":
                        // Ask user to enter the National ID of the account to transfer money to
                        Console.WriteLine("Enter the National ID of the account you want to transfer money to.....");
                        int UserIndexID2 = EnterUserID();
                        if (UserIndexID2 != -1 && UserIndexID2 != IndexID) // when user login to its account by accountID number, this number save in value IndexID which decalre in "internal calss program" so when want to transer from its account to another account, no need to enter its accountIDNumber agine it save temberary in variable "IndexID"
                        {
                            Transfer(IndexID, UserIndexID2); // If user exists, proceed with transfer
                        }
                        else if (UserIndexID2 == IndexID)
                        {
                            Console.WriteLine("You cannot transfer money to your own account.");
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please check the National ID of the recipient.");
                        }
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                    // Undo Last Complaint
                    case "6":
                        UndoLastComplaint();
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                    // case to Update Phone Number and Address
                    case "7":
                        UpdatePhoneAndAddress(IndexID); // If user exists, proceed with update
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                    // case to View Transaction History
                    case "8":
                        Console.WriteLine("Which option do you want to view transaction: ");
                        Console.WriteLine("1. Display All Your Transaction");
                        Console.WriteLine("2. Display Transaction For Specific Manth on a Specific Year");
                        Console.WriteLine("3. View Last N Transactions");
                        Console.WriteLine("4. View Transactions After a Date");
                        Console.WriteLine("0. Return to User Menu");
                        Console.Write("Select option: ");
                        string choice = Console.ReadLine();
                        Console.WriteLine();

                        // Use switch to select one of many code blocks to be executed
                        switch (choice)
                        {
                            // case to Display All Your Transaction
                            case "1":
                                PrintAllTransactions(IndexID);
                                break;
                            // case to Display Transaction For Specific Manth on a Specific Year
                            case "2":
                                GenerateMonthlyStatement(IndexID);
                                break;
                            // case to View Last N Transactions
                            case "3":
                                ViewLastNTransactions(IndexID);
                                Console.ReadLine();
                                break;
                            // case to View Transactions After a Date
                            case "4":
                                ViewTransactionsAfterDate(IndexID);
                                Console.ReadLine();
                                break;
                            case "0":
                                // Return to User Menu
                                inUserMenu = true; // this will exit the loop and return
                                break;
                            // default case if user choice the wronge number within the range of cases 
                            default:
                                Console.WriteLine("Wronge Choice number, Try Agine!");
                                break;
                        }
                        Console.ReadLine();
                        break;
                    // case to Request a Loan
                    case "9":
                        RequestLoan(IndexID);
                        Console.ReadLine();
                        break;
                    // case to View Active Loan Information
                    case "10":
                        ViewActiveLoanInfo(IndexID);
                        Console.ReadLine();
                        break;
                    // case to Book Appointment For Book Service
                    case "11":
                        RequestBookAppointment(IndexID);
                        Console.ReadLine();
                        break;

                    // case to exist from user menu and Return to Main Menu 
                    */
                    case "0":
                        inUserMenu = false; // this will exit the loop and return
                        break;
                    // default case if user choice the wronge number within the range of cases 
                    default:
                        Console.WriteLine("Wronge Choice number, Try Agine!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Deposit Function 
        public static void Deposit(int IndexID)
        {
            //if (IndexID < 0 || IndexID >= UserBalances.Count)
            //{
            //    Console.WriteLine("Error: Invalid user index for deposit operation.");
            //    return;
            //}

            int tries = 0;
            // Initialize a boolean flag to control the deposit loop.
            bool IsDeposit = false;
            // Initialize a variable to store the final parsed deposit amount.
            double FinalDepositAmount = 0.0;
            // Initialize an index to find the user's position in the account list.

            // Start a try block to catch potential runtime exceptions.
            try
            {
                // Repeat until a valid deposit is made.
                do
                {
                    Console.WriteLine("Select deposit currency: \n1. OMR\n2. USD\n3. EUR\n4. UAE");
                    string choice = Console.ReadLine();
                    string currency = choice == "1" ? "OMR" : choice == "2" ? "USD" : choice == "3" ? "EUR" : choice == "4" ? "UAE" : "";

                    if (string.IsNullOrEmpty(currency))
                    {
                        Console.WriteLine("Invalid selection.");
                        return;
                    }

                    Console.WriteLine($"Enter the amount to deposit in {currency}: ");
                    if (!double.TryParse(Console.ReadLine(), out double originalAmount) || originalAmount <= 0)
                    {
                        Console.WriteLine("Invalid deposit amount.");
                        return;
                    }
                    // convert double to string 
                    string DepositAmount = originalAmount.ToString("F2"); // Format to 2 decimal places

                    // Validate the entered amount using a custom method.
                    bool ValidDepositAmount = Validations.AmountValid(DepositAmount);
                    if (ValidDepositAmount == false)
                    {
                        // Display error if the input is not valid.
                        Console.WriteLine("Invalid deposit Amount Format, should be  00.00");
                        IsDeposit = false;
                        tries++;
                    }
                    // If input is valid, find the user index.
                    else
                    {
                        // convert string to double using TryParse
                        double.TryParse(DepositAmount, out FinalDepositAmount);

                        // Convert to OMR
                        double rate = ExchangeRates[currency];
                        double convertedAmount = FinalDepositAmount / rate;

                        Console.WriteLine($"Converted Amount from {currency} : {FinalDepositAmount} to OMR: {convertedAmount:F2}");

                        // Update the user's balance by adding the deposit amount.
                        accountsList[IndexID].balance = accountsList[IndexID].balance + convertedAmount;

                        // Display success message and the new balance.
                        Console.WriteLine($"Successfully deposited {convertedAmount} {currency} to your account.");
                        PrintReceipt(transactionType: "Deposit", amount: convertedAmount, balance: accountsList[IndexID].balance);
                        // Set the flag to true to exit the loop.
                        IsDeposit = true;

                        // Record the transaction in the user's transaction history.
                        //string transactionRecord = $"{AccountUserNationalID[IndexID]},{DateTime.Now:yyyy-MM-dd},Deposit, {FinalDepositAmount},{convertedAmount},{UserBalances[IndexID]}";
                        //for (int i = UserTransactions.Count; i < UserBalances.Count; i++)
                        //{
                        //    UserTransactions.Add(new List<string>());
                        //}

                        //UserTransactions[IndexID].Add(transactionRecord);
                        //// Save the user's transactions to a file.
                        //SaveUserTransactionsToFile();
                        //UserFeedbackSystem("Deposit");
                        // Exit the method (if inside a method).
                        return;

                    }
                    if (tries == 3)
                    {
                        Console.WriteLine("You have exceeded the number of times you are allowed to enter a valid value.");
                        return;
                    }
                } while (IsDeposit == false && tries < 3);
            }
            //Print any exception message that occurs during execution.
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
        // Withdraw Function 
        public static void withdraw(int IndexID)
        {
            int tries = 0;
            // Initialize a boolean flag to control the deposit loop.
            bool IsWithdraw = false;
            // Initialize a variable to store the final parsed deposit amount.
            double FinalwithdrawAmount = 0.0;
            // declare variable print balance after any process
            double BalanceAfterProcess = 0.0;
            // Start a try block to catch potential runtime exceptions.
            try
            {
                // Repeat until a valid deposit is made.
                do
                {

                    Console.WriteLine("Enter the amount of money you want to withdrw from your balance: ");
                    string WithdrawAmount = Console.ReadLine();
                    // Validate the entered amount using a custom method.
                    bool ValidWithAmount = Validations.AmountValid(WithdrawAmount);
                    if (ValidWithAmount == false)
                    {
                        // Display error if the input is not valid.
                        Console.WriteLine("Invalid input");
                        IsWithdraw = false;
                        tries++;
                    }
                    // If input is valid, find the user index.
                    else
                    {

                        // convert string to double using TryParse
                        double.TryParse(WithdrawAmount, out FinalwithdrawAmount);
                        // check if user balamce is less than or equal MinimumBalance
                        bool checkBalance = CheckBalanceAmount(FinalwithdrawAmount, IndexID);
                        if (checkBalance == true)
                        {

                            // Update the user's balance by adding the deposit amount.
                            accountsList[IndexID].balance = accountsList[IndexID].balance - FinalwithdrawAmount;
                            Console.WriteLine($"Successfully withdraw");
                            Console.WriteLine($"Your Current Balance is {accountsList[IndexID].balance}");
                            // Record the transaction in the user's transaction history.
                            PrintReceipt(transactionType: "Withdraw", amount: FinalwithdrawAmount, balance: accountsList[IndexID].balance);
                            // Record the transaction in the user's transaction history.
                            //string transactionRecord = $"{DateTime.Now:yyyy-MM-dd},Withdraw,{FinalwithdrawAmount},{UserBalances[IndexID]}";
                            //for (int i = UserTransactions.Count; i < UserBalances.Count; i++)
                            //{
                            //    UserTransactions.Add(new List<string>());
                            //}

                            //UserTransactions[IndexID].Add(transactionRecord);
                            //// Save the user's transactions to a file.
                            //SaveUserTransactionsToFile();
                            //UserFeedbackSystem("Withdraw");
                            // Set the flag to true to exit the loop.
                            IsWithdraw = true;
                        }
                        else
                        {
                            BalanceAfterProcess = accountsList[IndexID].balance - FinalwithdrawAmount;
                            Console.WriteLine($"Can not withdraw {FinalwithdrawAmount} from your balance, becouse your balance after with draw is {BalanceAfterProcess} which less than 100.00");
                        }
                        return;

                    }
                    if (tries == 3)
                    {
                        Console.WriteLine("You have exceeded the number of times you are allowed to enter a valid value.");
                        return;
                    }
                } while (IsWithdraw == false && tries < 3);
            }
            //Print any exception message that occurs during execution.
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        // Check Balance Function
        public static void CheckBalance(int IndexID)
        {
            Console.WriteLine($"Your Current Balance is {accountsList[IndexID].balance}");
        }

        // Print Receipt After Deposit/Withdraw 
        public static void PrintReceipt(string transactionType, double amount, double balance)
        {
            Console.WriteLine("\n--- Transaction Receipt ---");
            Console.WriteLine($"Transaction Type: {transactionType}");
            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"New Balance: {balance}");
            Console.WriteLine("---------------------------\n");
        }

        //************************************ check balance amount to decided if we can withdraw or not *********************************
        public static bool CheckBalanceAmount(double FinalAmount, int indexID)
        {
            // flag 
            bool GoWithProcess = false;
            // check if balance has more than Minimum Balance 
            if ((accountsList[indexID].balance > MinimumBalance) && (FinalAmount <= (accountsList[indexID].balance - MinimumBalance)))
            {
                // put flag as true if user can go with process 
                GoWithProcess = true;
            }
            else
            {
                // put flag as flase if user can not go with process becoouse its balance has just 100.00$
                GoWithProcess = false;
            }

            return GoWithProcess;
        }

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
