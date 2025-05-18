using UnityEngine;

public class Enemy1 : Enemy
{
    public override void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
    }
}
