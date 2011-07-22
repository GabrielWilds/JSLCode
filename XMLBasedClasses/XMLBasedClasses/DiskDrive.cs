using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class DiskDrive
    {
        public DiskDrive(string type, string brand, string quality)
        {
            Type = type;
            Brand = brand;
            Quality = quality;
        }

        public string Type
        {
            get;
            private set;
        }

        public string Brand
        {
            get;
            private set;
        }

        public string Quality
        {
            get;
            private set;
        }
    }
}
