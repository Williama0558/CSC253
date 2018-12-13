using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public class Weapons : BaseItem
    {
        // Fields for the Potions class
        private string _type;
        private int _attackValue;

        public Weapons() : base()
        {
            // No arg constructor
            _type = "";
            _attackValue = 0;
        }

        public Weapons(string name, string description, string tpye, int recoveryValue) : base(name, description)
        {
            // Constructor that takes arguments for each field
            _type = type;
            _attackValue = attackValue;
        }


        // Methods that get and set information for the fields of the class
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int attackValue
        {
            get { return _attackValue; }
            set { _attackValue = value; }
        }

    }
}
