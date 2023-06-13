using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
public Transform[] spawnPoints;
public GameObject[] enemysPrefabs;
int randomSpawnPoint;
int randomEnemy;



///
// Vector2 whereToSpawn;
// float nextSpawn=0.0f;
// float spawnRate=2f;
// float randx;
// public GameObject enemy;




    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",0f,5f);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        //get random spawn point
        randomSpawnPoint=Random.Range(0,spawnPoints.Length);
                //randomSpawnPoint=Random.Range(0,spawnPoints.Length);

        //get random enemy prefabs
        randomEnemy=Random.Range(0,enemysPrefabs.Length);
        //spawn it
        Instantiate(enemysPrefabs[randomEnemy],spawnPoints[randomSpawnPoint].position,Quaternion.identity);


        ///
        // if(Time.time>nextSpawn){
        //     nextSpawn=Time.time+spawnRate;
        //     randx=Random.Range(-8.4f,8.4f);
        //     whereToSpawn=new Vector2(randx,transform.position.y);
        //     Instantiate(enemy,whereToSpawn,Quaternion.identity);
        // }
    }
}
