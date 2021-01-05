using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker
{
    /// <summary>
    /// Includes error checking methods, used to verify strings and integers. Including: EnsureDigit, 
    /// EnsureEmptyLines, EnsureLength.
    /// </summary>
    class ErrorChecking
    {
        /// <summary>
        /// Ensures the string is a digit and not a letter or punctuation. If a non-digit is found, will prompt for new input.
        /// Ensure it is nine or less digits long
        /// </summary>
        /// <param name="input">takes any string as input</param>
        /// <returns>the input string that is verified to only contain a digit</returns>
        public static string EnsureDigit(string input) // ensures a string is a digit
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;
                
                foreach (char letter in input)
                {
                    if (char.IsPunctuation(letter) || char.IsLetter(letter))
                    {
                        keepGoing = true;
                    }
                    if (input.Length > 9)
                    {
                        keepGoing = true;
                    }
                }
                if (keepGoing == true)
                {
                    Console.WriteLine("Please try again and enter a digit only or a shorter number");
                    input = Console.ReadLine();
                }
            }
            return input;
        }
        
        /// <summary>
        /// Ensures blank input is not accepted, will prompt for input if input is blank
        /// </summary>
        /// <param name="input">accepts any string as input</param>
        /// <returns>returns the input string that is verifies as not being a blank line</returns>
        public static string EnsureEmptyLines(string input) // checks if string is empty
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;

                if (input == null || input == "" || input == " " || input == "  ")
                {
                    keepGoing = true;
                    Console.WriteLine("Please enter a value, try again");
                    input = Console.ReadLine();
                    input = input.ToUpper();
                }
            }
            return input;
        }

        /// <summary>
        /// Limits the input to 25 characters or under, if it is over 25 characters it will prompt for new input.
        /// </summary>
        /// <param name="input">accepts any string as input</param>
        /// <returns>the input string that is verified as being twenty-five characters or under.</returns>
        public static string EnsureLength(string input) // ensures a string does not exceed 25 characters
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = false;
                if (input.Length > 25)
                {
                    keepGoing = true;
                    Console.WriteLine("Please limit the length to under 25, please try again");
                    input = Console.ReadLine();
                    input = EnsureEmptyLines(input);
                    input = input.ToUpper();
                }
            }
            return input;
        }
    }
}
