using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlatformSpawnCollectable : OI_ActionBase
    {
        [SerializeField] public OI_GameData gameData;
        [SerializeField] private GameObject[] _spawnObject;
        [SerializeField] private Transform _spawnPos;
        [SerializeField][Range(0,50)] private int _spawnRate;

        protected override void ExecuteInternal()
        {
            int chanceToSpawn = Random.Range(0, 100);
            if (chanceToSpawn <= _spawnRate)
            {
                int objectID = Random.Range(0, _spawnObject.Length);
                var spawnObject = _spawnObject[objectID].GetComponent<OI_CollectableCore>();
                var placeholder = gameData.collectablePlaceholder.transform;
                var spawnPos = _spawnPos.position;

                Instantiate(spawnObject, spawnPos, Quaternion.identity, placeholder).Init(gameData);
            }
        }
    }
}

