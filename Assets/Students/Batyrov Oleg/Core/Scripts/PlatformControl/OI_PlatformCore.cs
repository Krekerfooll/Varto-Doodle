using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public abstract class OI_PlatformCore : MonoBehaviour
    {
        protected virtual void CollisionCheck()
        {
            transform.GetComponent<Collider2D>().enabled = false;
        }
        protected void PlatformDestroy()
        {

        }
    }
}

