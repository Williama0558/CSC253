using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class PotionGeneration
    {
        public static List<Potions> potionList = SqliteDataAccess.loadPotions();

        public static Potions[] createPotions()
        {
            // Will look for the correct text file and will create potion objects using that information.
            Potions healthPotion = new Potions(potionList[0].name, potionList[0].description, potionList[0].recoveryValue);
            Potions greaterHealthPotion = new Potions(potionList[1].name, potionList[1].description, potionList[1].recoveryValue);

            // Returns a list of potions created from this method
            Potions[] potionArray = { healthPotion, greaterHealthPotion };
            return potionArray;
        }
    }
}
