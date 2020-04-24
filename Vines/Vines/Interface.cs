using System;
using System.Collections.Generic;
using System.Text;

namespace Vines
{
    public static class Interface
    {
        public static string RawInput()
        {
            return Console.ReadLine();
        }

        public static char GetNumber()
        {
            char[] numbers = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            char r = '0';
            string attempt = Console.ReadLine();

            for (int i = 0; i < attempt.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (char.Equals(numbers[j], attempt[i]))
                    {
                        r = attempt[i];
                        return r;                        
                    }
                }
            }
            return r;
        }
    }
}
