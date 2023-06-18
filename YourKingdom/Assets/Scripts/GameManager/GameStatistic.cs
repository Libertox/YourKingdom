using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class GameStatistic
    {
        public int DefeatedEnemy { get; private set; }
        public int LoseBuilding { get; private set; }
        public int LoseUnit { get; private set; }

        public void AddDefeatedEnemy() => DefeatedEnemy++;

        public void AddLoseBuidling() => LoseBuilding++;

        public void AddLoseUnit() => LoseUnit++;

    }
}
