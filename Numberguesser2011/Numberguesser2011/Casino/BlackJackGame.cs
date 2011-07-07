using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;
using Utility;

namespace Casino
{
    class BlackJackGame : GameParent
    {


        public BlackJackGame(Player playerImported)
            : base(playerImported)
        {
        }

        NewLinked<Card> _playerHand = new NewLinked<Card>();
        int _playerScore = 0;
        NewLinked<Card> _dealerHand = new NewLinked<Card>();
        int _dealerScore = 0;
        Deck _deckCards = new Deck();

        public override void PlayGame()
        {
            Console.WriteLine("This is Real Blackjack. It is super real. Press 1 to Hit. Press 2 to Stay.");
            Console.WriteLine("Get as close to 21 as possible without going over. Jacks/Queens/Kings are worth 10. Aces can be 1 or 11.");
            Console.WriteLine();

            _deckCards.MakeDeck();
            MakeBet();
            Console.WriteLine();

            bool playerWon = false;
            PlayPlayerHand();
            PlayDealerHand();

            if (_playerScore > 21)
            {
                Console.WriteLine("You've Busted.");
            }
            else if (_dealerScore > 21)
            {
                Console.WriteLine("The Dealer has busted.");
                playerWon = true;
            }
            else if (_dealerScore > _playerScore)
            {
                Console.WriteLine("The Dealer wins, with a total of " + _dealerScore + " over the Player's " + _playerScore);
            }
            else if (_dealerScore == _playerScore)
            {
                Console.WriteLine("Both hands are equal. The game is a Draw. Your bet value is returned.");
            }
            else
            {
                Console.WriteLine("The Player wins, with a total of " + _playerScore + " over the Dealer's " + _dealerScore);
                playerWon = true;
            }

            Console.WriteLine("Game Over. Your Hand Total was: " + _playerScore);
            if (_dealerScore != _playerScore)
                ApplyBet(playerWon, 1);
            Console.ReadKey();
            Console.Clear();
        }



        protected void DrawCard(NewLinked<Card> hand, int drawCount)
        {

            for (int cardNum = 0; cardNum < drawCount; cardNum++)
            {
                hand.Add(_deckCards.Draw());
            }

        }


        protected void PlayPlayerHand()
        {
            DrawCard(_dealerHand, 1);
            Console.WriteLine("The Dealer shows his first card, a " + _dealerHand.Get(0).ToString());
            Console.WriteLine();
            Console.WriteLine("You are dealt your first cards.");
            DrawCard(_playerHand, 2);
            int userInput = 0;
            bool stayed = false;

            while (!stayed)
            {
                _playerScore = CalculateHand(_playerHand);
                if (_playerScore > 21)
                {
                    Console.WriteLine("You a busta.");
                    break;
                }
                Console.WriteLine("1. Hit 2. Stay");
                userInput = Input.GetUserNum();
                switch (userInput)
                {
                    case 1:
                        DrawCard(_playerHand, 1);
                        break;
                    case 2:
                        stayed = true;
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine();
        }


        protected void PlayDealerHand()
        {
            if (_playerScore < 22)
            {
                Console.WriteLine("Dealer takes his turn.");
                Console.ReadKey();
                Console.Clear();

                DrawCard(_dealerHand, 1);
                _dealerScore = CalculateHand(_dealerHand);

                while (_dealerScore < 17)
                {
                    DrawCard(_dealerHand, 1);
                    _dealerScore = CalculateHand(_dealerHand);
                }
            }
        }

        protected int CalculateHand(NewLinked<Card> hand)
        {
            Console.WriteLine("Hand contents:");
            Card curCard = null;
            int totalScore = 0;
            int cardVal = 0;
 
            for (int i = 0; i < hand.Length; i++)
            {
                curCard = (Card)hand.Get(i);
                cardVal = (int)curCard.Rank;
                Console.WriteLine(hand.Get(i).ToString());

                if (curCard.Rank == Rank.Ace)
                    continue;
                if (cardVal > 10)
                    cardVal = 10;
                totalScore = totalScore + cardVal;

            }

            for (int i = 0; i < hand.Length; i++)
            {
                curCard = (Card)hand.Get(i);
                cardVal = (int)curCard.Rank;
                if (curCard.Rank != Rank.Ace)
                    continue;
                if (totalScore + 11 > 21)
                    totalScore++;
                else
                    totalScore = totalScore + 11;
            }

            Console.WriteLine();
            Console.WriteLine("Hand Value is " + totalScore);
            Console.WriteLine();
            return totalScore;
        }
    }

}
