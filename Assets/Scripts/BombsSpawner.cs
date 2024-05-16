using UnityEngine;

public class BombsSpawner : Spawner
{
    [SerializeField] private BombPool _bombPool;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private Transform _parent;
        
    private void OnEnable()
    {
        _cubePool.Puted += Spawn;
    }

    private void OnDisable()
    {
        _cubePool.Puted -= Spawn;
    }

    private void Spawn(Cube cube)
    {
        Bomb bomb = _bombPool.GetBomb();
        bomb.SetAlphaTime(cube.Timer.GetLifeTime);
        bomb.transform.position = cube.transform.position;
        bomb.transform.parent = _parent;
        bomb.gameObject.SetActive(true);

        IncreaseSpawnedObject();
    }
}
