using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
public Transform[] spawnPoints;
public GameObject[] enemysPrefabs;
int randomSpawnPoint;
int randomEnemy;





    // Start is called before the first frame update
    public void Start()
    {

     InvokeRepeating("SpawnEnemy",0f,10f);
       
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


       
}
}
