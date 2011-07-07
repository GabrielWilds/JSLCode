using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;
using Utility;

namespace Casino
{
    class Guesser : GameParent
    {


        public Guesser(Player playerImported)
            : base(playerImported)
        {
        }


        public override void PlayGame()
        {
            int randomCompare = Randomizer.RandomNumber(1, 10);
            int userCompare = 0;
            bool playerWin = false;

            Console.WriteLine("Let's Play... THE RANDOM NUMBER GUESSING GAME!!");
            Console.WriteLine("We generate a random number.... AND YOU GUESS IT!");
            Console.WriteLine();
            MakeBet();

            Console.WriteLine();
            Console.WriteLine("Alright, we've got a number from 1 to 10. See if you can guess what it is. You get three guesses.");
            Console.WriteLine("Enter your answer and press return:");
            Console.WriteLine();

            for (int tries = 0; tries < 3; tries++)
            {
                if (tries != 0)
                    Console.WriteLine("Guess Again!");

                userCompare = Input.GetUserNumString();

                if (userCompare == randomCompare)
                {
                    Console.WriteLine("You got it right! Goddamn! Holy Shit! etc");
                    playerWin = true;
                    break;
                }
                else if (userCompare > randomCompare)
                {
                    Console.Beep();
                    Console.WriteLine("You're too high!");
                }
                else if (userCompare < randomCompare)
                {
                    Console.Beep();
                    Console.WriteLine("Too low!");
                }

            }

            ApplyBet(playerWin,1);
            Console.WriteLine("Game Over!");
        }

    }

}
