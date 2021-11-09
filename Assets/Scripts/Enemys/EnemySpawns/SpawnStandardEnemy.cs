using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStandardEnemy : MonoBehaviour
{
    [Space]
    public GameObject standardEnemyPrefab;

    [Space]
    public float firstSpawn;
    public float nextSpawn;
    [Space]
    public int maxEnemys;

    private int enemys = 0;


    private void Update()
    {
        Spawn();

        Die();
    }

    void Timer()
    {
        // Timer for Creating Enemys
        if (firstSpawn > 0)
        {
            firstSpawn -= 1 *Time.deltaTime;

            if(firstSpawn <= 0)
            {
                firstSpawn = 0;
            }
        }
    }

    // Enemy will Create
    void Spawn()
    {
        Timer();
        
        if(firstSpawn == 0)
        {
            GameObject newEnemy = Instantiate(standardEnemyPrefab);
            newEnemy.transform.position = gameObject.transform.position;
            firstSpawn = nextSpawn;
            enemys++;
        }
    }

    void Die()
    {
        if (enemys == maxEnemys)
        {
            Destroy(gameObject);
        }
    }
}
