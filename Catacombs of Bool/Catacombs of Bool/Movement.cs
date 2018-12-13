using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    class Movement
    {
        // Initializing a room array filled with objects created from the RoomsInformation class
        public static Rooms[,] roomsArray = RoomsInformation.createRoomsArray();
        public static Player player = CurrentPlayer.getCurrentPlayer();
        public static bool runProgram = true;

        public static void moveThroughDungeon()
        {
            // Variables to keep track of the players position
            int horizontalPosition = 0;
            int verticalPosition = 0;

            // Displays current room information to the player
            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine(roomsArray[0, 0].roomName);
            Console.WriteLine(roomsArray[0, 0].roomDescription);
            Console.WriteLine(roomsArray[0, 0].roomExits);
            Console.WriteLine("In this room you see a " + roomsArray[0, 0].roomMonsters.name);

            while (runProgram == true)
            {
                // Moves the player vertically, horizontally, or lets the player fight depending on their input
                string userChoice = Options.getUserInput();

                if (userChoice == "E" || userChoice == "W")
                {
                    horizontalPosition += Options.selectMovementOption(userChoice);
                }

                else if (userChoice == "N" || userChoice == "S")
                {
                    verticalPosition += Options.selectMovementOption(userChoice);
                }

                // Let's the user enter combat
                else if(userChoice == "COMBAT" || userChoice == "combat" || userChoice == "Combat")
                {
                    if (roomsArray[verticalPosition, horizontalPosition].roomMonsters != null)
                    {
                        Combat.getCombatants(player, roomsArray[verticalPosition, horizontalPosition].roomMonsters);
                        roomsArray[verticalPosition, horizontalPosition].roomMonsters = null;
                    }
                    else
                    {
                        Console.WriteLine("There is nothing in this room to fight");
                    }
                }

                // Allows the player to see what's in their inventory
                else if (userChoice == "INVENTORY")
                {
                    Console.WriteLine("In your inventory, you currently have: ");
                    for (int itemIndex = 0; itemIndex < player.playerInventory.Count(); itemIndex++)
                    {
                        Console.WriteLine(player.playerInventory[itemIndex].name);
                    }
                }
                
                // Method that allows the player to win the game if they've defeated the boss
                else if (userChoice == "EXIT")
                {
                    if(verticalPosition == 2 && horizontalPosition == 2)
                    {
                        for(int itemIndex = 0; itemIndex < player.playerInventory.Count(); itemIndex ++)
                        {
                            if (player.playerInventory[itemIndex].name == "Bools' Mittens")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("After defeating the monster of the catacombs, you equip the mittens you looted off the body." +
                                                  "\nYou use these to push open the door leading out of the dungeon.");
                                Console.ResetColor();
                                StandardMessages.EndMessage();

                            }
                            else
                            {
                                Console.WriteLine("You need proof that you defeated Bool");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The dungeon exit is not in this room");
                    }
                }
               



                // If-else statements to prevent the user from going out of the bounds of the map
                if (verticalPosition > 2)
                {
                    Console.WriteLine("Invalid movement option, please try a different direction");
                    verticalPosition--;
                }

                else if (verticalPosition < 0)
                {
                    Console.WriteLine("Invalid movement option, please try a different direction");
                    verticalPosition++;
                }

                else if (horizontalPosition > 2)
                {
                    Console.WriteLine("Invalid movement option, please try a different direction");
                    horizontalPosition--;
                }

                else if (horizontalPosition < 0)
                {
                    Console.WriteLine("Invalid movement option, please try a different direction");
                    horizontalPosition++;
                }

                else
                {
                    Console.WriteLine("--------------------------------------------------------------------------------" +
                                      roomsArray[verticalPosition, horizontalPosition].roomName + "\n" + roomsArray[verticalPosition, horizontalPosition].roomDescription +
                                      "\n" + roomsArray[verticalPosition, horizontalPosition].roomExits + 


                                      "\n--------------------------------------------------------------------------------");
                    if (roomsArray[verticalPosition, horizontalPosition].roomMonsters != null)
                    {
                        Console.WriteLine("In this room, you see a: " + roomsArray[verticalPosition, horizontalPosition].roomMonsters.name);
                    }
                    else
                    {
                        Console.WriteLine("There is nothing in this room");
                    }
                }
            }

        }
    }
}
