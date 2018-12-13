using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public abstract class Entities
    {
        private string _name;
        private int _health;
        private int _agility;
        private int _armorValue;

        public Entities()
        {
            // No arg constructor

            _name = "";
            _health = 0;
            _agility = 0;
            _armorValue = 0;
        }

        public Entities(string name, int health, int agility, int armorValue)
        {
            // Constructor that takes arguments for each field

            _name = name;
            _health = health;
            _agility = agility;
            _armorValue = armorValue;
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int agility
        {
            get { return _agility; }
            set { _agility = value; }
        }

        public int armorValue
        {
            get { return _armorValue; }
            set { _armorValue = value; }
        }
    }
}
