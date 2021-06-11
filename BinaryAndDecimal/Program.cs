/* Binary - Decimal Converter
 * Adrian Sanchez Rodriguez - EC1939656 
 */

using System;

namespace BinaryAndDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            Console.WriteLine(" Welcome to the Decimal - Binary Converter");

            while( answer != "n")
            {
                //We ask the user to choose the operation
                Console.WriteLine("Which operation would you like to perform?\n 1 - Decimal to Binary\n 2 - Binary To Decimal\n");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":

                        //We ask the user for the decimal number and store it in a variable
                        Console.WriteLine("Enter the decimal number you want to convert to binary: ");
                        long decimalInput = Convert.ToInt64(Console.ReadLine());

                        // Convert the decimal number to binary
                        DecimalToBinary(decimalInput);

                        //Asks for further operations
                        Console.WriteLine("Would you like to perform another operation? (y/n)");
                        answer = Console.ReadLine().ToLower();
                        Console.Clear();
                        break;

                    case "2":

                        //We ask the user for the binary number and store it in a variable
                        Console.WriteLine("Enter the binary number you want to conver to decimal: ");
                        string binaryNumber = Console.ReadLine();

                        //Convert the binary number to decimal
                        BinaryToDecimal(binaryNumber);

                        //Ask for further operations
                        Console.WriteLine("Would you like to perform another operation? (y/n)");
                        answer = Console.ReadLine().ToLower();
                        Console.Clear();
                        break;
                    default:

                        //Exception for choosing an option different than 1 or 2
                        Console.WriteLine("Wrong option, please try again");
                        break;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        //This method converts the decimal number we got from the user to binary
        public static void DecimalToBinary(long userInput)
        {
            //Store user input in a temp variable to not mess the output later
            long tempUserInput = userInput;

            //Create a variable to store the binary number we are going to be calculating
            //String is good, since we don't need any value in the integer, to swap the number later.
             
            string binaryNumber = "";

            //While the userInput is higher than 0, we are going to run this loop
            while (tempUserInput > 0)
            {
                //Check the remainder of the number divided by two
                long remainder = tempUserInput % 2;

                //Depending on whether the remainder is 0 or 1, we add that to binaryNumber
                if (remainder == 0)
                {
                    binaryNumber += "0";
                }
                else
                {
                    binaryNumber += "1";
                }
                //Divide the user input by two and store it again in the temp variable
                tempUserInput /= 2;
            }

            //Reverse the binary number, since the addition was done from left to right, the number would be wrong if we don't do this
            binaryNumber = ReverseString(binaryNumber);

            //Display the number introduced by the user and its binary value
            Console.WriteLine(userInput + " to binary is " + binaryNumber);
        }

        //This method converts the binary number we got from the user to decimal
        public static void BinaryToDecimal(string userInput)
        {
            //Create an array of character and store the user input
            char[] array = userInput.ToCharArray();
            //Reverse the positions in the array to multiply in correct order in the future
            Array.Reverse(array);

            //Store the value of the binary number
            int sum = 0;

            //we go through each position of the array 
            //multiplying the number by 2 raised to the power of the number stored in the index
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                   
                    if (i == 0)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }

            }
            //Output the binary number the user introduced and its decimal value
            Console.WriteLine(userInput + " to decimal is " + sum);

        }
        
        //This method takes the string created from the decimal number and reverses it, so the output its correct
        public static string ReverseString(string s)
        {
            //Store each character of the binary string in an array
            char[] array = s.ToCharArray();
            Array.Reverse(array);

            //Return the string back to the method
            return new string(array);
        }
    }
    
}
