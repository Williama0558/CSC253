using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    class CurrentPlayer
    {
        public static Player getCurrentPlayer()
        {
            Player player = CharacterCreation.currentPlayer();
            return player;
        }
    }
}
