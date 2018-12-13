using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{

    class Combat
    {
        public static Potions[] potionsArray = PotionGeneration.createPotions();
        public static List<Items> itemList = ItemGeneration.createItems();
        // This class controls the fighting mechanics of the game.
        public static void getCombatants(Player player, Monster monster)
        {
            Random rng = new Random();
            Console.WriteLine("\n\n");
            while (player.health > 0 && monster.health > 0)
            {
                // Displays status to the player
                Console.WriteLine("You are currently fighting " + monster.name + "\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You currently have " + player.health + " hitpoints\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("It currently has " + monster.health + " hitpoints\n");
                Console.ResetColor();
                Console.WriteLine("Type in 'attack' to attack the enemy\n");
                Input combatChoice = new Input();
                combatChoice.userInput = Console.ReadLine().ToUpper();

                // Checks to see if the player hits and for how much.
                if (combatChoice.userInput == "ATTACK")
                {
                    int hitChance = rng.Next(1, 15);
                    if (hitChance >= monster.agility)
                    {
                        int damage = rng.Next(monster.armorValue, 20);
                        monster.health -= player.baseDamage + damage;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You hit the " + monster.name + " for " + damage + " hitpoints\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You missed the " + monster.name);
                        Console.ResetColor();
                    }
                }

                // Checks to see if the enemy hits and for how much
                int enemyHitchance = rng.Next(1, 15);
                if (monster.health > 0)
                {
                    if (enemyHitchance >= player.agility)
                    {
                        int damage = rng.Next(player.armorValue, 15);
                        player.health -= damage;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("The " + monster.name + " hit you for " + damage + " hitpoints\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nThe " + monster.name + " missed!\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The " + monster.name + " died before it could strike again!");
                    Console.ResetColor();
                }

            }

            // Displays a message depending on who wins.
            if (player.health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You died, game over");
                Console.ResetColor();
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You defeated the " + monster.name + "!");
                Console.ResetColor();
                if (monster.name == "Goblin")
                {
                    Console.WriteLine("You found a potion on the body of the goblin");
                    player.playerInventory.Add(new Potions(potionsArray[0].name, potionsArray[0].description, potionsArray[0].recoveryValue));
                }
                else if (monster.name == "Bool")
                {
                    Console.WriteLine("You found an old pair of mittens on Bool's body");
                    player.playerInventory.Add(new Items(itemList[3].name, itemList[3].description));

                }
            }
        }
    }
}
