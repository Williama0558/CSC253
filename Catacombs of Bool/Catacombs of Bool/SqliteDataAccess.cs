using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public class SqliteDataAccess
    {
        public static List<Rooms> loadRooms()
        {
            // Creates a connection with the database to retrieve information from it.
            List<Rooms> roomList = new List<Rooms>();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();

                // Creates an SQL command and then specifies what that command is
                SQLiteCommand command = cnn.CreateCommand();

                command.CommandText = "select * from Rooms";

                // Allows data to be read from the database
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Creates objects using data from the database
                    Rooms room = new Rooms();
                    room.roomName = reader.GetString(1);
                    room.roomDescription = reader.GetString(2);
                    room.roomExits = reader.GetString(3);
                    room.roomMonsters = null;
                    roomList.Add(room);
                }

                reader.Close();
                cnn.Close();
                return roomList;
            }

        }

        public static List<Weapons> loadWeapons()
        {
            List<Weapons> weaponList = new List<Weapons>();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();

                SQLiteCommand command = cnn.CreateCommand();

                command.CommandText = "select * from Weapons";

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Weapons weapon = new Weapons();
                    weapon.name = reader.GetString(1);
                    weapon.description = reader.GetString(2);
                    weapon.type = reader.GetString(3);
                    weapon.attackValue = reader.GetInt32(4);
                    weaponList.Add(weapon);
                }

                reader.Close();
                cnn.Close();
                return weaponList;
            }

        }

        public static List<Monster> loadMobs()
        {
            List<Monster> mobList = new List<Monster>();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();

                SQLiteCommand command = cnn.CreateCommand();

                command.CommandText = "select * from Mobs";

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Monster mob = new Monster();
                    mob.name = reader.GetString(1);
                    mob.description = reader.GetString(2);
                    mob.health = reader.GetInt32(3);
                    mob.agility = reader.GetInt32(4);
                    mob.armorValue = reader.GetInt32(5);
                    mobList.Add(mob);
                }

                reader.Close();
                cnn.Close();
                return mobList;
            }

        }

        public static List<Items> loadItems()
        {
            List<Items> itemList = new List<Items>();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();

                SQLiteCommand command = cnn.CreateCommand();

                command.CommandText = "select * from Items";

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Items item = new Items();
                    item.name = reader.GetString(1);
                    item.description = reader.GetString(2);
                    itemList.Add(item);
                }

                reader.Close();
                cnn.Close();
                return itemList;
            }

        }

        public static List<Potions> loadPotions()
        {
            List<Potions> potionList = new List<Potions>();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();

                SQLiteCommand command = cnn.CreateCommand();

                command.CommandText = "select * from Potions";

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Potions potion = new Potions();
                    potion.name = reader.GetString(1);
                    potion.description = reader.GetString(2);
                    potion.recoveryValue = reader.GetInt32(3);
                    potionList.Add(potion);
                }

                reader.Close();
                cnn.Close();
                return potionList;
            }

        }

        public static void createPlayer(Player player)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string listOfItems = "";

                foreach (BaseItem item in player.playerInventory)
                {
                    if (item != null)
                    {
                        listOfItems += item.name + ",";
                    }
                }

                cnn.Open();

                string sql = "Insert into Player (Name, Health, Agility, ArmorValue, Password, Class, Race, Inventory) values(@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)";


                SQLiteCommand command = new SQLiteCommand(sql, cnn);
                command.Parameters.Add(new SQLiteParameter("@param1", player.name));
                command.Parameters.Add(new SQLiteParameter("@param2", player.health));
                command.Parameters.Add(new SQLiteParameter("@param3", player.agility));
                command.Parameters.Add(new SQLiteParameter("@param4", player.armorValue));
                command.Parameters.Add(new SQLiteParameter("@param5", player.password));
                command.Parameters.Add(new SQLiteParameter("@param6", player.playerClass));
                command.Parameters.Add(new SQLiteParameter("@param7", player.playerRace));
                command.Parameters.Add(new SQLiteParameter("@param8", listOfItems));
                command.ExecuteNonQuery();
            }
        }

        public static void savePlayer(Player player)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string listOfItems = "";

                // Gets the name of each item to store in the database
                foreach (BaseItem item in player.playerInventory)
                {
                    if (item != null)
                    {
                        listOfItems += item.name + ",";
                    }
                }

                string sql = "Replace into Player (Name, Health, Agility, ArmorValue, Password, Class, Race, Inventory) values(@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)";


                cnn.Open();
                // Sends the data to be stored in the database
                using (SQLiteCommand cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.Add(new SQLiteParameter("@param1", player.name));
                    cmd.Parameters.Add(new SQLiteParameter("@param2", player.health));
                    cmd.Parameters.Add(new SQLiteParameter("@param3", player.agility));
                    cmd.Parameters.Add(new SQLiteParameter("@param4", player.armorValue));
                    cmd.Parameters.Add(new SQLiteParameter("@param5", player.password));
                    cmd.Parameters.Add(new SQLiteParameter("@param6", player.playerClass));
                    cmd.Parameters.Add(new SQLiteParameter("@param7", player.playerRace));
                    cmd.Parameters.Add(new SQLiteParameter("@param8", listOfItems));
                    cmd.ExecuteNonQuery();
                }

                cnn.Close();
            }
        }

        public static Player loadPlayer(string name)
        {
            Player player = new Player();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();

                SQLiteCommand command = cnn.CreateCommand();

                // Loads the record from the database that has a matching name
                command.CommandText = "select * from Player Where Name Like @param1";
                command.Parameters.Add(new SQLiteParameter("@param1", name));

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    player.name = reader.GetString(1);
                    player.health = reader.GetInt32(2);
                    player.agility = reader.GetInt32(3);
                    player.armorValue = reader.GetInt32(4);
                    player.password = reader.GetString(5);
                    player.playerClass = reader.GetString(6);
                    player.playerRace = reader.GetString(7);

                    // Was supposed to be used for loading items from the database for the inventory, but couldn't get it to work properly
                    //player.playerInventory = reader.GetString(8);

                }

                reader.Close();
                cnn.Close();
                return player;
            }

        }


        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
