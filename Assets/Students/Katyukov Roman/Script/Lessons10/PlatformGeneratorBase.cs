using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformGeneratorBase : MonoBehaviour
{
    protected List<GameObject> platforms = new List<GameObject>();

    protected abstract void InitGenerator();
    protected abstract bool ShouldSpawn();
    protected abstract bool ShouldDelete();
    protected abstract void SpawnPlatform();
    protected abstract void DeletePlatform();

    protected virtual void Awake()
    {
        InitGenerator();
    }

    protected virtual void Update()
    {
        if (ShouldSpawn())
        {
            SpawnPlatform();
        }
        if (ShouldDelete())
        {
            DeletePlatform();
        }
    }
}

