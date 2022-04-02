using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAnim : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("fan_run");
        }
    }


}
