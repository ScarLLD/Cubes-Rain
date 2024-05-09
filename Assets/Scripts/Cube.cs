using UnityEngine;

[RequireComponent(typeof(DeathTimer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Material _material;

    private bool _isTouched;
    private Renderer _renderer;

    public DeathTimer Timer { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Timer = GetComponent<DeathTimer>();
    }

    private void OnEnable()
    {
        _renderer.material = _material;
        _isTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTouched == false && collision.gameObject.TryGetComponent(out Ground ground))
        {
            Timer.StartWaiting(this);
            _renderer.material.color = Random.ColorHSV();
            _isTouched = true;
        }
    }
}