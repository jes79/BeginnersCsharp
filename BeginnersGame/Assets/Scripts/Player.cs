using UnityEngine;

public class Player : MonoBehaviour
{
    float health = 100.0f;

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Debug.Log("health : " + health);
            Destroy(coll.gameObject);
        }
    }
}
