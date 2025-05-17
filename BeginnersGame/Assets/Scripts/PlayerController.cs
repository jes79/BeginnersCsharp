using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject BulletPrefab;
    public float BulletSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject Bullet = Instantiate(BulletPrefab);
                Vector3 bulletPos = transform.position;
                bulletPos.y += 0.3f * i;
                Bullet.transform.position = bulletPos;
                // Bullet.transform.position = transform.position;
                // Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * BulletSpeed * (1 + 0.1f * i));
                Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * BulletSpeed);
            }
        }
    }
}