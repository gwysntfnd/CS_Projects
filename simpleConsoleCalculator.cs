using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Operation
    {
        public static double DoOperation(double num1, double num2, string operation) {

            double result = double.NaN; //Not-a-number, The value of this constant is the result of dividing zero by zero.

            switch (operation)
            {
                //addition
                case "a":
                    result = num1 + num2;
                    break;
                //subraction
                case "b":
                    result = num1 - num2;
                    break;
                //multiplication
                case "c":
                    result = num1 * num2;
                    break;
                //division
                case "d":
                    // Enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option.
                default:
                    break;
            }
            return result;
        }
    
    }


    class Program
    {
        static void Main(string[] args)
        {
            menu();

        }


        //Main Menu
        static void menu() {
            Console.BackgroundColor
            = ConsoleColor.DarkMagenta;
            Console.ForegroundColor
            = ConsoleColor.Green;
            Console.Clear();


            String title = @" ▄████▄   ▄▄▄       ██▓     ▄████▄   ▒█████   ▒█████   ██▓    ▄▄▄     ▄▄▄█████▓ ▒█████   ██▀███  
▒██▀ ▀█  ▒████▄    ▓██▒    ▒██▀ ▀█  ▒██▒  ██▒▒██▒  ██▒▓██▒   ▒████▄   ▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒
▒▓█    ▄ ▒██  ▀█▄  ▒██░    ▒▓█    ▄ ▒██░  ██▒▒██░  ██▒▒██░   ▒██  ▀█▄ ▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒
▒▓▓▄ ▄██▒░██▄▄▄▄██ ▒██░    ▒▓▓▄ ▄██▒▒██   ██░▒██   ██░▒██░   ░██▄▄▄▄██░ ▓██▓ ░ ▒██   ██░▒██▀▀█▄  
▒ ▓███▀ ░ ▓█   ▓██▒░██████▒▒ ▓███▀ ░░ ████▓▒░░ ████▓▒░░██████▒▓█   ▓██▒ ▒██▒ ░ ░ ████▓▒░░██▓ ▒██▒
░ ░▒ ▒  ░ ▒▒   ▓▒█░░ ▒░▓  ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░▒░▒░ ░ ▒░▓  ░▒▒   ▓▒█░ ▒ ░░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░
  ░  ▒     ▒   ▒▒ ░░ ░ ▒  ░  ░  ▒     ░ ▒ ▒░   ░ ▒ ▒░ ░ ░ ▒  ░ ▒   ▒▒ ░   ░      ░ ▒ ▒░   ░▒ ░ ▒░
░          ░   ▒     ░ ░   ░        ░ ░ ░ ▒  ░ ░ ░ ▒    ░ ░    ░   ▒    ░      ░ ░ ░ ▒    ░░   ░ 
░ ░            ░  ░    ░  ░░ ░          ░ ░      ░ ░      ░  ░     ░  ░            ░ ░     ░     
░          Welcome to the coolest calculator console, What would you like to do?";
            Console.WriteLine(title);
            String[] options = { "> Press 'S' to Start", "> Press 'E' to Exit" };
            options.ToList().ForEach(Console.WriteLine);
            String userInput = Console.ReadLine();


                if (userInput.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    start();
                }
                else if (userInput.Equals("e", StringComparison.OrdinalIgnoreCase))
                {
                    exit();
                }
                else
                {
                    Console.WriteLine("Invalid Input, Try again later.");
                    Console.ReadKey();
                }
        }

        //Class for exit

        static void exit() 
        {

            Environment.Exit(0);

        }

        //Class for calculations

        static void start() {

            // Display title as the C# console calculator app.
            Console.WriteLine("-------------------------------\r");
            Console.WriteLine(" Welcome to Console Calcoolator\r");
            Console.WriteLine("-------------------------------\n");

            bool exit = false;
            while (!exit)
            {
                // Declare variables and set to empty.
                string num1 = "";
                string num2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("Enter the first number, and then press Enter: ");
                num1 = Console.ReadLine();

                //Disable string and other unnecessary inputs from user
                double cleanNum1 = 0;
                while (!double.TryParse(num1, out cleanNum1))
                {
                    Console.Write("Input Invalid. Please enter an integer value: ");
                    num1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Enter the second number, and then press Enter: ");
                num2 = Console.ReadLine();

                //Disable string and other unnecessary inputs from user
                double cleanNum2 = 0;
                while (!double.TryParse(num2, out cleanNum2))
                {
                    Console.Write("Invalid Input. Please enter an integer value: ");
                    num2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\tb - Subtract");
                Console.WriteLine("\tc - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Selected: ");

                string operation = Console.ReadLine();

                //Catch division error
                try
                {
                    result = Operation.DoOperation(cleanNum1, cleanNum2, operation);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("The result encountered a mathematical error.\n");
                    }
                    // max. two decimal places
                    else Console.WriteLine("The answer is : {0:0.##}\n", result);
                }
                catch (Exception DivideByZeroException)
                {
                    Console.WriteLine("Oh no! An exception occurred.\n - Details: " + DivideByZeroException.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Want to calculate again ? Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine().Equals("n", StringComparison.OrdinalIgnoreCase)) exit = true;

                Console.WriteLine("\n"); //linespacing.
            }
            return;

        }

    }
}

