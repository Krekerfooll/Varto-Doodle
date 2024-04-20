using UnityEngine;
using Random = UnityEngine.Random;

namespace Students.Shupa_Dubrova_Artem.Scripts.Utils
{
    public class ObjectSpawner : ActionBase
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject[] _prefabsVariants;
        [SerializeField] private int _chanceToSpawnObject;

        private void Awake()
        {
            Execute();
        }

        protected override void Execute()
        {
            var randomObject = _prefabsVariants[Random.Range(0, _prefabsVariants.Length)];
            var randomChance = Random.Range(0, 100);
            if (randomChance <= _chanceToSpawnObject)
            {
                Instantiate(randomObject, _spawnPoint);
            }
        }
        
    }
}

