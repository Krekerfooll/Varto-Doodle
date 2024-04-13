using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public abstract class BuffBase : MonoBehaviour
    {
        private void Awake()
        {
            ApplyBuff();
        }
        protected abstract void ApplyBuff();
    }
}
