using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class Platforms : MonoBehaviour
    {
        [SerializeField] protected Transform _target;
        [SerializeField] protected GameObject _collider;

        public void Init(Transform target)
        {
            _target = target;
        }
    }
}
