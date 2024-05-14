using System.Collections;
using UnityEngine;

public class BombsSpawner : MonoBehaviour
{
    [SerializeField] private BombPool _bombPool;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private Transform _bombsParent;

    private void OnEnable()
    {
        _cubePool.CubeTaken += Spawn;
    }

    private void OnDisable()
    {
        _cubePool.CubeTaken -= Spawn;
    }

    private void Spawn(Cube cube)
    {
        Bomb bomb = _bombPool.GetBomb();
        bomb.SetAlphaTime(cube.Timer.GetLifeTime);
        bomb.transform.position = cube.transform.position;
        bomb.transform.parent = _bombsParent;
        bomb.gameObject.SetActive(true);
    }
}
