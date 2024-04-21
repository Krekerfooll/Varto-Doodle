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
        [SerializeField] private bool _paralax;
        [SerializeField] private float _paralaxValue;
        private float _startPos;

        private void Awake()
        {
            if (_paralax) _startPos = _follower.position.y;
        }
        private void OnEnable()
        {
            if (_paralax) _startPos = _follower.position.y;
        }

        void Update()
        {
            if (_follower == null || _target == null) return;

            if (_stopOnHighestPosition && !_paralax)
            {
                if (_follower.position.y <= _target.position.y)
                    FollowTarget(_follower, _target, _smoothFollow);
            }
            else if (!_stopOnHighestPosition && !_paralax)
            {
                FollowTarget(_follower, _target, _smoothFollow);
            }
            else if (_paralax)
                FollowTargetParalax(_paralaxValue);
        }
        private void FollowTarget(Transform follower, Transform followTarget, bool useLerp)
        {
            var targetPos = new Vector3(follower.position.x, followTarget.position.y, follower.position.z);

            if (useLerp)
                follower.position = Vector3.Lerp(follower.position, targetPos, _smoothFollowValue*Time.deltaTime);
            else 
                follower.position = targetPos;
        }
        private void FollowTargetParalax(float paralaxValue)
        {
            float length = 20;
            float dist = (_target.position.y * (1 - paralaxValue));
            float posY = (_target.position.y * paralaxValue);

            _follower.position = new Vector3(_follower.position.x, _startPos + posY, _follower.position.z);

            if (dist > (_startPos + length)) _startPos += length;
        }
    }
}

