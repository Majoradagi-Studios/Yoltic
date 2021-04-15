using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{

    public GameObject[] enemies;
    float spawnX;
    public GameObject followCamera;
    Vector2 whereToSpawn;
    public float spawnRate = 2.0f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            spawnX = followCamera.GetComponent<Transform>().transform.position.x + 8f;
            //randX = Random.Range (1,1);
            whereToSpawn = new Vector2(spawnX, transform.position.y);
            Instantiate(enemies[0], whereToSpawn, Quaternion.identity);
        }
    }
}
