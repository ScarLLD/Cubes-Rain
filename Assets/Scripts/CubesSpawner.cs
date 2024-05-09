using System.Collections;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private Transform _cubesParent;
    [SerializeField] private PositionRandomizer _positionRandomizer;
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
            cube.transform.parent = _cubesParent;

            yield return _wait;
        }
    }
}
