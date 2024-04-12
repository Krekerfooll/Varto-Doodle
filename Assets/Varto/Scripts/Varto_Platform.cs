using UnityEngine;

namespace Varto.Examples.Platforms
{
    public class Varto_Platform : MonoBehaviour
    {
        [SerializeField] protected Transform _target;
        [SerializeField] protected GameObject _collider;
<<<<<<< Updated upstream:Assets/Varto/Scripts/Varto_Platform.cs
=======
        [Space]
        [Tooltip("Is object stays active after become active ones")]
        [SerializeField] protected bool _staysActive = true;
        [Space]
        [SerializeField] protected List<Utils.PlatformBase> _executeOnCollisionActivated;
        [SerializeField] protected List<Utils.PlatformBase> _executeOnCollisionDeactivated;
>>>>>>> Stashed changes:Assets/Varto/Scripts/Platforms/Varto_Platform.cs

        protected bool _isInitiated;

        public void Init(Transform target)
        {
            _target = target;
            _isInitiated = true;
        }

        void Update()
        {
            if (_isInitiated)
            {
                OnUpdatePlatform();
            }
        }

        protected virtual void OnUpdatePlatform()
        {
            if (_target.transform.position.y > transform.position.y)
            {
                _collider.SetActive(true);
            }
            else
            {
                _collider.SetActive(false);
            }
        }
    }
}
