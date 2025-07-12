namespace MiniBankSystemWithOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create objects of User Class
            User user1 = new User("Fatema", "123456789", 100.0 , "91234567", "Muscat");
            User user2 = new User("Ahmed", "1111111111", 200.0, "91234568", "Muscat");
            User user3 = new User("Sara", "2222222222", 300.0, "91234569", "Muscat");
            Console.WriteLine(user1.Name); // Display the name of user 1

            user1.Deposit(50.0); // Deposit money into user 1's account

        }
    }
}
