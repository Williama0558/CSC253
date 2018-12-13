using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public class Potions : BaseItem
    {
        // Fields for the Potions class
        private int _recoveryValue;

        public Potions() : base()
        {
            // No arg constructor
            _recoveryValue = 0;
        }

        public Potions(string name, string description, int recoveryValue) : base(name, description)
        {
            // Constructor that takes arguments for each field
            _recoveryValue = recoveryValue;
        }

        public int recoveryValue
        {
            get { return _recoveryValue; }
            set { _recoveryValue = value; }
        }

    }
}
