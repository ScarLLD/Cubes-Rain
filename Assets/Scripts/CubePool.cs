using System;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : Pool
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _container;

    private Queue<Cube> _cubes;

    public event Action<Cube> Puted;

    private void Awake()
    {
        _cubes = new Queue<Cube>();
    }

    public void PutCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.parent = _container;
        _cubes.Enqueue(cube);

        Puted?.Invoke(cube);
        DecreaseSpawnedObject();
    }

    public Cube GetCube()
    {
        if (_cubes.Count == 0)
        {
            Cube cube = Instantiate(_cubePrefab);
            cube.Timer.Init(this);
            IncreaseSpawnedObject();

            return cube;
        }

        IncreaseSpawnedObject();

        return _cubes.Dequeue();
    }
}
