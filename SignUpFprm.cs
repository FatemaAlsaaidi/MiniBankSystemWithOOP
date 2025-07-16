using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankSystemWithOOP
{
    class SignUpFprm
    {
        public static bool isValid = true; // Flag to check if every user input is valid

        // ================================= Enter User Name ===============================
        public static string EnterUserName()
        {
            try
            {
                string name = ""; // Initialize name variable
                do
                {
                    Console.Write("Enter your name: ");
                    name = Console.ReadLine();
                    //isValid = 

                    return name;
                } while (string.IsNullOrWhiteSpace(name)); // Ensure name is not null or whitespace
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your name: " + ex.Message);
                return string.Empty; // Return an empty string in case of an error
            }
        }

        // =============================== Enter User National ID =============================
     
        public static int EnterUserNationalID()
        {
            int tries = 0;
            int IndexId = -1;
            bool UserExist = false;
            string ID = "";
            // Step 1: Verify National ID
            do
            {
                // Prompt user to enter their National ID
                Console.WriteLine("Enter User National ID: ");
                ID = Console.ReadLine(); // Read user input from console                           
                // valid user exist
                UserExist = CheckUserIDExist(ID);
                if (UserExist == false) // or if(!UserExist)
                {
                    Console.WriteLine("User with this ID does not exist. Please try again.");
                    tries++;
                }



            } while (UserExist == false && tries < 3);
            if (tries == 3)
            {
                Console.WriteLine("You have exceeded the number of times you are allowed to enter a valid ID.");
                Console.ReadLine();
                return IndexId;
            }
            tries = 0;
            // Step 2: Find user ID index
            if (UserExist == true) // or if(UserExist)
            {
                //loop thriugh items in list
                for (int i = 0; i < AccountUserNationalID.Count; i++)
                {
                    //check if Input exist in the list 
                    if (AccountUserNationalID[i] == ID)
                    {
                        // Store the index of the user with the matching ID.
                        IndexId = i;
                        // Check if the account is locked
                        if (UserIsLocked[IndexId])
                        {
                            Console.WriteLine("This account is locked due to too many failed login attempts. Please contact the admin to unlock.");
                            return -1;
                        }

                    }
                }
            }
            return IndexId;
        }

        // ============================= Enter User Password ===============================
        public static int EnterUserPassword(int Index_ID)
        {
            int tries = 0;
            int Indexpassword = -1;
            bool UserExist = false;
            // Step 3: Validate Password
            bool passwordCorrect = false;

            do
            {
                Console.Write("Enter your password: ");
                string enteredPassword = ReadPassword(); // masked input
                string enteredHashed = HashPassword(enteredPassword);

                // Fetch the stored hashed password for this user
                bool PassExist = ExistPassword(enteredHashed);

                if (PassExist == true)
                {
                    passwordCorrect = true;

                }
                else
                {
                    Console.WriteLine("\nIncorrect password. Please try again.");
                    tries++;
                }

            } while (!passwordCorrect && tries < 3);

            if (tries == 3)
            {
                Console.WriteLine("You have exceeded the allowed attempts for password entry.");
                // Lock account after 3 failed attempts
                Accounts.accountsList[Index_ID].IsActivity = true; // access to properties
                Console.WriteLine("Account locked due to 3 failed login attempts. Please contact admin to unlock.");
                Indexpassword = -1; // login fails
            }

            if (passwordCorrect == true)
            {
                Indexpassword = Index_ID;
            }
            return Indexpassword;
        }
        // Read password from console without echoing characters
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        // Hash the password using SHA256
        static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // vlidate exist User password in the list
        static bool ExistPassword(string HashPassword)
        {
            // Loop through the list of registered password
            for (int i = 0; i < AccountUserHashedPasswords.Count; i++)
            {
                // Check if the current password in the list matches the user's input
                if (AccountUserHashedPasswords[i] == HashPassword)
                {
                    return true; // User password exists in the list
                }
            }
            return false; // User password does not exist in the list
        }

        // =========================== Enter User Phone Number ==============================
        public static string EnterUserPhoneNumber()
        {
            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            return phoneNumber;
        }

        // =========================== Enter User Account Type ==============================
        public static string EnterUserAccountType()
        {
            Console.Write("Enter account type:\n 1. Savings\n 2. Current ");
            string type = Console.ReadLine();
            if (type == "1")
            {
                type = "Savings";
            }
            else if (type == "2")
            {
                type = "Current";
            }
            else
            {
                Console.WriteLine("Invalid account type. Defaulting to Savings.");
                type = "Savings";
            }
            return type;
        }
        // =========================== Enter User Address ==============================
        public static string EnterUserAddress()
        {
            Console.Write("Enter your address: ");
            string address = Console.ReadLine();
            return address;
        }



    }
}
