using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void DestroyAfterTime();
    public abstract void ApplyItem();

    void Start()
    {
        DestroyAfterTime();
    }

}
