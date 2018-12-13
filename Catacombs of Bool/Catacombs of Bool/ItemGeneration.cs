using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{
    class ItemGeneration
    {
        public static List<Items> itemsList = SqliteDataAccess.loadItems();
        public static List<Items> createItems()
        {
            // Will look for the correct text file and will create item objects using that information.

            Items boots = new Items(itemsList[0].name, itemsList[0].description);
            Items buckler = new Items(itemsList[1].name, itemsList[1].description);
            Items chestpiece = new Items(itemsList[2].name, itemsList[2].description);
            Items mittens = new Items(itemsList[3].name, itemsList[3].description);

            // Returns a list of mobs created from this method
            List<Items> itemList = new List<Items> { boots, buckler, chestpiece, mittens };
            return itemList;
        }
    }
}
