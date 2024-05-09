using System.Collections;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private int _maxLifeTime;
    [SerializeField] private int _minLifeTime;

    private CubePool _cubePool;
    private WaitForSeconds _wait;

    public void Init(CubePool cubePool)
    {
        _cubePool = cubePool;
    }

    public void StartWaiting(Cube cube)
    {
        StartCoroutine(Wait(cube));
    }

    private IEnumerator Wait(Cube cube)
    {
        bool isWork = true;

        int lifeTime = Random.Range(_minLifeTime, _maxLifeTime);

        _wait = new WaitForSeconds(lifeTime);

        while (isWork)
        {
            yield return _wait;
            _cubePool.PutCube(cube);
        }
    }
}
