using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertInputToNumeric(string argTextInput)
        {
            double convertedNumber;
            if (!double.TryParse(argTextInput, out convertedNumber))
            {
                Console.Write("Invalid number, please insert a valid digit \n");
                return double.NaN;
            }
            else
                return convertedNumber;
        }
    }
}
