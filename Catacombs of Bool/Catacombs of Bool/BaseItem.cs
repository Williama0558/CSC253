using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public abstract class BaseItem : IItems
    {
        private string _name;
        private string _description;

        public BaseItem()
        {
            // No arg constructor

            _name = "";
            _description = "";
        }

        public BaseItem(string name, string description)
        {
            // Constructor that takes arguments for each field

            _name = name;
            _description = description;
        }


        // Methods that get and set information for the fields of the class

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
