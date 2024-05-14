using UnityEngine;

public class ExplosionSummoner : MonoBehaviour
{
    [SerializeField] private float _searchRadius;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void SummonExplosion(Vector3 explosionPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _searchRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].transform.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionForce);
        }
    }
}
