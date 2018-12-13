using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class CharacterCreation
    {
        enum Classes { Warrior, Mage, Paladin, Rogue }
        enum Races { Human, Dwarf, Elf, Gnome }

        public static Player player = new Player();
        public static Potions[] potionsArray = PotionGeneration.createPotions();
        public static List<Rooms> roomList = SqliteDataAccess.loadRooms();
        public static Weapons[] weaponsArray = WeaponGeneration.createWeapons();

        public static Player createCharacter()
        {
            // Calls various methods to gather information on the player's character
            bool saveGame = true;
            bool loadGame = false;
            getCharacterName();
            getPlayerPassword();
            getPlayerClass();
            getPlayerRace();
            SqliteDataAccess.createPlayer(player);
            storePlayerInfo(saveGame, loadGame);
            return player;
        }

        public static void getCharacterName()
        {
            // Method for creating the player character's name
            Console.WriteLine("What is your character's name?");
            string playerName = Console.ReadLine();
            player.name = playerName;
        }

        public static void getPlayerPassword()
        {
            // Method for creating the player's password

            // Variables for holding the amount of characters that appear in a player's password
            int numberOfUppercaseLetters = 0;
            int numberOfLowercaseLetters = 0;
            int numberOfSpecialCharacters = 0;
            string playerPassword;
            Console.WriteLine("Please enter in a password to make sure only you can access your file. It must have: 1 uppercase, lowercase, and special character: ");
            playerPassword = Console.ReadLine();

            // Checks the characters in the password to see if the string fits the criteria.
            for (int index = 0; index < playerPassword.Length; index++)
            {
                char letter = playerPassword[index];
                if (char.IsUpper(letter))
                {
                    numberOfUppercaseLetters += 1;
                }
                else if (char.IsLower(letter))
                {
                    numberOfLowercaseLetters += 1;
                }
                else if (!char.IsLetterOrDigit(letter))
                {
                    numberOfSpecialCharacters += 1;
                }
            }
            // Password must not be 0 for any of these in order to create a proper password
            if (numberOfLowercaseLetters != 0 && numberOfUppercaseLetters != 0 && numberOfSpecialCharacters != 0)
            {
                player.password = playerPassword;
            }

            else
            {
                Console.WriteLine("Invalid password entered, please try again.");
                playerPassword = "";
                getPlayerPassword();
            }

        }

        public static void getPlayerClass()
        {
            // This method uses enumerators to check what option the user entered in and sees if it is allowed.
            Console.WriteLine("\n\nPlease enter in the number of the class you want to be: ");
            Console.WriteLine("0.\t\tWarrior");
            Console.WriteLine("1.\t\tMage");
            Console.WriteLine("2.\t\tPaladin");
            Console.WriteLine("3.\t\tRogue");

            string playerClass;
            string userChoice = Console.ReadLine();
            int classChoice = 0;

            if(Int32.TryParse(userChoice, out classChoice))
            {
                if (classChoice == (int)Classes.Warrior)
                {
                    Classes warrior = Classes.Warrior;
                    playerClass = warrior.ToString();
                    player.playerClass = playerClass;
                    player.armorValue = 6;
                    player.playerInventory.Add(new Potions(potionsArray[0].name, potionsArray[0].description, potionsArray[0].recoveryValue));
                    player.baseDamage = weaponsArray[3].attackValue;
                }
                
                else if (classChoice == (int)Classes.Mage)
                {
                    Classes mage = Classes.Mage;
                    playerClass = mage.ToString();
                    player.playerClass = playerClass;
                    player.armorValue = 3;
                    player.baseDamage = weaponsArray[2].attackValue;
                }

                else if (classChoice == (int)Classes.Paladin)
                {
                    Classes paladin = Classes.Paladin;
                    playerClass = paladin.ToString();
                    player.playerClass = playerClass;
                    player.armorValue = 7;
                    player.baseDamage = weaponsArray[0].attackValue;
                }

                else if (classChoice == (int)Classes.Rogue)
                {
                    Classes rogue = Classes.Rogue;
                    playerClass = rogue.ToString();
                    player.playerClass = playerClass;
                    player.armorValue = 4;
                    player.baseDamage = weaponsArray[1].attackValue;
                }

                else
                {
                    Console.WriteLine("Invalid input entered, please try again.");
                    getPlayerClass();
                }
            }

            else
            {
                Console.WriteLine("Invalid input entered, please try again.");
                getPlayerClass();
            }
        }

        public static void getPlayerRace()
        {
            // This method uses enumerators to check what option the user entered in and sees if it is allowed.
            Console.WriteLine("\n\nPlease enter in the number of the race you want to be: ");
            Console.WriteLine("0.\t\tHuman");
            Console.WriteLine("1.\t\tDwarf");
            Console.WriteLine("2.\t\tElf");
            Console.WriteLine("3.\t\tGnome");

            string playerRace;
            string userChoice = Console.ReadLine();
            int raceChoice = 0;

            if (Int32.TryParse(userChoice, out raceChoice))
            {
                if (raceChoice == (int)Races.Human)
                {
                    Races human = Races.Human;
                    playerRace = human.ToString();
                    player.playerRace = playerRace;
                    player.health = 50;
                    player.agility = 5;
                }

                else if (raceChoice == (int)Races.Dwarf)
                {
                    Races dwarf = Races.Dwarf;
                    playerRace = dwarf.ToString();
                    player.playerRace = playerRace;
                    player.health = 65;
                    player.agility = 3;
                }

                else if (raceChoice == (int)Races.Elf)
                {
                    Races elf = Races.Elf;
                    playerRace = elf.ToString();
                    player.playerRace = playerRace;
                    player.health = 55;
                    player.agility = 7;
                }

                else if (raceChoice == (int)Races.Gnome)
                {
                    Races gnome = Races.Gnome;
                    playerRace = gnome.ToString();
                    player.playerRace = playerRace;
                    player.health = 30;
                    player.agility = 9;
                }

                else
                {
                    Console.WriteLine("Invalid input entered, please try again.");
                    getPlayerRace();
                }
            }

            else
            {
                Console.WriteLine("Invalid input entered, please try again.");
                getPlayerRace();
            }
        }

        public static Player storePlayerInfo(bool saveGame, bool loadGame)
        {
            // Saves the game
            if (saveGame == true)
            {
                // Method for storing player info to use later on.
                Player playerInfo = new Player();
                playerInfo.name = player.name;
                playerInfo.password = player.password;
                playerInfo.playerClass = player.playerClass;
                playerInfo.playerRace = player.playerRace;
                playerInfo.health = player.health;
                playerInfo.agility = player.agility;
                playerInfo.armorValue = player.armorValue;
                playerInfo.playerInventory = player.playerInventory;
                return player;
            }

            // Loads the game
            else
            {
                Console.WriteLine("Please enter the name of your character: ");
                string playerName = Console.ReadLine();

                // Try-catch that will prevent the user from messing up the program by entering a name not in the database
                try
                {
                    player = SqliteDataAccess.loadPlayer(playerName);
                    Console.WriteLine("Please enter in your password to confirm it is you: ");
                    string userPassword = Console.ReadLine();
                    while (player.password != userPassword)
                    {
                        Console.WriteLine("Invalid password entered, please try again:");
                        userPassword = Console.ReadLine();
                    }
                    return player;
                }
                catch
                {
                    Console.WriteLine("File not found, aborting load...");
                    CharacterCreation.storePlayerInfo(saveGame, loadGame);
                    return player;
                }
            }
        }

        public static Player currentPlayer()
        {
            Player playerInfo = new Player();
            playerInfo.name = player.name;
            playerInfo.password = player.password;
            playerInfo.playerClass = player.playerClass;
            playerInfo.playerRace = player.playerRace;
            playerInfo.health = player.health;
            playerInfo.agility = player.agility;
            playerInfo.armorValue = player.armorValue;
            playerInfo.playerInventory = player.playerInventory;
            return playerInfo;
        }
    }
}
