using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is where the application prompts you for the 2 numbers you will be working with. Uses a method that is broken down further down called GetValue.
            double value1 = GetValue("Enter your first value: ");
            double value2 = GetValue("Enter your second value: ");

            // This is the variable that stores the answer we calculate
            double result = 0;

            // This is how we decide which operation to perform. Give the option of selecting a letter. Research more into ConsoleKeyInfo Class.
            while (true)
            {
                // Here we have the options for our Operators.
                Console.Write("(A)dd (S)ubtract (M)ultiple (D)ivide: ");
                
                // The ConsoleKeyInfo class reads a single character and converts it into a string.
                ConsoleKeyInfo info = Console.ReadKey();
                string operation = info.Key.ToString();


                //Make it uppercase just in case the user doesnt enter it that way. If none of the right letters are picked, run the default class.
                switch (operation.ToUpper())
                {
                    case "A":
                        result = Add(value1, value2);
                        break;
                    case "S":
                        result = Subtract(value1, value2);
                        break;
                    case "M":
                        result = Multiply(value1, value2);
                        break;
                    case "D":
                        result = Divide(value1, value2);
                        break;
                    default:
                        Console.WriteLine("Choose from supported operations");
                        continue;
                }

                // How we populate what the actual answer is and a break to end the program
                Console.WriteLine("\nResult: " + result);
                Console.Read();
                break;
            }
        }

            //The Method for GetValue
            private static double GetValue(string label)
            {
                double value;
                
                //This is where we parse what the user entered into value1 and value2. If they did not enter a number, the else clause lets us know what the error is.
                while(true)
                {
                    Console.Write(label);
                    string input = Console.ReadLine();
                    if (Double.TryParse(input, out value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Value can't be parsed as a number");
                    }
                }
            }
            
            //How we process each operator. By making methods of each of the separate math operators, we can use them easier in our code above.
            private static double Add(double value1, double value2)
            {
                return value1 + value2;
            }
            private static double Subtract(double value1, double value2)
            {
                return value1 - value2;
            }
            private static double Multiply(double value1, double value2)
            {
                return value1 * value2;
            }
            // This one is a bit different to add the error handling needed for dividing by Zero. If either value is 0, return 0, if not, return the value. 
            private static double Divide(double value1, double value2)
            {
                if (value1 == 0 || value2 == 0)
                {
                    return 0;
                }
                else
                {
                    return value1 / value2;
                }
            }
        }
    }
