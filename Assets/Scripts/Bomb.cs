using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int _alphaTime;
    private Renderer _renderer;


    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(Colorize());
        Color endColor = new(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0);
        _renderer.material.color = Color.Lerp(_renderer.material.color, endColor, _alphaTime);
    }

    public void Init(int alphaTime)
    {
        _alphaTime = alphaTime;
    }

    private IEnumerator Colorize()
    {
        bool isWork = true;

        while (isWork)
        {
            //Color endColor = new(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0);

            //_renderer.material.color = Color.Lerp(_renderer.material.color, endColor, _alphaTime);

            //if (_renderer.material.color == endColor)
            //    isWork = false;

            yield return null;
        }
    }
}
