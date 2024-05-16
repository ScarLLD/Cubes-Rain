using System;
using UnityEngine;

public abstract class Pool : MonoBehaviour
{
    public int ObjectsCount { get; private set; }

    public event Action CountChanged;

    protected void IncreaseSpawnedObject()
    {
        ObjectsCount++;
        CountChanged?.Invoke();
    }

    protected void DecreaseSpawnedObject()
    {
        ObjectsCount--;
        CountChanged?.Invoke();
    }
}
