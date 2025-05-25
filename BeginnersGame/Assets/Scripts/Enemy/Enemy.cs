using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 50.0f;
    public float speed;
    public float Health
    {
        get { return health; }
    }

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float ratio)
    {
        health -= (int)(health * ratio);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        EventManager.RunEnemyDieEvent();
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            coll.gameObject.SetActive(false);
        }
    }

    public virtual void Move()
    {

    }


}
