using UnityEngine;

public class EverytimeObjects : Viewer
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.Spawned += ChangeCount;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= ChangeCount;
    }

    protected override void ViewCount(int count)
    {
        _text.text = count.ToString();
    }

    private void ChangeCount()
    {
        ViewCount(_spawner.SpawnedObjectsCount);
    }
}
