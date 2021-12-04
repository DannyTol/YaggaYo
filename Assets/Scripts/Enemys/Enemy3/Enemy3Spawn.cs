using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Spawn : MonoBehaviour
{
    [Space]
    public int countEnemy;
    public int maxEnemy;

    [Space]
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;

    [Space]
    public float moveSpeed;
    public float ySpeed;

    [Space]
    public float spawnTime;
    public float nextSpawn;

    [Space]
    public bool getActive = false;

    private void Update()
    {
        GetActive();
    }

    // Timer for spawn Enemy
    void SpawnTime()
    {
        if (spawnTime > 0)
        {
            spawnTime -= 1 * Time.deltaTime;
            if(spawnTime <= 0)
            {
                spawnTime = 0;
            }
        }
    }

    // Spawn Enemy
    void Spawn()
    {
        SpawnTime();

        if (spawnTime == 0)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = gameObject.transform.position;
            countEnemy += 1;
            spawnTime = nextSpawn;
        }
    }

    //If Enemys are max moves away and destroys
    void MaxEnemy()
    {
        if(countEnemy == maxEnemy)
        {
            moveSpeed += 2;
            transform.Translate(moveSpeed * Time.deltaTime, ySpeed *Time.deltaTime, 0);
            Destroy(gameObject, 2f);
        }
        else
        {
            SpawnMoves();
        }
    }

   void SpawnMoves()
    {
        if(countEnemy < maxEnemy)
        {
            transform.Translate(moveSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
        }
    }

    void GetActive()
    {
        if(getActive == true)
        {
            MaxEnemy();

            Spawn();
        }
        else if( getActive == false)
        {
            SpawnWait();
        }
    }

    void SpawnWait()
    {
        transform.Translate(0, 0, 0);
    }
}
