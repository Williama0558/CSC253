using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catacombs_of_Bool
{

    public class Player : Entities
    {
        // Fields for the player class
        private int _baseDamage;
        private string _password;
        private string _playerClass;
        private string _playerRace;
        private List<BaseItem> _playerInventory;

        public Player() : base()
        {
            // No arg constructor

            _password = "";
            _playerClass = "";
            _playerRace = "";
            _playerInventory = new List<BaseItem>();
        }

        public Player(string name, int health, int agility, int armorValue, string password, string playerClass, string playerRace, int[,] playerPosition, List<BaseItem> playerInventory, int baseDamage) : 
            base(name, health, agility, armorValue)
        {
            // Constructor that takes arguments for each field
            _baseDamage = baseDamage;
            _password = password;
            _playerClass = playerClass;
            _playerRace = playerRace;
            _playerInventory = playerInventory;

        }


        // Methods that get and set information for the fields of the class

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string playerRace
        {
            get { return _playerRace; }
            set { _playerRace = value; }
        }

        public string playerClass
        {
            get { return _playerClass; }
            set { _playerClass = value; }
        }

        public List<BaseItem> playerInventory
        {
            get { return _playerInventory; }
            set { _playerInventory = value; }
        }

        public int baseDamage
        {
            get { return _baseDamage; }
            set { _baseDamage = value; }
        }

    }

}

