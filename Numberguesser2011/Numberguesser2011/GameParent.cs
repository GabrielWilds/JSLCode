using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Numberguesser2011
{
    abstract class GameParent
    {

        private Player playerImported;
        private int _betVal = 0;

        public GameParent(Player playerIncoming)
        {
            playerImported = playerIncoming;
        }

        public Player PlayerCheck
        {
            get { return playerImported; }
            private set { playerImported = value; }
        }

        public abstract void PlayGame();


        protected void MakeBet()
        {
            int userBet = 0;
            bool finishedBet = false;

            while (!finishedBet)
            {
                Console.WriteLine("Your Score is " + this.PlayerCheck.Score);
                Console.WriteLine("How much would you like to bet on the game?");
                userBet = Input.GetUserNumString();

                if (userBet > PlayerCheck.Score)
                    Console.WriteLine("You don't have that much to bet!");
                else if (userBet < 0)
                    Console.WriteLine("You have to bet a positive number");
                else
                {
                    Console.WriteLine("You have chosen to bet " + userBet + " of your score of " + this.PlayerCheck.Score);
                    _betVal = userBet;

                    finishedBet = true;
                }
            }
        }


        protected void ApplyBet(bool gameWon, int multiplier)
        {
            if (!gameWon)
                PlayerCheck.Score = this.PlayerCheck.Score - _betVal;
            else
            {
                PlayerCheck.Score = this.PlayerCheck.Score + (_betVal * multiplier);
            }
            Program.SaveData();
            Console.WriteLine("Your Score is " + PlayerCheck.Score);
        }


    }
}
