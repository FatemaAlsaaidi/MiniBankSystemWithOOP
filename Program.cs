namespace MiniBankSystemWithOOP
{
    internal class Program
    {
        // List for accounts object 
        static List<Accounts> accountsList = new List<Accounts>();
        // queue for account requests
        static Queue<Accounts> accountRequests = new Queue<Accounts>();



        // Constant admin information 
        static string AdminNationalID = "111";
        static string AdminPassword = "123";
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Mini Bank System");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // User Sign Up logic
                        Console.WriteLine("Sign Up selected.");
                        Console.Write("Enter your name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter your National ID: ");
                        string nationalID = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string password = Console.ReadLine();
                        Console.Write("Enter your phone number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter account type (e.g., Savings, Current): ");
                        string type = Console.ReadLine();
                        SignUp(name, nationalID, password, phoneNumber, type);
                        Console.WriteLine($"Request Account created successfully! Account Number: {Accounts.GetAccountNumber}");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter your National ID: ");
                        string id = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string pass = Console.ReadLine();

                        if (id == AdminNationalID && pass == AdminPassword)
                        {
                            Console.WriteLine("Welcome Admin!");
                            AdminMenuOperations();
                            Console.ReadLine();
                        }
                        else
                        {

                            SignIn(id, pass);
                        }
                        Console.ReadLine(); // Make user hold the screen 

                        break;
                    case "0": Console.WriteLine("Exiting the system..."); return;

                }

            } while (true);

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
                    if (response != "y" || response != "Y")
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
