using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    static class Randomizer
    {

        static Random randomVar = new Random();


        public static int RandomNumber()
        {
            int output = randomVar.Next();
            return output;
        }

        public static int RandomNumber(int maxVal)
        {
            int output = randomVar.Next(maxVal);
            return output;
        }

        public static int RandomNumber(int minVal, int maxVal)
        {
            int output = randomVar.Next(minVal, maxVal);
            return output;
        }


    }
}
