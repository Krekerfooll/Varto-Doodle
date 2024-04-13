using UnityEngine;

namespace Varto.ScriptsVarto.Utils
{
    public class Varto_ObjectSpawner : Varto_ActionBase
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject[] _prefabsVariants;

        protected override void ExecuteInternal()
        {
            var randomObject = _prefabsVariants[Random.Range(0, _prefabsVariants.Length)];
            Instantiate (randomObject, _spawnPoint);
        }
    }
}