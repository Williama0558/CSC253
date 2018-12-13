using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class MonsterGeneration
    {
        public static List<Monster> monsterList = SqliteDataAccess.loadMobs();
        public static List<Monster> createMonsters()
        {
            // Will look for the correct text file and will creates monster objects using that information.
            Monster goblin = new Monster(monsterList[0].name, monsterList[0].health, monsterList[0].agility, monsterList[0].armorValue, monsterList[0].description);
            Monster spider = new Monster(monsterList[1].name, monsterList[1].health, monsterList[1].agility, monsterList[1].armorValue, monsterList[1].description);
            Monster servant = new Monster(monsterList[2].name, monsterList[2].health, monsterList[2].agility, monsterList[2].armorValue, monsterList[2].description);
            Monster rat = new Monster(monsterList[3].name, monsterList[3].health, monsterList[3].agility, monsterList[3].armorValue, monsterList[3].description);
            Monster armor = new Monster(monsterList[4].name, monsterList[4].health, monsterList[4].agility, monsterList[4].armorValue, monsterList[4].description);
            Monster Bool = new Monster(monsterList[5].name, monsterList[5].health, monsterList[5].agility, monsterList[5].armorValue, monsterList[5].description);

            // Returns a list of mobs created from this method
            List < Monster > mobList = new List<Monster> { goblin, spider, servant, rat, armor, Bool };
            return mobList;
        }
    }
}
