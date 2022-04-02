using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 movement;
    public float speed_A;
    public float speed_B;
    public float speed_C;
    GameObject topLine;

    void Start()
    {
        movement.y = speed_A;
        topLine = GameObject.Find("TopLine");
    }

    void Update()
    {
        if (GameManager._surviveTime > 20 && GameManager._surviveTime < 45)
        {
            movement.y = speed_B;
        }
        if (GameManager._surviveTime > 45)
        {
            movement.y = speed_C;
        }
        PlatformMove();
    }

    void PlatformMove()
    {
        transform.position += movement * Time.deltaTime;

        if (transform.position.y > topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
