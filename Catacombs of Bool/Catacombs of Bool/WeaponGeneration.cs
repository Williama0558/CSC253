using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class WeaponGeneration
    {
        public static List<Weapons> weaponList = SqliteDataAccess.loadWeapons();

        public static Weapons[] createWeapons()
        {
            // Will look for the correct text file and will create weapon objects using that information.
            Weapons axe = new Weapons(weaponList[0].name, weaponList[0].description, weaponList[0].type, weaponList[0].attackValue);
            Weapons mace = new Weapons(weaponList[1].name, weaponList[1].description, weaponList[1].type, weaponList[1].attackValue);
            Weapons spear = new Weapons(weaponList[2].name, weaponList[2].description, weaponList[2].type, weaponList[2].attackValue);
            Weapons sword = new Weapons(weaponList[3].name, weaponList[3].description, weaponList[3].type, weaponList[3].attackValue);

            // Returns a list of mobs created from this method
            Weapons[] weaponArray = { axe, mace, spear, sword };
            return weaponArray;
        }
    }
}
