using UnityEngine;

namespace RomanDoliba.Utils
{
    public class ItemSpawner : ActionBase
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject[] _itemsToSpawn;
        [Tooltip("The higher value, the lower chance")]
        [SerializeField] private int _chanseToSpawn; 

        private void Awake()
        {
            Execute();
        }

        protected override void Execute()
        {
            var willSpawn = Random.Range(0, _chanseToSpawn);
            if (willSpawn == 0)
            {
                var randomItem = _itemsToSpawn[Random.Range(0, _itemsToSpawn.Length)];
                Instantiate (randomItem, _spawnPoint.transform.position, Quaternion.identity, _spawnPoint);
            }
        }
    }
}
