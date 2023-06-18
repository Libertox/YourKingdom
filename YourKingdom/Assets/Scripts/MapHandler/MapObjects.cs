using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.BuildingObject;

namespace Kingdom.MapHandler
{
    public class MapObjects
    {
        public List<Resource> TreeList { get; private set; }
        public List<Resource> StoneList { get; private set; }

        private Building _castle;

        public MapObjects()
        {
            TreeList = new List<Resource>();
            StoneList = new List<Resource>();
        }


        public void AddTree(Resource tree) => TreeList.Add(tree);

        public void AddStone(Resource stone) => StoneList.Add(stone);

        public Building GetCastle() => _castle;
        public void SetCastle(Building castle) => _castle = castle;

    }
}
