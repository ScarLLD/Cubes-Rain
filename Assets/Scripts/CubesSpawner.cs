using System.Collections;
using UnityEngine;

public class CubesSpawner : Spawner
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private PositionRandomizer _positionRandomizer;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _time;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_time);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        bool isWork = true;

        while (isWork)
        {
            Cube cube = _cubePool.GetCube();
            cube.gameObject.SetActive(true);
            cube.transform.position = _positionRandomizer.GetPosition();
            cube.transform.parent = _parent;

            IncreaseSpawnedObject();

            yield return _wait;
        }
    }
}
