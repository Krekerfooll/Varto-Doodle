using UnityEngine;

public class ObjectSpawner : ActionBase
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject[] _prefabsVariants;

    protected override void ExecuteInternal()
    {
        var randomObject = _prefabsVariants[Random.Range(0, _prefabsVariants.Length)];
        Instantiate(randomObject, _spawnPoint);
    }
}
