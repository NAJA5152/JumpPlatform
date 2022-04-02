using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnimCtrl : MonoBehaviour
{
    public  Material[] mats;
    MeshRenderer rd;
    Material bgMat;
    Vector2 movement;
    float count;
    public Vector2 speed;

    void Start()
    {
        bgMat = GetComponent<Renderer>().material;
        rd = GetComponent<MeshRenderer>();
        
    }

   
    void Update()
    {
        count += Time.deltaTime;
        if (count > 10&&count<20)
        {
           rd.materials[0].CopyPropertiesFromMaterial(mats[0]);
        }
        if (count > 20 && count < 30)
        {
            rd.materials[0].CopyPropertiesFromMaterial(mats[1]);
        }
        if (count > 30 && count < 40)
        {
            rd.materials[0].CopyPropertiesFromMaterial(mats[2]);
        }
        if (count > 40 && count < 50)
        {
            rd.materials[0].CopyPropertiesFromMaterial(mats[3]);
        }
        if (count > 50)
        {
            rd.materials[0].CopyPropertiesFromMaterial(mats[4]);
        }


        movement += speed * Time.deltaTime;
        bgMat.mainTextureOffset = movement;             
    }
}
