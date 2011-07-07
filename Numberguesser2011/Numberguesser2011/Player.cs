using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Numberguesser2011
{
    class Player : Character
    {


        protected int _score;
        protected string _username;
        private delegate bool MenuOption(Arena.FightState state);

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public Player(string username, int score, int level, int str, int def, int dex, int spd, int sta, int exp)
            : base(username, score, level, str, def, dex, spd, sta, exp)
        {
            this.Score = score;
            this.Username = username;
        }

        public override void TakeTurn(Arena.FightState state)
        {
            Console.WriteLine("_____________________");
            state.StatusReport(this);
            Console.WriteLine("_____________________");
            bool madeSelection = false;
            MenuOption[] options = { ChooseAttackTarget, ChooseSpecial, ChooseItem, ConfirmFlee, null };
            String[] optionDesc = { "Attack", "Special", "Items", "Flee", "Do Nothing" };

            while (!madeSelection)
            {
                MenuOption choice = Menu<MenuOption>.SimpleMenu(options, optionDesc, false);
                if (choice == null)
                {
                    madeSelection = true;
                    continue;
                }
                else
                    madeSelection = choice(state);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
        }


        public bool ChooseAttackTarget(Arena.FightState state)
        {
            bool targetChosen = false;
            NewLinked<Team> targetTeams = GetTargets(state);
            NewLinked<Character> targets = new NewLinked<Character>();

            for (int i = 0; i < targetTeams.Length; i++)
                for (int x = 0; x < targetTeams.Get(i)._members.Length; x++)
                {
                    if (!targetTeams.Get(i)._members[x].IsDead)
                        targets.Add(targetTeams.Get(i)._members[x]);
                }

            MenuItem<Character>[] menuItems = MakeMenu(targets);
            for (int i = 0; i < menuItems.Length; i++)
                menuItems[i].NeedsConfirm = false;

            Console.WriteLine("Choose a target to attack:");
            Character attackTarget = Menu<Character>.ShowMenu(menuItems);

            if (attackTarget == null)
                targetChosen = false;
            else
            {
                this.Attack(attackTarget, state);
                targetChosen = true;
            }

            return targetChosen;
        }


        public bool ChooseSpecial(Arena.FightState state)
        {
            bool choseSpecial = false;
            Console.WriteLine("No specials available!");
            return choseSpecial;
        }


        public bool ChooseItem(Arena.FightState state)
        {
            bool choseItem = false;
            Console.WriteLine("You have no items!");
            return choseItem;
        }


        public bool ConfirmFlee(Arena.FightState state)
        {
            bool fled = false;
            Console.WriteLine("Flee chance will be based on your AT and speed versus the remaining opponents possibly blocking your escape. Are you sure? y/n");
            Char input = Input.GetUserAny();
            if (input == 'y')//Flee chance calculation goes in here (later) (much later)
                fled = true;
            else
                fled = false;
            return fled;
        }

        MenuItem<Character>[] MakeMenu(NewLinked<Character> targets)
        {
            MenuItem<Character>[] menuItems = new MenuItem<Character>[targets.Length + 1];
            for (int i = 0; i < menuItems.Length - 1; i++)
            {
                menuItems[i] = new MenuItem<Character>();
                menuItems[i].Content = targets.Get(i);
                menuItems[i].Description = targets.Get(i).Name + ":  HP " + targets.Get(i).HP + "/" + targets.Get(i).MaxHP + ", AT " + targets.Get(i).AT;
            }
            menuItems[menuItems.Length - 1] = new MenuItem<Character>();
            menuItems[menuItems.Length - 1].Content = null;
            menuItems[menuItems.Length - 1].Description = "Go Back";
            return menuItems;
        }

        public void LevelUp(bool showNextLevel)
        {
            int[] levelUps = { 100, 250, 500, 1000, 1750, 3000, 5000, 7500, 11000, 15000, 19500, 25000, 31000, 37500, 45000, 52000, 60000, 70000, 82500, 95000, 110000 };

            Console.WriteLine("Current XP: " + XP);
            if (XP >= levelUps[Level] && Level < levelUps.Length)
            {
                Console.WriteLine("You leveled up!");
                Console.WriteLine("You can add one extra point to any two stats. Pick which stats you would like to increase");
                Console.WriteLine();

                MenuItem<String>[] stats = new MenuItem<String>[5];
                for (int i = 0; i < stats.Length; i++)
                {
                    MenuItem<String> stat = new MenuItem<String>();
                    stats[i] = stat;
                }
                stats[0].Content = "Strength";
                stats[0].Description = "Strength";
                stats[1].Content = "Defense";
                stats[1].Description = "Defense";
                stats[2].Content = "Dexterity";
                stats[2].Description = "Dexterity";
                stats[3].Content = "Speed";
                stats[3].Description = "Speed";
                stats[4].Content = "Stamina";
                stats[4].Description = "Stamina";

                int increaseCount = 2;
                string lastStat = null;
                while (increaseCount > 0)
                {
                    String statToIncrease = Menu<String>.ShowMenu(stats);
                    if (statToIncrease != lastStat)
                    {
                        lastStat = statToIncrease;

                        switch (statToIncrease)
                        {
                            case "Strength":
                                Strength++;
                                break;
                            case "Defense":
                                Defense++;
                                break;
                            case "Dexterity":
                                Dexterity++;
                                break;
                            case "Speed":
                                Speed++;
                                break;
                            case "Stamina":
                                Stamina++;
                                break;
                            default:
                                break;
                        }
                        increaseCount--;
                        if(lastStat == null)
                            Console.WriteLine("Pick one more stat to increase.");
                    }
                    else
                        Console.WriteLine("You've already increased that stat. You cannot increase it again this level.");

                }
                Level++;
                if (Level == levelUps.Length)
                    Console.WriteLine("You've hit max level. Gratz");
                else
                    LevelUp(false);

            }
            if(showNextLevel)
                Console.WriteLine("Next Level: " + (levelUps[Level] - XP));

        }

    }
}