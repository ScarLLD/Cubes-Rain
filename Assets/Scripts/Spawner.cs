
using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _objectParent;

    public event Action ObjectSpawned;

    protected void Spawn() { }

}
