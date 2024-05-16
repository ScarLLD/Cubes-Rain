using UnityEngine;

public class ActiveObjects : Viewer
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private BombPool _bombPool;

    private void OnEnable()
    {
        _cubePool.CountChanged += ChangeCount;
        _bombPool.CountChanged += ChangeCount;
    }

    private void OnDisable()
    {
        _cubePool.CountChanged -= ChangeCount;
        _bombPool.CountChanged -= ChangeCount;
    }
    
    protected override void ViewCount(int count)
    {
        _text.text = count.ToString();
    }

    private void ChangeCount()
    {
        ViewCount(_cubePool.ObjectsCount + _bombPool.ObjectsCount);
    }
}
