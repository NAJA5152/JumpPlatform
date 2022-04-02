using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{
    public enum collectionName
    {
        apple,
        pineapple,
        strawberry,
        banana
    }
    public collectionName collect;
    public int score;
    public GameObject collectEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            AudioManager.PlayCollectAudio();
            GameManager._collectionScore += score;
            if (collect == collectionName.apple)
            {
                GameManager._appleNum++;
            }
            if (collect == collectionName.pineapple)
            {
                GameManager._pineappleNum++;
            }
            if (collect == collectionName.strawberry)
            {
                GameManager._strawberryNum++;
            }
            if (collect == collectionName.banana)
            {
                GameManager._bananaNum++;
            }
            Destroy(gameObject);
        }
    }
}
