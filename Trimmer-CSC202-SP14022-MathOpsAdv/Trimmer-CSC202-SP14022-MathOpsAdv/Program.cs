/*
 * Justin Trimmer
 * CSC202 - SP14022
 * Project 1 -  Math Ops.

    ** You must write a C# program that allows the user to input three 
    ** integer values. Your program will then determine and display the
    ** sum (add them up), average (add them up and divide by three), 
    ** product (multiply them together), and the smallest and largest 
    ** of the three integer values (find the smallest and largest by 
    ** using C#’s if statement). The output of your program should be 
    ** clear and easy to read.
*/


            


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimmer___CSC202_SP14022___Math_Ops
{
    class Program
    {
        // Set a max amount of entries the user can enter, that can be easily modified later.
        // If the user needs to manually enter more than 500 numbers, they need a shrink not a program.
        const int MAX_NUM_ENTRIES = 500;

        //Array of stings for creation of simple ordinal numbers
        static string[] ordSuffixList = new string[4] 
        {
            "st", "nd", "rd", "th"
        };

        static void Main(string[] args)
        {
            // Declare and use at least 3 integer variables.
            int sum = 0;
            int littleNum = 0;
            int bigNum = 0;
            int numEntries = 0;

            // Used long for the product, because of the growing possibility of going outside the constraints of int.
            // Product is inistialized to one to allow the use of a running product.
            long product = 1;

            // Declare and use at least 1 float variable.
            float avg = 0.0f;

            //Print Header for the first time, before anything else is printed.
            ClearAndPrintHeader();

            // Get the number of entries the user would like to make.
            numEntries = GetNumEntries();

            // Create an integer array to hold all user entered values.  This allows for easy expansion in the code.
            int[] userEnteredValues = new int[numEntries];

            
            // Get the users entries, and stor them in the array.
            for (int arrayIndex = 0; arrayIndex < numEntries; arrayIndex++)
            {
                userEnteredValues[arrayIndex] = FetchNumber(arrayIndex + 1);
            }

            // use a loop to determine a running sum and product.
            for (int arrayIndex = 0; arrayIndex < numEntries; arrayIndex++)
            {
                
                sum += userEnteredValues[arrayIndex];

                
                product *= userEnteredValues[arrayIndex];
            }

            // Determine the average.
            avg = sum / (float)numEntries;

            // Determine the smallest and largest value
            littleNum = userEnteredValues[0];
            bigNum = userEnteredValues[0];
            for (int arrayIndex = 1; arrayIndex < numEntries; arrayIndex++)
            {
                if (littleNum > userEnteredValues[arrayIndex])
                {
                    littleNum = userEnteredValues[arrayIndex];
                }

                if (bigNum < userEnteredValues[arrayIndex])
                {
                    bigNum = userEnteredValues[arrayIndex];
                }
            }

            
            Console.Write("You entered the numbers ");
            // print all values from the integer array to display all the values the user entered.
            for (int arrayIndex = 0; arrayIndex < numEntries; arrayIndex++)
            {
                if (arrayIndex < numEntries - 1)
                {
                    Console.Write("{0}, ", userEnteredValues[arrayIndex]);
                }
                else
                {
                    Console.Write("and {0}.\n", userEnteredValues[arrayIndex]);
                }
            }

            // Display the sum, average, product, smallest, and largest.
            Console.WriteLine("\n\nThe sum is\t\t{0}", sum);
            Console.WriteLine("The average is\t\t{0}", avg);
            Console.WriteLine("The product is\t\t{0}", product);
            Console.WriteLine("The smallest number is\t{0}", littleNum);
            Console.WriteLine("The largest number is\t{0}", bigNum);


            // Pause the consol so the user can read the output before it closes.
            Console.Write("\n\nPress any key to continue... ");
            Console.ReadKey(true);
        }


        static int FetchNumber(int usersCurNum)
        {
            // Method to get the integer input from the user

            string ordNum = CardinalToOrdinal(usersCurNum);
            int tempNum = 0;

            Console.Write("Enter the {0} integer: ", ordNum);
            // Error check the input, and if input is incorrect have the user re-enter.
            while (!int.TryParse(Console.ReadLine(), out tempNum))
            {
                ClearAndPrintHeader();
                Console.WriteLine("Please enter only an integer value.");
                Console.Write("Enter the {0} integer: ", ordNum);
            }

            ClearAndPrintHeader();
            return tempNum;
        }


        static int GetNumEntries()
        {
            // Method to get the number of entries the user would like to make.
            // The entry must be between three and the max currently allowed by the program ARRAY_SIZE.

            int tempNum = 0;
            Console.Write("Enter the number of numbers you would like to enter, between 3 and {0}. ", MAX_NUM_ENTRIES);
            while (tempNum < 3 || tempNum > MAX_NUM_ENTRIES)
            {
                // Error check the input, and if input is incorrect have the user re-enter.
                while (!int.TryParse(Console.ReadLine(), out tempNum))
                {
                    ClearAndPrintHeader();
                    Console.WriteLine("Please enter only an integer value.");
                    Console.Write("Enter the number of numbers you would like to enter, between 3 and {0}. ", MAX_NUM_ENTRIES);
                }

                // Verify the value the user entered is in the allowed Range.
                if (tempNum < 3 || tempNum > MAX_NUM_ENTRIES)
                {
                    ClearAndPrintHeader();
                    Console.WriteLine("Please enter a number in the correct range.");
                    Console.Write("Enter the number of numbers you would like to enter, between 3 and {0}. ", MAX_NUM_ENTRIES);
                }
            }
            ClearAndPrintHeader();
            return tempNum;
        }


        static string CardinalToOrdinal(int cardNum)
        {
            // Method to take a cardinal number input, and to output a simple ordinal version of that number.


            string numStr = cardNum.ToString();
            int numStrLen = numStr.Length;
            int lastTwoDigits = 0;

            // Only the last two digits of the number matter for this conversion.
            if (numStr.Length > 1)
            {
                lastTwoDigits = int.Parse(numStr[numStrLen - 2].ToString() + numStr[numStrLen - 1].ToString());
            }
            // If the number is only a single digit, attempting to get two digits will throw an error.
            else
            {
                lastTwoDigits = int.Parse(numStr[numStrLen - 1].ToString());
            }

            // Concatonate the proper ordinal suffix to the number.
            if (numStr.EndsWith("1") && lastTwoDigits != 11)
            {
                numStr += "st";
            }
            else if (numStr.EndsWith("2") && lastTwoDigits != 12)
            {
                numStr += "nd";
            }
            else if (numStr.EndsWith("3") && lastTwoDigits != 13)
            {
                numStr += "rd";
            }
            else
            {
                numStr += "th";
            }

            return numStr;
        }


        static void ClearAndPrintHeader()
        {
            // Method to clear the console, and print my personal header.  

            Console.Clear();

            // Print my Header.
            Console.WriteLine("\n{0}{0}", new string('#', 12));
            Console.WriteLine("##{0}{0}##", new string(' ', 10));
            Console.WriteLine("##{0}Justin Trimmer{0}##", new string(' ', 3));
            Console.WriteLine("##{0}CSC202{0}##", new String(' ', 7));
            Console.WriteLine("##{0}Math Ops{0}##", new string (' ', 6));
            Console.WriteLine("##{0}{0}##", new string(' ', 10));
            Console.WriteLine("{0}{0}\n\n", new string('#', 12));
        }
    }
}
