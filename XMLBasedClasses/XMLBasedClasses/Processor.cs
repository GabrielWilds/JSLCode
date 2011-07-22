using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class Processor
    {
        public Processor(string name, string brand, string socket, decimal speed, string cooling)
        {
            Name = name;
            Brand = brand;
            Socket = socket;
            SpeedInGhz = speed;
            Cooling = cooling;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Brand
        {
            get;
            private set;
        }

        public string Socket
        {
            get;
            private set;
        }

        public decimal SpeedInGhz
        {
            get;
            private set;
        }

        public string Cooling
        {
            get;
            set;
        }
    }
}
