using System;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public int SpawnedObjectsCount { get; private set; }

    public event Action Spawned;

    protected void IncreaseSpawnedObject()
    {
        SpawnedObjectsCount++;
        Spawned?.Invoke();
    }
}
