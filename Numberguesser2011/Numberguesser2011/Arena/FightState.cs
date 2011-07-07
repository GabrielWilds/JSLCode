using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Numberguesser2011;

namespace Arena
{
    class FightState
    {
        private Team[] teams;
        public FightState(Team[] selectedTeams)
        {
            teams = selectedTeams;
        }

        public Team[] GetTeams
        {
            get { return teams; }
        }

        public void StatusReport(Character currentActor)
        {
            int nameSpace = 16;
            for (int i = 0; i < teams.Length; i++)
            {
                Console.Write("__Team ");
                if (teams[i].Leader is Player)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(teams[i].TeamName);
                Console.ResetColor();
                Console.WriteLine("__");

                for (int x = 0; x < teams[i].Members.Length; x++)
                {
                    string charName = teams[i].Members[x].Name;
                    if (teams[i].Members[x] is Player)
                        charName = "Your Status:";

                    int namePadding = nameSpace - charName.Length;

                    for (int y = 0; y < namePadding; y++)
                        charName = charName.Insert(charName.Length, " ");
                    if (!teams[i].Members[x].IsDead)
                        Console.WriteLine(charName + "| " + teams[i].Members[x].HP.ToString("00") + "\\" + teams[i].Members[x].MaxHP.ToString("00") + " | " + teams[i].Members[x].AT.ToString("00"));
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(teams[i].Members[x].Name + ": Dead");
                        Console.ResetColor();
                    }

                }

            }
        }

    }
}
