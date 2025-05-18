using UnityEngine;

public class Enemy2 : Enemy
{
    public override void Move()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
    }
}
