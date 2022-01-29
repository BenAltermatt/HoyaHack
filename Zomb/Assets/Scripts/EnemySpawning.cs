using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    
    public GameObject[] enemies;
    public float minTimeBtwSpawns;
    public float maxTimeBtwSpawns;
    public bool canSpawn;
    public float spawnTime;
    public int enemiesInRoom;

    public bool spawnerDone;
    public GameObject spawnerDoneGameObject;

    private void Start(){
        Invoke("SpawnEnemy", 0.5f);
    }

    void SpawnEnemy(){
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = SpawnPoints[index];
        float timeBtwSpans = Random.Range(minTimeBtwSpawns, maxTimeBtwSpawns);

        if(canSpawn){
            Instantiate(enemies[Random.Range(0, enemies.length)], currentPoint.transform.position, Quaternion.identity);
            enemiesInRoom++;
        }

        Invoke("SpawnEnemy", timeBtwSpans);

        if(spawnerDone){
            //up to us
            spawnerDoneGameObject.SetActive(true);
        }
    }
}
