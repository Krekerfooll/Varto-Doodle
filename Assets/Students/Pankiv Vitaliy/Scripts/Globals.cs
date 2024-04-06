using UnityEngine;

namespace PVitaliy
{
    public abstract class Globals {
        public static bool IsPlayer(GameObject obj)
        {
            return obj.tag.Equals("Player");
        }
    }
}
