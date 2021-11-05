using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [Space]
    public float health;
    [Space]
    public float speed;
    [Space]
    public int pointsToGive;
    [Space]
    public float firstShot;
    public float nextShot;
    [Space]
    public GameObject enemy2BulletPrefab;
    public Transform shootPoint1;
    public Transform shootPoint2;
    public Transform shootPoint3;
    [Space]
    public GameObject target;
    
   

    private void Awake()
    {
        speed = Random.Range(0.3f, 2f);

    }

    void Update()
    {
        Move();

        Health();

        EnemyShoot();
    }

    // Enemy moves
    void Move()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Enemy collision with Bullet
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet hits Enemy");
            health -= FindObjectOfType<Bullet>().bulletDamage;
        }

        // Enemy collision with DestroyWall
        if(collision.gameObject.tag == "DestroyWall")
        {
            Debug.Log("Enemy2 collision with DestroyWall");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy collision with Shield
        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("Enemy2 collision with Shield");
            Die();
        }
    }

    // Enemy Healthmanagment
    void Health()
    {
        if (health <= 0)
        {
            health = 0;
        }

        if (health == 0)
        {
            Die();
        }
    }

    // Enemy Death
    void Die()
    {
        Debug.Log("Enemy2 is dead");
        Destroy(gameObject);
        FindObjectOfType<PlayerMovement>().points += pointsToGive;
    }

    void Timer()
    {
        // Countdown for next Bullet
        if(firstShot > 0)
        {
            firstShot -= 1 * Time.deltaTime;
            if(firstShot <= 0)
            {
                firstShot = 0;
            }
        }
        else
        {
            firstShot = nextShot;
        }
        
               
       
    }

    // If Timer = 0 Enemy will shoot
    void EnemyShoot()
    {
        Timer();

        float distance = Vector3.Distance(FindObjectOfType<PlayerMovement>().transform.position, target.transform.position);

        if(firstShot == 0 && distance <= 50)
        {
            Debug.Log("Enemy is shooting");

            GameObject newBullet = Instantiate(enemy2BulletPrefab);
            newBullet.transform.position = shootPoint1.transform.position;
            Destroy(newBullet, 2.5f);

            GameObject newBullet2 = Instantiate(enemy2BulletPrefab);
            newBullet2.transform.position = shootPoint2.transform.position;
            Destroy(newBullet2, 2.5f);

            GameObject newBullet3 = Instantiate(enemy2BulletPrefab);
            newBullet3.transform.position = shootPoint3.transform.position;
            Destroy(newBullet3, 2.5f);
        }
        
    }
}
