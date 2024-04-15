using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_FollowManager : MonoBehaviour
    {
        [Header("Follow Setup")]
        [SerializeField] private Transform _follower;
        [SerializeField] private Transform _target;
        [Space]
        [SerializeField] private bool _stopOnHighestPosition;
        [SerializeField] private bool _smoothFollow;
        [SerializeField] private float _smoothFollowValue;

        void Update()
        {
            if (_follower == null || _target == null) return;

            if (_stopOnHighestPosition)
            {
                if (_follower.position.y <= _target.position.y)
                    FollowTarget(_follower, _target, _smoothFollow);
            }
            else if (!_stopOnHighestPosition)
            {
                FollowTarget(_follower, _target, _smoothFollow);
            }
        }
        private void FollowTarget(Transform follower, Transform followTarget, bool useLerp)
        {
            var targetPos = new Vector3(follower.position.x, followTarget.position.y, follower.position.z);

            if (useLerp)
                follower.position = Vector3.Lerp(follower.position, targetPos, _smoothFollowValue*Time.deltaTime);
            else 
                follower.position = targetPos;
        }
    }
}

