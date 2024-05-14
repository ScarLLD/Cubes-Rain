using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ExplosionSummoner))]
public class Bomb : MonoBehaviour
{
    private ExplosionSummoner _explosionSummoner;
    private BombPool _bombPool;
    private Renderer _renderer;
    private float _alphaTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _explosionSummoner = GetComponent<ExplosionSummoner>();
    }

    private void OnEnable()
    {
        _renderer.material.color = Color.black;
        StartCoroutine(Colorize());
    }

    public void Init(BombPool bombPool)
    {
        _bombPool = bombPool;
    }

    public void SetAlphaTime(float alphaTime)
    {
        _alphaTime = alphaTime;
    }

    private IEnumerator Colorize()
    {
        float _time = 0;

        while (_renderer.material.color != Color.black.WithAlpha(0f))
        {
            _renderer.material.color = Color.Lerp(Color.black, Color.black.WithAlpha(0f), _time / _alphaTime);
            _time += Time.deltaTime;

            yield return null;
        }

        _explosionSummoner.SummonExplosion(transform.position);
        _bombPool.PutBomb(this);
    }
}
