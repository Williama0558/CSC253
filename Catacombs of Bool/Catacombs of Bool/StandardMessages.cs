using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    class StandardMessages
    {
        public static void IntroductionMessage()
        {
            // Method for displaying a message to welcome the player
            Console.Write("Welcome to Catacombs of Bool, a text-based dungeon crawl made with the Visual Studio console.");
            Console.Write("This final iteration of the game showcases everything that has been added to the program over the course of the class.\n\nPlease type in 'Start'" +
                          " to start the game if you don't have a character, or type 'Load' to load a previous character: \n\n");
        }

        public static void HelpMessages()
        {
            // Method for displaying commands the user can enter.
            Console.Write("\n\nType 'end' to bring up the option to quit the game.\n");
            Console.Write("Type 'weapons' to display the weapons array.\n");
            Console.Write("Type 'room' to display the rooms array\n");
            Console.Write("Type 'combat' to fight the enemy in the current room\n");
            Console.Write("Type 'save' to save the game\n");
            Console.Write("Type 'inventory' to bring up what you have in your inventory\n");
            Console.Write("Type 'exit' to leave the dungeon after beating the boss\n\n");
        }

        public static void EndMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("After your difficult adventure inside of Bool's Catacombs, you finally emerge victorious");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Congratulations on beating the game, and thank you for playing.");
            Console.ResetColor();
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
