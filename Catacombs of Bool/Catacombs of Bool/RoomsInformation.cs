using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class RoomsInformation
    {
        public static List<Monster> mobList = MonsterGeneration.createMonsters();
        public static List<Rooms> roomList = SqliteDataAccess.loadRooms();


        public static Rooms[,] createRoomsArray()
        {
            // Method that reads info from a database and then stores it in Room objects
            Rooms entrance = new Rooms(roomList[0].roomName, roomList[0].roomDescription, roomList[0].roomExits, null);
            entrance.roomMonsters = new Monster(mobList[0].name, mobList[0].health, mobList[0].agility, mobList[0].armorValue, mobList[0].description);

            Rooms northHall = new Rooms(roomList[1].roomName, roomList[1].roomDescription, roomList[1].roomExits, null);
            northHall.roomMonsters = new Monster(mobList[0].name, mobList[0].health, mobList[0].agility, mobList[0].armorValue, mobList[0].description);

            Rooms emptyRoom = new Rooms(roomList[2].roomName, roomList[2].roomDescription, roomList[2].roomExits, null);
            emptyRoom.roomMonsters = new Monster(mobList[0].name, mobList[0].health, mobList[0].agility, mobList[0].armorValue, mobList[0].description);

            Rooms treasureStash = new Rooms(roomList[3].roomName, roomList[3].roomDescription, roomList[3].roomExits, null);
            treasureStash.roomMonsters = new Monster(mobList[2].name, mobList[2].health, mobList[2].agility, mobList[2].armorValue, mobList[2].description);

            Rooms centralHall = new Rooms(roomList[4].roomName, roomList[4].roomDescription, roomList[4].roomExits, null);
            centralHall.roomMonsters = new Monster(mobList[3].name, mobList[3].health, mobList[3].agility, mobList[3].armorValue, mobList[3].description);

            Rooms armory = new Rooms(roomList[5].roomName, roomList[5].roomDescription, roomList[5].roomExits, null);
            armory.roomMonsters = new Monster(mobList[4].name, mobList[4].health, mobList[4].agility, mobList[4].armorValue, mobList[4].description);

            Rooms bossRoom = new Rooms(roomList[6].roomName, roomList[6].roomDescription, roomList[6].roomExits, null);
            bossRoom.roomMonsters = new Monster(mobList[5].name, mobList[5].health, mobList[5].agility, mobList[5].armorValue, mobList[5].description);

            Rooms southHall = new Rooms(roomList[7].roomName, roomList[7].roomDescription, roomList[7].roomExits, null);
            southHall.roomMonsters = new Monster(mobList[1].name, mobList[1].health, mobList[1].agility, mobList[1].armorValue, mobList[1].description);

            Rooms exit = new Rooms(roomList[8].roomName, roomList[8].roomDescription, roomList[8].roomExits, null);

            // Creates an array to store room class objects
            Rooms[,] roomsArray = { { entrance, northHall, emptyRoom },
                                     { treasureStash, centralHall, armory },
                                     {  bossRoom, southHall, exit} };

            return roomsArray;
        }
    }
}
