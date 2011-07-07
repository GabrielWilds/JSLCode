using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;
using Utility;

namespace Casino
{
    class Card
    {
        private Rank _rank;
        private Suit _suit;


        public Rank Rank
        {
            get { return _rank; }
        }

        public Suit Suit
        {
            get { return _suit; }
        }

        public Card(Rank rank, Suit suit)
        {
            _rank = rank;
            _suit = suit;
        }

        public override String ToString()
        {
            return _rank.ToString() + " of " + _suit.ToString() + "s.";
        }
    }
}
