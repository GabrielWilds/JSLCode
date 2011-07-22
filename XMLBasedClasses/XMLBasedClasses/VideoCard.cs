using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLBasedClasses
{
    class VideoCard
    {
        public VideoCard(string type, string brand, int vram, string socket, string cooling)
        {
            Type = type;
            Brand = brand;
            VramInMB = vram;
            SocketType = socket;
            Cooling = cooling;
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

        public int VramInMB
        {
            get;
            private set;
        }

        public string SocketType
        {
            get;
            private set;
        }

        public string Cooling
        {
            get;
            private set;
        }

    }
}
