using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("platforms")]
    public List<GameObject> platforms_A = new List<GameObject>();
    public List<GameObject> platforms_B = new List<GameObject>();
    public List<GameObject> platforms_C = new List<GameObject>();
    public GameObject spikeBall;
    public GameObject firePlatform;

    public float spawnTime;
    public Vector2 spawnRangeLimit;
    float countTime;
    private Vector3 spawnPosition;

    [Header("Collections")]
    public List<GameObject> collections = new List<GameObject>();
    public float collectionSpawnTime;
    float collectionCountTime;
    public Vector2 collectionSpawnRange;
    private Vector3 collectionSpawnPosition;

    void Update()
    {     
        countTime += Time.deltaTime;    
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(spawnRangeLimit.x,spawnRangeLimit.y);

        collectionCountTime += Time.deltaTime;
        collectionSpawnPosition = transform.position;
        collectionSpawnPosition.x = Random.Range(collectionSpawnRange.x, collectionSpawnRange.y);

        if (countTime >= spawnTime)
        {
            LevelControl();
            countTime = 0;
        }

        if (collectionCountTime>=collectionSpawnTime)
        {
            CreateCollecion();
            collectionCountTime = 0;
        }
    }

    void CreateCollecion()
    {
        int index = Random.Range(0, collections.Count);

        GameObject newCollection = Instantiate(collections[index], collectionSpawnPosition, Quaternion.identity);
        newCollection.transform.SetParent(gameObject.transform);
    }

    void LevelControl()
    {       
        if (GameManager._surviveTime >=0&& GameManager._surviveTime<20)
        {
            CreatPlatformA();
        }
        if (GameManager._surviveTime > 20 && GameManager._surviveTime < 45)
        {
            CreatPlatformB();
        }
        if (GameManager._surviveTime > 45)
        {
            CreatPlatformC();
        }
    }


    void CreatPlatformA()
    {
        int index = Random.Range(0, platforms_A.Count);

       GameObject newPlatform= Instantiate(platforms_A[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(gameObject.transform);
    }

    void CreatPlatformB()
    {
        int index = Random.Range(0, platforms_B.Count);

        GameObject newPlatform = Instantiate(platforms_B[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(gameObject.transform);
    }

    void CreatPlatformC()
    {
        int index = Random.Range(0, platforms_C.Count);

        GameObject newPlatform = Instantiate(platforms_C[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(gameObject.transform);
    }
}
