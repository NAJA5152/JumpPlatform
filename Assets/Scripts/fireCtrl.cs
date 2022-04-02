using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCtrl : MonoBehaviour
{
    BoxCollider2D col;
    Animator anim;
    public float fireSpawnTime;
    public float fireLastTime;
    bool isFire;
    float fireSpawncountTime;
    float fireCDCount;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
  
    void Update()
    {
        anim.SetBool("isFire", isFire);
        Fire();
    }

    void Fire()
    {
        fireSpawncountTime += Time.deltaTime;

        if (fireSpawncountTime >= fireSpawnTime)
        {          
            col.enabled = true;
            isFire = true;          
            fireCDCount += Time.deltaTime;
        }

        if (fireCDCount >= fireLastTime)
        {
            fireCDCount = 0;
            fireSpawncountTime = 0;
            col.enabled =false;
            isFire = false;
            
        }
        
    }

   
   
}
