using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class Options
    {
        public static List<Monster> mobList = MonsterGeneration.createMonsters();
        public static Rooms[,] roomsArray = RoomsInformation.createRoomsArray();

        public static string getUserInput()
        {
            // Method to get input from the user
            Console.Write("\nYou can also write 'Help' to bring up a list of commands.");
            Console.Write("\nWhat would you like to do: ");
            Input userChoice = new Input();
            userChoice.userInput = Console.ReadLine().ToUpper();
            if (userChoice.userInput == "E" || userChoice.userInput == "S" || userChoice.userInput == "N" || userChoice.userInput == "W")
            {
                selectMovementOption(userChoice.userInput);
            }
            else
            {
                selectOption(userChoice.userInput);
            }
            return userChoice.userInput;
        }

        public static void selectOption(string userChoice)
        {
            // Method that holds options that don't control the player's movement.
            // Picks an option based on user input from other methods.
            if (userChoice == "HELP")
            {
                displayHelp();
            }
            else if (userChoice == "WEAPONS")
            {
                displayWeapons();
            }
            else if (userChoice == "END")
            {
                endGame();
            }
            else if (userChoice == "ROOM")
            {
                displayRooms();
            }
            else if (userChoice == "SAVE")
            {
                saveGame();
            }
            else if (userChoice == "RNG")
            {
                testRNG();
            }
            // Prevents the error message from popping up for options not covered in this class.
            else if (userChoice == "COMBAT" || userChoice == "INVENTORY" || userChoice == "EXIT")
            {

            }
            else
            {
                Console.Write(userChoice + " is not a valid option.\n\n");
            }
        }

        public static int selectMovementOption(string userChoice)
        {
            int horizontalPosition = 0;
            int verticalPosition = 0;
            if (userChoice == "E")
            {
                horizontalPosition += 1;
                return horizontalPosition;
            }

            else if (userChoice == "W")
            {
                horizontalPosition -= 1;
                return horizontalPosition;
            }

            else if (userChoice == "N")
            {
                verticalPosition -= 1;
                return verticalPosition;
            }

            else if (userChoice == "S")
            {
                verticalPosition += 1;
                return verticalPosition;
            }

            else
            {
                return 0;
            }
        }

        private static void displayHelp()
        {
            // Displays a list of commands the user can enter
            StandardMessages.HelpMessages();
        }

        public static void displayWeapons()
        {
            // Method that displays an array of weapons.
            Weapons[] weaponsArray = WeaponGeneration.createWeapons();
            foreach (Weapons element in weaponsArray)
            {
                Console.Write(element.name + " ");
            }
            Console.WriteLine("\n");
        }

        public static void displayRooms()
        {
            // Method that will display all of the room names in the roomsArray.
            foreach (Rooms element in roomsArray)
            {
                Console.WriteLine(element.roomName + "\n" + element.roomDescription + "\n" + element.roomExits +"\n");
            }
        }

        public static void saveGame()
        {
            
            // Method that saves the player's game
            bool saveGame = true;
            bool loadGame = false;
            Player player = new Player();
            player = CharacterCreation.storePlayerInfo(saveGame, loadGame);
            SqliteDataAccess.savePlayer(player);

            // Old version of saving that was used when text files what stored information
            /*
            StreamWriter playerFile;
            string playerName = player.name;

            // Variable that creates a file with the same name as the player character
            string playerFileName = playerName + ".txt";

            // Writes player information to a file
            playerFile = File.CreateText(playerFileName);
            playerFile.WriteLine(playerName.ToString());
            playerFile.WriteLine(player.password.ToString());
            playerFile.WriteLine(player.playerClass);
            playerFile.WriteLine(player.playerRace);
            playerFile.WriteLine(player.health);
            playerFile.WriteLine(player.agility);
            playerFile.WriteLine(player.armorValue);
            playerFile.Close();
            */
        }

        // Test version of the look method, not ready for use yet
        /*
        public static void lookRoom()
        {
            Console.WriteLine("What would you like to look at: ");
            string userLook = Console.ReadLine();
            int index = 0;
            foreach (object element in roomsArray[verticalPosition, horizontalPosition].roomObjects)
                if (string.Join(",", roomsArray[verticalPosition, horizontalPosition].roomObjects).Contains(userLook))
                {
                    Console.WriteLine(string.Join(",", roomsArray[verticalPosition, horizontalPosition].roomObjects[index]));
                    index++;
                }
                else
                {
                    Console.WriteLine("That object is not in this room");
                    index++;
                }

        }
        */

        public static void testRNG()
        {
            // Method for testing random numbers
            Random rng = new Random();
            Console.Write(rng.Next(1, 100) + "\n");
            Console.Write(rng.Next(1, 1000) + "\n");
            Console.Write(rng.Next());
        }



        public static void endGame()
        {
            bool runProgram = true;
            // Method that will allow the user to end the game/program.
            Console.Write("Press Y if you would like to end the game: ");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "Y")
            {
                Environment.Exit(0);
                runProgram = false;
            }
            else
            {
                Console.Write("Invalid input, resuming game...\n");
            }
        }
    }
}
