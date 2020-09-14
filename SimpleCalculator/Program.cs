using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to begin");

            String restart = Console.ReadLine();

            do
            {
                try
                {
                    //Class to convert user input
                    InputConverter inputConverter = new InputConverter();

                    //Class to perform actual calculations
                    CalculatorEngine calculatorEngine = new CalculatorEngine();

                    Console.WriteLine("Please enter the first number:");
                    double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                    while (double.IsNaN(firstNumber))
                        firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

                    Console.WriteLine("Please enter the second number:");
                    double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                    while (double.IsNaN(secondNumber))
                        secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

                    Console.WriteLine("Please enter the operator:");
                    string operation = Console.ReadLine();

                    double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                    while (double.IsNaN(result))
                    {
                        Console.WriteLine("Invalid operator \nPlease utilize one of the following: \nadd subtract multiply divide + - * / \n");
                        operation = Console.ReadLine();
                        result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                    }

                    Console.WriteLine("The value " + String.Format("{0:.00}", firstNumber) + " " + operation + " " + String.Format("{0:.00}", secondNumber) + " is equal to " + String.Format("{0:.00}", result));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Would you like to restart application. if yes, write 'yes'");
                restart = Console.ReadLine();

            } while (restart == "yes");
            System.Environment.Exit(0);
        }
    }
}
