using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Objects
{
    public class ObjectSpawner : ActionBase
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject[] _prefabsVariants;
        [SerializeField] private int _chanceToSpawnObject;

        protected override void ExecuteInternal()
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