using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Casino;
using Utility;

namespace Numberguesser2011
{
    class Program
    {
        protected static Player _playerObject = new Player("Make New Player", 100, 1, 5, 5, 5, 5, 5, 0);
        protected static String path = "score.txt";
        protected static NewLinked<Player> _players = new NewLinked<Player>();
        protected static bool exitGame = false;

        private delegate void MenuMethod();

        static void Main(string[] args)
        {
            PrepGame();

            while (!exitGame)
            {
                Console.WriteLine();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("JSL's terribad cmd prompt games of questionable quality");
                Console.WriteLine();

                MenuItem<MenuMethod>[] subMenus = new MenuItem<MenuMethod>[4];

                MenuMethod casino = GambleMenu;
                MenuMethod fighter = FightMenu;
                MenuMethod store = ShopMenu;
                MenuMethod menuToRun;

                for (int i = 0; i < subMenus.Length; i++)
                    subMenus[i] = new MenuItem<MenuMethod>();

                subMenus[0].Content = casino;
                subMenus[0].Description = "Casino Games";
                subMenus[0].NeedsConfirm = false;
                subMenus[1].Content = fighter;
                subMenus[1].Description = "Fights";
                subMenus[1].NeedsConfirm = false;
                subMenus[2].Content = store;
                subMenus[2].Description = "Stats and Store";
                subMenus[2].NeedsConfirm = false;
                subMenus[3].Content = null;
                subMenus[3].Description = "Exit Game";

                menuToRun = Menu<MenuMethod>.ShowMenu(subMenus);

                if (menuToRun != null)
                    menuToRun();
                else if (menuToRun == null)
                    exitGame = true;
                Console.Clear();
            }

        }


        static void PrepGame()
        {
            LoadData(path);
            MenuItem<Player>[] playerOptions = new MenuItem<Player>[_players.Length + 1];
            MenuItem<Delegate>[] subMenus = new MenuItem<Delegate>[4];

            for (int i = 0; i < _players.Length; i++)
            {
                playerOptions[i] = new MenuItem<Player>();
                playerOptions[i].Content = _players.Get(i);
                playerOptions[i].Description = _players.Get(i).Username;
            }

            playerOptions[playerOptions.Length - 1] = new MenuItem<Player>();
            playerOptions[playerOptions.Length - 1].Content = _playerObject;
            playerOptions[playerOptions.Length - 1].Description = _playerObject.Username;
            _playerObject = Menu<Player>.ShowMenu(playerOptions);

            if (_playerObject.Username == "Make New Player")
            {
                Console.WriteLine("Enter Your Name:");
                _playerObject.Username = Console.ReadLine();
                _players.Add(_playerObject);
                SaveData();
            }

        }


        static void GambleMenu()
        {
            while (true)
            {

                GameParent gameToRun = null;

                MenuItem<GameParent>[] games = new MenuItem<GameParent>[5];


                for (int i = 0; i < games.Length; i++)
                {
                    MenuItem<GameParent> gameItem = new MenuItem<GameParent>();
                    games[i] = gameItem;
                }

                games[0].Content = new Guesser(_playerObject);
                games[0].Description = "Number Guesser";
                games[1].Content = new BlackJackGame(_playerObject);
                games[1].Description = "Black Jack";
                games[2].Content = new SlotMachine(_playerObject);
                games[2].Description = "Slot Machine";
                games[3].Content = new Solitaire(_playerObject);
                games[3].Description = "Solitaire (not a cheat menu, promise!";
                games[4].Content = null;
                games[4].Description = "Go Back";
                games[4].NeedsConfirm = false;

                gameToRun = Menu<GameParent>.ShowMenu(games);
                Console.Clear();

                if (gameToRun != null)
                    gameToRun.PlayGame();
                else
                    break;
            }

        }

        static void FightMenu()
        {
            Arena.Combat.ChoseFight(_playerObject);
            Console.Clear();
        }

        static void ShopMenu()
        {
            Console.WriteLine("The stand is dark. A sign hangs on the door, announcing \"Coming Soon!\". Better come back later.");
        }

        public static void SaveData()
        {
            string master = "";
            for (int i = 0; i < _players.Length; i++)
            {
                Player player = (Player)_players.Get(i);
                string user = player.Username + ',' + player.Score.ToString() + ',' + player.Level + ',' + player.Strength + ',' + player.Defense + ',' + player.Dexterity + ',' + player.Speed + ',' + player.Stamina + ',' + player.XP;

                if (i != _players.Length - 1)
                    user += '\n';

                master += user;
            }
            File.WriteAllText(path, master);
        }

        public static void LoadData(string path)
        {
            String[] userTable = File.ReadAllLines(path);

            for (int i = 0; i < userTable.Length; i++)
            {
                String userGroup = userTable[i];
                String[] playeri = userGroup.Split(new Char[] { ',' });

                int[] playerStats = new int[playeri.Length - 1];
                for (int stat = 1; stat < playerStats.Length; stat++)
                {
                    if (!Int32.TryParse(playeri[stat], out playerStats[stat - 1]))
                        throw new InvalidDataException();
                }
                string name = playeri[0];
                int score = int.Parse(playeri[1]);
                int level = int.Parse(playeri[2]);
                int str = int.Parse(playeri[3]);
                int def = int.Parse(playeri[4]);
                int dex = int.Parse(playeri[5]);
                int spd = int.Parse(playeri[6]);
                int sta = int.Parse(playeri[7]);
                int exp = int.Parse(playeri[8]);

                Player player = new Player(name, score, level, str, def, dex, spd, sta, exp);
               
                _players.Add(player);
            }
        }


    }
}