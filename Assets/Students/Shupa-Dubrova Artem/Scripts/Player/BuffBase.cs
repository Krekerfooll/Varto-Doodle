using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public abstract class BuffBase : MonoBehaviour
    {
        private void FixedUpdate()
        {
            if (IsCanBeBuffed())
            {
                ApplyBuff();
            }
    
            if (IsBuffOver())
            {
                RemoveBuff();
            }
        }

        protected abstract bool IsCanBeBuffed();
        protected abstract bool IsBuffOver();
        protected abstract void ApplyBuff();
        protected abstract void RemoveBuff();






    }
}
