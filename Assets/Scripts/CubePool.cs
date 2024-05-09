using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _container;

    private Queue<Cube> _cubes;

    private void Awake()
    {
        _cubes = new Queue<Cube>();
    }

    public void PutCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.parent = _container;
        _cubes.Enqueue(cube);
    }

    public Cube GetCube()
    {
        if (_cubes.Count == 0)
        {
            Cube cube = Instantiate(_cubePrefab);
            cube.Timer.Init(this);
            return cube;
        }

        return _cubes.Dequeue();
    }
}
