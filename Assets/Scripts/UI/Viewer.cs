using TMPro;
using UnityEngine;

public abstract class Viewer : MonoBehaviour
{
    [SerializeField] protected TMP_Text _text;

    protected abstract void ViewCount(int count);
}
