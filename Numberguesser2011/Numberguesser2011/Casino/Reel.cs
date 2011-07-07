using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;
using Utility;

namespace Casino
{
    class Reel
    {
        char[] reelArray = new char[5] { '!', '@', '#', '$', '%' };
        private int _curFace = 0;
        public char Face
        {
            get { return reelArray[_curFace]; }
        }


        public void SpinReel()
        {
            _curFace = Randomizer.RandomNumber(reelArray.Length);
        }
    }
}
