using UnityEngine;

public class Coin : Item, IEffect
{
    public override void DestroyAfterTime()
    {
        Invoke("GetOpaque", 3f);
        Invoke("DestroyThis", 5f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    public override void ApplyItem()
    {
        DestroyThis();
    }

    public void GetOpaque()
    {
        Color32 color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 50);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            ApplyItem();
        }
    }
}
