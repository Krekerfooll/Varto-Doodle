using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_SpawnObjectAction : OI_ActionBase
    {
        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] private Transform spawnTransform;
        [SerializeField] public Transform spawnPlaceholder;
        protected override void ExecuteInternal()
        {
            Instantiate(objectToSpawn, spawnTransform.position, Quaternion.identity, spawnPlaceholder);
        }
    }
}

