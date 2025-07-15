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
                            ProcessAccountRequests();
                            Console.WriteLine("All account requests have been processed.");
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
        
        // Create Request for Create Account  
        public static void SignUp(string name, string nationalID, string password, string phoneNumber, string type)
        {
            Accounts newAccount = new Accounts(name, nationalID, password, phoneNumber, type);
            // add the request account the queue
            accountRequests.Enqueue(newAccount);

        }

        public static void SignIn(string UserID, string password)
        {
            // Logic for user sign in
            Accounts account = accountsList.FirstOrDefault(a => a.NationalID == UserID && a.Password == password);
            if (account != null)
            {
                Console.WriteLine($"Welcome back, {account.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid account number or password.");
            }
        }

        // Process all account requests in the queue done by user 
        public static void ProcessAccountRequests()
        {
            while (accountRequests.Count > 0)
            {
                Accounts account = accountRequests.Dequeue();
                accountsList.Add(account);
                Console.WriteLine($"Account for {account.Name} with Account Number {account.AccountNumber1} has been created.");
            }
        }
    }
}
