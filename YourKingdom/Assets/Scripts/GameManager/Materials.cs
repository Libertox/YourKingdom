using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    [System.Serializable]
    public struct Materials
    {
        public int wood;
        public int stone;
        public int grain;

        public Materials(int wood, int stone, int grain)
        {
            this.wood = wood;
            this.stone = stone;
            this.grain = grain;
        }

        public static Materials operator +(Materials resource1, Materials resources2)
        {
            return new Materials(resource1.wood + resources2.wood, resource1.stone + resources2.stone, resource1.grain + resources2.grain);
        }

        public static Materials operator -(Materials resource1, Materials resources2)
        {
            return new Materials(resource1.wood - resources2.wood, resource1.stone - resources2.stone, resource1.grain - resources2.grain);
        }

        public static bool operator <=(Materials resource1, Materials resources2)
        {
            if (resource1.wood <= resources2.wood && resource1.stone <= resources2.stone && resource1.grain <= resources2.grain)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(Materials resource1, Materials resources2)
        {
            if (resource1.wood >= resources2.wood && resource1.stone >= resources2.stone && resource1.grain >= resources2.grain)
            {
                return true;
            }
            return false;
        }

  
    }
}

