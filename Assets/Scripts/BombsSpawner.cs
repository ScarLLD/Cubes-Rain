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
        Bomb bomb = _bombPool.GetBomb(cube.Timer.GetLifeTime);
        bomb.transform.position = cube.transform.position;
        bomb.gameObject.SetActive(true);
    }
}
