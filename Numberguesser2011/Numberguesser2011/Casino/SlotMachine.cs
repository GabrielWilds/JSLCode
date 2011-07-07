using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;
using Utility;

namespace Casino
{
    class SlotMachine : GameParent
    {

        public SlotMachine(Player playerImported)
            : base(playerImported)
        {
        }

        public override void PlayGame()
        {
            Console.WriteLine("Welcome to Slot Machine.");
            Console.WriteLine("Enter a Reel count for the slot machine.");

            bool playerWon = true;
            bool playerDone = false;

            Reel[] reelArray = new Reel[Input.GetUserNum()];
            int betMultiplier = reelArray.Length * ((int)reelArray.Length / 2);
            if (betMultiplier < 2)
                betMultiplier = 1;

            for (int i = 0; i < reelArray.Length; i++)
                reelArray[i] = new Reel();

            do
            {
                Console.WriteLine(reelArray.Length + " reels will roll. If their faces match, you win " + betMultiplier + " times your bet value.");
                MakeBet();

                foreach (Reel reel in reelArray)
                    reel.SpinReel();

                foreach (Reel reel in reelArray)
                    Console.Write(reel.Face);

                Console.WriteLine();

                playerWon = CheckWinState(reelArray);

                ApplyBet(playerWon, betMultiplier);

                Console.WriteLine("Return to Main Menu? y/n");
                char userConfirm = Input.GetUserAny();
                if (userConfirm == 'y')
                    playerDone = true;

            } while (!playerDone);

        } 
        //end PlayGame



        protected bool CheckWinState(Reel[] reelArray)
        {
            bool reelsMatch = true;
            for (int i = 1; i < reelArray.Length && reelsMatch; i++)
            {
                if (reelArray[0].Face != reelArray[i].Face)
                    reelsMatch = false;
            }

            if (!reelsMatch)
                Console.WriteLine("You Lose.");
            else
                Console.WriteLine("You Win!");
            return reelsMatch;
        } 

    }
}
