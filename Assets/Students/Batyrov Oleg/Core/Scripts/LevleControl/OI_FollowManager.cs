using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_FollowManager : MonoBehaviour
    {
        [Header("Follow Setup")]
        [SerializeField] private Transform[] _follower;
        [SerializeField] private Transform[] _target;
        [Space]
        [SerializeField] private float _followSmooth;

        void Update()
        {
            if (_follower[0].position.y <= _target[0].position.y)
                FollowTarget(_follower[0], _target[0], true);
            FollowTarget(_follower[1], _follower[0], false);
            FollowTarget(_follower[2], _target[1], false);
        }
        private void FollowTarget(Transform follower, Transform followTarget, bool useLerp)
        {
            var targetPos = new Vector3(follower.position.x, followTarget.position.y, follower.position.z);
            if (useLerp )
                follower.position = Vector3.Lerp(follower.position, targetPos, _followSmooth*Time.deltaTime);
            else follower.position = targetPos;
        }
    }
}

