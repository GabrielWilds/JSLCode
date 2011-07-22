using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class Case
    {
        public Case(string brand, string size, string color)
        {
            Brand = brand;
            Size = size;
            Color = color;
        }

        public string Brand
        {
            get;
            private set;
        }

        public string Size
        {
            get;
            private set;
        }

        public string Color
        {
            get;
            private set;
        }

        public Motherboard Mobo
        {
            get;
            set;
        }

        public Processor CPU
        {
            get;
            set;
        }

        public VideoCard Videocard
        {
            get;
            set;
        }

        public RAM Ram
        {
            get;
            set;
        }

        public DiskDrive Diskdrive
        {
            get;
            set;
        }

        public List<Fan> Fans
        {
            get
            {
                return fans;
            }
        }

        List<Fan> fans = new List<Fan>();

        public void AddFan(Fan fan)
        {
            fans.Add(fan);
        }

    }
}
