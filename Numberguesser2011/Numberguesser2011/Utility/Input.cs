using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    static class Input
    {
        public static int GetUserNumString()
        {
            int userInputParsed = 0;
            bool parsed = false;

            while (!parsed)
            {
                string userInput = Console.ReadLine();
                parsed = Int32.TryParse(userInput, out userInputParsed);
                if (!parsed)
                {
                    Console.Beep();
                    Console.WriteLine("Not a Valid Entry");
                }

            }

            return userInputParsed;
        }

        public static int GetUserNum()
        {
            bool isNum = false;
            int userInput = 0;
            while (!isNum)
            {
                ConsoleKeyInfo userAscii = Console.ReadKey();
                Console.WriteLine();
                userInput = userAscii.KeyChar - 48;
                if (userInput >= 0 && userInput <= 9)
                    isNum = true;
                else
                    Console.WriteLine("Not a valid number. Try Again");
            }
            return userInput;
        }


        public static char GetUserAny()
        {
            char userInput;
            ConsoleKeyInfo userAscii = Console.ReadKey();
            Console.WriteLine();
            userInput = userAscii.KeyChar;
            return userInput;

        }


        public static int GetUserString()
        {
            int userInputParsed = 0;
            bool parsed = false;

            while (!parsed)
            {
                string userInput = Console.ReadLine();
                parsed = Int32.TryParse(userInput, out userInputParsed);
                if (!parsed)
                {
                    Console.Beep();
                    Console.WriteLine("Not a Valid Entry");
                }

            }

            return userInputParsed;
        }
    }
}
