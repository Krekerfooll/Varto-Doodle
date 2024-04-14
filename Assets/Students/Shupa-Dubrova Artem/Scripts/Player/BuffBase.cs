using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public abstract class BuffBase : MonoBehaviour
    {
        [SerializeField] private string _onTriggerEnterWith;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"{_onTriggerEnterWith}"))
            {
                ApplyBuff();
            }
        }
        protected abstract void ApplyBuff();
    }
}
