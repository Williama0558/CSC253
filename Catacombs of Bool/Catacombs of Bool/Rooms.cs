using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public class Rooms
    {
        // Fields for the Rooms class
        private string _roomName;
        private string _roomDescription;
        private string _roomExits;
        private Monster _roomMonsters;

        public Rooms()
        {
            _roomName = "";
            _roomDescription = "";
            _roomExits = "";
            _roomMonsters = null;
        }

        public Rooms(string roomName, string roomDescription, string roomExits, Monster roomMonsters)
        {
            _roomName = roomName;
            _roomDescription = roomDescription;
            _roomExits = roomExits;
            _roomMonsters = roomMonsters;
        }

        public string roomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        public string roomDescription
        {
            get { return _roomDescription; }
            set { _roomDescription = value; }
        }

        public string roomExits
        {
            get { return _roomExits; }
            set { _roomExits = value; }
        }

        public Monster roomMonsters
        {
            get { return _roomMonsters; }
            set { _roomMonsters = value; }
        }
    }

}
