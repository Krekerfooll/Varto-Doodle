using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ActionBaseSpawnOnPlatfowm : ActionBase
    {
        [SerializeField] private GameObject _objectPrefab;

        public override void ExecuteInternal()
        {
            SpawnOnPlatform();
        }

        public void SpawnOnPlatform()
        {
            Instantiate(_objectPrefab, transform.position, Quaternion.identity, this.transform);
        }
    }
}