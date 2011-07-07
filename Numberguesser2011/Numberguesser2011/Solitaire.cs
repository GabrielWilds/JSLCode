using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;
using Utility;

namespace Casino
{
    class Solitaire : GameParent
    {

        public Solitaire(Player playerImported)
            : base(playerImported)
        {
        }

        public override void PlayGame()
        {
            bool gameWon = false;
            String[] tips = { "...Heh", "If you want to learn programming, it helps having a good friend who knows how to program.", "Stay off the iodine.", "Rice makes a good sandwich filling. Try it, you'll like it!", "You can see boobs at http://www.google.com/search?q=boobs", "You can put back cards stacked on the aces to make possible connections, at the cost of points.", "Lying is often useful, and sometimes a neccesity, to get by in life." };

            Console.WriteLine("Welcome to Solitaire, the totally fun and fair way to make money!");
            MakeBet();
            Console.WriteLine("Alright, welcome to Solitaire. Now, go play a game of Solitaire.");
            Console.WriteLine("I'll wait.");
            String[] options = { "Ok.", "How do I play Solitaire?" };
            int selection = Menu<String>.ShowMenu(options);
            if (selection == 1)
            { }
            if (selection == 2)
            {
                Console.WriteLine("Click Start, maybe Programs (start menus vary), Games, Solitaire. Not Spider Solitaire. Just Solitaire. Ok? Go.");
            }
            Console.WriteLine("...");
            Console.WriteLine("...");
            Console.WriteLine("Ok, done? Well, how'd it go? You win, or what?");
            String[] options2 = { "Yes, I did.", "Nah, got stuck." };
            selection = Menu<String>.ShowMenu(options2);
            if (selection == 1)
            {
                Console.WriteLine("Good Job! Here's your money, well earned.");
                gameWon = true;
            }
            if (selection == 2)
            {
                Console.WriteLine("I respect your honesty, and better luck next time. As a concelation prize, here's a tip:");
                Console.WriteLine(tips[Randomizer.RandomNumber(tips.Length)]);
            }
            ApplyBet(gameWon, 1);
        }
    }
}
