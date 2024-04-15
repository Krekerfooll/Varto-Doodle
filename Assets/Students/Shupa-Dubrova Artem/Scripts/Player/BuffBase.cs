using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public abstract class BuffBase : MonoBehaviour
    {
        private void Update()
        {
            ApplyBuff();
            RemoveBuff();
        }

        protected abstract void ApplyBuff();
        protected abstract void RemoveBuff();






    }
}
