using UnityEngine;

public class Coin : Item
{
    public override void DestroyAfterTime()
    {
        Invoke("Destroy", 5f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    public override void ApplyItem()
    {
        DestroyThis();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            ApplyItem();
        }
    }
}
