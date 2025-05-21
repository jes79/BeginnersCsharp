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

public interface IEffect
{
    void GetOpaque();
}

public enum Items
{
    Coin, SpeedUp, PowerUp
}

