using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
public Transform[] spawnPoints;
public GameObject[] enemysPrefabs;
int randomSpawnPoint;
int randomEnemy;


GameObject SpawnWolfStart;
GameObject SpawnWolfStop;

GameObject target;

    public void Start()
    {
        SpawnWolfStart=GameObject.Find("SpawnWolfStart");
        SpawnWolfStop=GameObject.Find("SpawnWolfStop");
        target=GameObject.Find("Player");
        InvokeRepeating("SpawnEnemy",0f,5f);     
    }

    void SpawnEnemy()
    {
        if (target.transform.position.x<=SpawnWolfStart.transform.position.x) {
            if (target.transform.position.x>=SpawnWolfStop.transform.position.x)  {

                //get random spawn point
                randomSpawnPoint=Random.Range(0,spawnPoints.Length);
                //get random enemy prefabs
                randomEnemy=Random.Range(0,enemysPrefabs.Length);
                //spawn it
                Instantiate(enemysPrefabs[randomEnemy],spawnPoints[randomSpawnPoint].position,Quaternion.identity);
            }
        }
    }
}