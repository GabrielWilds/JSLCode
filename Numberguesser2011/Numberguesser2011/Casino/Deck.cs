using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;
using Utility;

namespace Casino
{
    class Deck
    {
        NewLinked<Card> _cards = new NewLinked<Card>();
        Utility.Stack<Card> _stack = new Utility.Stack<Card>();
        Random _random = new Random();


        public void MakeDeck()
        {

            Array ranks = Enum.GetValues(typeof(Rank));
            Array suits = Enum.GetValues(typeof(Suit));
            int index = 0;

            foreach (Rank rank in ranks)
            {
                foreach (Suit suit in suits)
                {
                    Card card = new Card(rank, suit);
                    _cards.Add(card);
                    index++;
                }

            }
            while (_cards.Length != 0)
            {
                int cardsIndex = _random.Next(_cards.Length - 1);
                Card card = (Card)_cards.Get(cardsIndex);
                _stack.Push(card);
                _cards.RemoveAt(cardsIndex);
            }
        }

        public Card Draw()
        {
            return (Card)_stack.Pop();
        }

    }
}
