using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Numberguesser2011;
using Utility;
using System.Threading;

namespace Arena
{
    class Combat
    {

        public static void ChoseFight(Player player)
        {
            Console.WriteLine("The Arena is bustling, full of gamblers looking to bet on fights, and fighters looking to beat up on gamblers. You look over the various counters and stalls.");


            MenuItem<int>[] fights = new MenuItem<int>[4];

            for (int i = 0; i < fights.Length; i++)
            {
                MenuItem<int> fight = new MenuItem<int>();
                fights[i] = fight;
            }

            fights[0].Content = 0;
            fights[0].Description = "Start a Ladder Match";
            fights[1].Content = 1;
            fights[1].Description = "Start a Randomized Match";
            fights[2].Content = 2;
            fights[2].Description = "Customize a Match";
            fights[3].Content = 3;
            fights[3].Description = "Return to main menu";
            fights[3].NeedsConfirm = false;

            FightState state = new FightState(null);
            int selection = Menu<int>.ShowMenu(fights);
            switch (selection)
            {
                case 0:
                    state = LadderFight(player);
                    break;
                case 1:
                    state = RandomFight(player);
                    break;
                case 2:
                    state = CustomizedFight(player);
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            Fight(state, player);

        }

        public static FightState RandomFight(Player player)
        {
            String path = "npc.txt";
            String[] monsters = File.ReadAllLines(path);

            int teamCount = Randomizer.RandomNumber(1, 4);
            int monsterCount = Randomizer.RandomNumber(teamCount, teamCount * Randomizer.RandomNumber(1, 3));
            Team[] teams = new Team[teamCount + 1];
            for (int i = 0; i < teams.Length; i++)
            {
                Team team = new Team();
                teams[i] = team;
            }
            Character[] playerTeam = new Character[1];
            playerTeam[0] = player;
            teams[0].SetTeam(playerTeam);

            for (int i = 1; i < teams.Length; i++)
            {
                NPC[] team = new NPC[monsterCount];
                for (int x = 0; x < team.Length; x++)
                {
                    NPC monster = new NPC(null, 0, 0, 0, 0, 0, 0, 0, 0);
                    monster = GetMonster(monsters, Randomizer.RandomNumber(monsters.Length));
                    team[x] = monster;
                }
                teams[i].SetTeam(team);
            }
            FightState state = new FightState(teams);

            return state;
        }

        public static FightState LadderFight(Player player)
        {
            throw new NotImplementedException();
        }

        public static FightState CustomizedFight(Player player)
        {
            throw new NotImplementedException();
            //TODO
        }


        public static void Fight(FightState state, Player player)
        {
            Team[] teams = state.GetTeams;
            bool endState = false;

            while (!endState)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    if (endState)
                        continue;
                    if (teams[i].IsDead)
                    {
                        Console.WriteLine("Team " + teams[i].TeamName + " is all dead");
                        continue;
                    }
                    for (int x = 0; x < teams[i].Members.Length; x++)
                    {
                        if (endState || teams[i].Members[x].IsDead)
                            continue;
                        else if (CheckState(state))
                            endState = true;
                        else
                        {
                            teams[i].Members[x].IncrementAT();
                            state.StatusReport(player);
                            //Console.WriteLine(teams[i].Members[x].Name + "'s AT is " + teams[i].Members[x].AT);

                            if (teams[i].Members[x].AT >= 40)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine(teams[i].Members[x].Name + " takes a turn.");
                                teams[i].Members[x].TakeTurn(state);
                                Console.WriteLine();
                                if (teams[i].Members[x] is NPC)
                                    Thread.Sleep(500);
                            }
                            else
                                Thread.Sleep(50);

                            Console.Clear();
                        }
                    }

                }
            }
            Console.WriteLine("The fight is over!");
            if (!player.IsDead)
                RewardPlayer(state, player);
            else
                Console.WriteLine("You were knocked out...");

            player.Heal(player.MaxHP);
            player.IsDead = false;

            Program.SaveData();
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
        }


        public static bool CheckState(FightState state)
        {
            bool endState = false;
            int deadTeams = 0;
            Team[] teams = state.GetTeams;
            for (int i = 0; i < teams.Length; i++)
            {
                int deadPlayers = 0;
                for (int x = 0; x < teams[i].Members.Length; x++)
                {
                    if (teams[i].Members[x].HP <= 0)
                    {
                        teams[i].Members[x].IsDead = true;
                        deadPlayers++;
                    }
                }
                if (teams[i]._members.Length == deadPlayers)
                {
                    teams[i].IsDead = true;
                    deadTeams++;
                }
                if (teams[i].IsDead == true && teams[i].Leader is Player)
                    endState = true;
            }

            if (deadTeams + 1 == teams.Length)
                endState = true;

            return endState;
        }

        public static void RewardPlayer(FightState state, Player player)
        {
            Team[] teams = state.GetTeams;
            int money = 0;
            int exp = 0;

            for (int i = 0; i < teams.Length; i++)
                for (int x = 0; x < teams[i].Members.Length; x++)
                    if (teams[i].Members[x] is NPC)
                    {
                        money = money + teams[i].Members[x].Money;
                        exp = exp + teams[i].Members[x].XP;
                    }
            Console.WriteLine(player.Username + " earns " + money + " money!");
            Console.WriteLine(player.Username + " gains " + exp + " experience!");
            player.Score = player.Score + money;
            player.XP = player.XP + exp;
            player.LevelUp(true);
        }

        static NPC GetMonster(String[] monsterTable, int monsterNum)
        {
            String[] monsterInfo = monsterTable[monsterNum].Split(',');
            String name = monsterInfo[0];
            int money = int.Parse(monsterInfo[1]);
            int level = int.Parse(monsterInfo[2]);
            int strength = int.Parse(monsterInfo[3]);
            int def = int.Parse(monsterInfo[4]);
            int dex = int.Parse(monsterInfo[5]);
            int spd = int.Parse(monsterInfo[6]);
            int sta = int.Parse(monsterInfo[7]);
            int XP = int.Parse(monsterInfo[8]);
            NPC monster = new NPC(name, money, level, strength, def, dex, spd, sta, XP);
            return monster;
        }
    }
}
