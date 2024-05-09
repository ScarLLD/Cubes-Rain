using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    [SerializeField] private Vector3 _originPosition;
    [SerializeField] private float _minPos;
    [SerializeField] private float _maxPos;

    public Vector3 GetPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(_minPos, _maxPos),
            Random.Range(_minPos, _maxPos), Random.Range(_minPos, _maxPos));

        return _originPosition + randomPosition;
    }
}
