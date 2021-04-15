using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemieSpawner : MonoBehaviour
{
    public static EnemieSpawner enemieSpawner;
    public GameObject[] enemies;
    public GameObject followCamera;
    public float spawnRate = 2.0f;

    float nextSpawn = 0.0f;
    float spawnX;
    Vector2 whereToSpawn;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if (enemieSpawner == null)
        {
            enemieSpawner = this;
        }
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
            if (currentScene.name == "Escena2")
            {
                Instantiate(enemies[1], whereToSpawn, Quaternion.identity);
            }
            else
            {
                Instantiate(enemies[0], whereToSpawn, Quaternion.identity);

            }
        }
    }
}
