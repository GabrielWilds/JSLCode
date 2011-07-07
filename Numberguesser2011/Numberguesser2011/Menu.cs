using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Numberguesser2011
{
    class Menu<T>
    {

        public static T ShowMenu(MenuItem<T>[] menuItems)
        {
            bool valid = false;
            T selectedObject = menuItems[0].Content;
            while (!valid)
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i > 9)
                        continue;
                    Console.WriteLine((i + 1) + ". " + menuItems[i].Description);
                }
                Console.WriteLine("_____________________________");
                Console.WriteLine("Choose an option");
                int selectedNumber = Input.GetUserNum() - 1;
                if (selectedNumber < 0 || selectedNumber >= menuItems.Length)
                {
                    Console.WriteLine("Invalid Selection");
                    continue;
                }
                else
                {
                    valid = true;
                    Console.WriteLine("You have selected " + menuItems[selectedNumber].Description);
                    if (menuItems[selectedNumber].NeedsConfirm)
                    {
                        Console.WriteLine("Are You Sure? y/n");
                        char userConfirm = Input.GetUserAny();
                        if (userConfirm != 'y')
                            valid = false;
                    }
                    if (valid)
                        selectedObject = menuItems[selectedNumber].Content;
                }

            }
            return selectedObject;
        }

        public static int ShowMenu(String[] menuOptions)
        {
            for (int i = 0; i < menuOptions.Length; i++)
                Console.WriteLine((i + 1) + ". " + menuOptions[i]);
            int playerSelection = Input.GetUserNum();
            return playerSelection;
        }

        public static T SimpleMenu(T[] contents, String[] descriptions, bool confirm)
        {
            MenuItem<T>[] items = new MenuItem<T>[contents.Length];
            for (int i = 0; i < contents.Length; i++)
            {
                items[i] = new MenuItem<T>();
                items[i].Content = contents[i];
                items[i].Description = descriptions[i];
                if (!confirm)
                    items[i].NeedsConfirm = false;
            }
            T result = ShowMenu(items);
            return result;

        }

    }
}
