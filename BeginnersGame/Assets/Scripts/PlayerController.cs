using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;


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

    }
}