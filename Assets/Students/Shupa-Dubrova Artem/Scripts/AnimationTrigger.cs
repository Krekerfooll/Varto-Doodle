using UnityEngine;
using UnityEngine.Events;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class AnimationTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _myEvents;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _myEvents.Invoke();
        }
    }
    
}
