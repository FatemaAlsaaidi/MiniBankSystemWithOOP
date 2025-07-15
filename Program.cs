namespace MiniBankSystemWithOOP
{
    internal class Program
    {
        
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
                        Accounts.SignUp(name, nationalID, password, phoneNumber, type);
                        Console.WriteLine($"Request Account created successfully!");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter your National ID: ");
                        string id = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string pass = Console.ReadLine();

                        if (id == Accounts.AdminNationalID && pass == Accounts.AdminPassword)
                        {
                            Console.WriteLine("Welcome Admin!");
                            Accounts.AdminMenuOperations();
                            Console.ReadLine();
                        }
                        else
                        {

                            Accounts.SignIn(id, pass);
                        }
                        Console.ReadLine(); // Make user hold the screen 

                        break;
                    case "0": Console.WriteLine("Exiting the system..."); return;

                }

            } while (true);

        }

      
    }
}
