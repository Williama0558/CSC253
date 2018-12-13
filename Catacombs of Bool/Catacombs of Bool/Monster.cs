using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public class Monster : Entities
    {
        private string _description;

        public Monster() : base()
        {
            // Uses the no argument constructor from the base class
        }

        public Monster(string name, int health, int agility, int armorValue, string description) : base (name, health, agility, armorValue)
        {
            _description = description;
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
