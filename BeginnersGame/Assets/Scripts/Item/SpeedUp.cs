using UnityEngine;

public class SpeedUp : Item
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
        GameObject playerObj = GameObject.Find("Player");
        PlayerController controller = playerObj.GetComponent<PlayerController>();
        controller.speed *= 1.25f;

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
