using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class Start_Game
    {
        public static bool runProgram = true;
        public static void gameStart()
        {

            Player player = new Player();


            while (runProgram == true)
            {
                StandardMessages.IntroductionMessage();
                string startGame = Console.ReadLine().ToUpper();
                // Lets the user enter input to either start the game or load a previous save
                if (startGame == "START")
                {
                    player = CharacterCreation.createCharacter();

                    Console.Write("\nYou move into the Entrance of the dungeon.\n");
                    moveThroughDungeon();
                }
                else if (startGame == "LOAD")
                {
                    bool saveGame = false;
                    bool loadGame = true;
                    // Loads the player's information from a method that reads a file.
                    player = CharacterCreation.storePlayerInfo(saveGame, loadGame);
                    moveThroughDungeon();
                }
                else
                {
                    Console.Write(startGame + " is not a valid option, please try again.\n\n");
                    gameStart();
                }
            }
        }

        public static void moveThroughDungeon()
        {
            while (runProgram == true)
            {
                Movement.moveThroughDungeon();
            }
        }
    }
}
