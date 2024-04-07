using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class Platforms : MonoBehaviour
    {
        [SerializeField] protected Transform _target;
        [SerializeField] protected GameObject _collider;

        protected bool _isInitiated;

        public void Init(Transform target)
        {
            _target = target;
            _isInitiated = true;
        }

        private void Update()
        {
            if (_isInitiated)
            {
                OnUpdatePlatform();
            }
        }

        protected virtual void OnUpdatePlatform()
        {
            if (_target.transform.position.y >= transform.position.y)
            {
                _collider.SetActive(true);
            }
            else
            {
                _collider.SetActive(true); // !!! debug! set to false!
            }
        }
    }
}
