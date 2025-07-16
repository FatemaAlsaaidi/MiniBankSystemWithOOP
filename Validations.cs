using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniBankSystemWithOOP
{
    class Validations
    {
        // =================== numeric validation with double value =================
        public static bool AmountValid(string amount)
        {
            // Define a regular expression pattern to match decimal numbers (e.g., 10.5)
            string pattern = @"^\d+\.\d+$";
            // Check if the input string is not null or empty
            if (!string.IsNullOrEmpty(amount))
            {
                // Check if the input string matches the decimal format defined by the regex
                if (Regex.IsMatch(amount, pattern))
                {
                    // Try converting the string to a double
                    if (double.TryParse(amount, out double result))
                    {
                        // Check if the parsed number is greater than zero
                        if (result > 0)
                        {
                            // Input is valid, print confirmation and return true
                            //Console.WriteLine("Valid input: " + result);
                            return true;

                        }
                        else
                        {
                            // Number is less than or equal to zero
                            Console.WriteLine("Amount must be greater than zero.");
                        }
                    }
                    else
                    {
                        // Parsing failed despite matching the regex (edge case)
                        Console.WriteLine("Invalid format. Please enter a valid number (e.g., 0.0)");
                    }
                }
                else
                {
                    // Input doesn't match the required decimal format
                    Console.WriteLine("Invalid format. Please enter a number with valid formate (0.0)");
                }
            }
            else
            {
                // Input is null or empty
                Console.WriteLine("Invalid null or empty value! Try again.");
            }
            // Return false if any validation step fails
            return false;
        }

        // ================== Validate Phone Number =================
        public static bool PhoneNumberValid(string phoneNumber)
        {
            // Define a regular expression pattern to match phone numbers
            string pattern = @"^\d{10}$"; // Example: 10 digits long
            // Check if the input string is not null or empty
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                // Check if the input string matches the phone number format defined by the regex
                if (Regex.IsMatch(phoneNumber, pattern))
                {
                    // Input is valid, print confirmation and return true
                    //Console.WriteLine("Valid phone number: " + phoneNumber);
                    return true;
                }
                else
                {
                    // Input doesn't match the required phone number format
                    Console.WriteLine("Invalid phone number format. Please enter a 10-digit number.");
                }
            }
            else
            {
                // Input is null or empty
                Console.WriteLine("Invalid null or empty value! Try again.");
            }
            // Return false if any validation step fails
            return false;
        }


        // ================== Validate National ID =================
        //NationalID validation formate
        public static bool IDValidation(string NationalID)
        {
            bool IsValid = true;
            // Check if the input is not null or empty
            if (!string.IsNullOrWhiteSpace(NationalID))
            {

                if (Regex.IsMatch(NationalID, @"^\d+$"))
                {
                    // Check if input is exactly 8 digits and only contains numbers
                    if (NationalID.Length == 8 && NationalID.All(char.IsDigit))
                    {
                        //Console.WriteLine("your National ID : " + NationalID);
                        IsValid = true;
                    }
                    else
                    {
                        IsValid = false;
                    }

                }
                else
                {
                    IsValid = false;
                }

            }
            else
            {
                IsValid = false;
            }

            return IsValid;
        }

        // Check the exist of user ID in the list
        public static bool CheckUserIDExist(string UserID)
        {

            //Loop through the list of registered National IDs
            for (int i = 0; i < AccountUserNationalID.Count; i++)
            {
                // Check if the current ID in the list matches the user's input
                if (AccountUserNationalID[i] == UserID)
                {
                    return true; // User ID exists in the list
                }
            }
            return false; // User ID does not exist in the list

            /////////////////////////// Use Linq in search////////////////
            //var user = AccountUserNationalID
            //    .Select((id, index) => new { Index = index, ID = id })
            //    .FirstOrDefault(x => x.ID == UserID);

            //if (user != null)
            //{
            //    //int index = user.Index;
            //    return true;
            //}

            //else
            //{
            //    return false; // User ID does not exist in the list
            //}
        }
    }
}
