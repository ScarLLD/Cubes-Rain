using System.Collections.Generic;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Transform _container;

    private Queue<Bomb> _bombs;

    private void Awake()
    {
        _bombs = new Queue<Bomb>();
    }

    public void PutBomb(Bomb bomb)
    {
        bomb.gameObject.SetActive(false);
        bomb.transform.parent = _container;
        _bombs.Enqueue(bomb);
    }

    public Bomb GetBomb()
    {
        if (_bombs.Count == 0)
        {
            Bomb bomb = Instantiate(_bombPrefab);
            bomb.Init(this);
            return bomb;
        }

        return _bombs.Dequeue();
    }
}