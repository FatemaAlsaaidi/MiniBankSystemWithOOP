namespace MiniBankSystemWithOOP
{
    internal class Program
    {
        // List for accounts object 
        List<Accounts> accountsList = new List<Accounts>();
        // queue for account requests
        Queue<Accounts> accountRequests = new Queue<Accounts>();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Mini Bank System");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Sign Up logic
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
                    break;
                case 2:
                    Console.WriteLine("Sign In selected.");
                    Console.ReadLine(); // Make user hold the screen 

                    break;
                case 0: Console.WriteLine("Exiting the system..."); break;

            }
            }

        public static void SignUp(string name, string nationalID, string password, string phoneNumber, string type)
        {
            Accounts newAccount = new Accounts(name, nationalID, password, phoneNumber, type);
            // add the new account to the accounts list

        }
    }
}
