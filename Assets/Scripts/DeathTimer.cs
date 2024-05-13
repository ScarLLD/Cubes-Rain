using System.Collections;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private int _maxLifeTime;
    [SerializeField] private int _minLifeTime;

    private int _lifeTime;
    private CubePool _cubePool;
    private WaitForSeconds _wait;

    public int GetLifeTime => _lifeTime;

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

        _lifeTime = Random.Range(_minLifeTime, _maxLifeTime);

        _wait = new WaitForSeconds(_lifeTime);

        while (isWork)
        {
            yield return _wait;
            _cubePool.PutCube(cube);
        }
    }
}
