using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [Space]
    public float health;

    [Space]
    public int pointsToGive;

    [Space]
    public float xSpeed;
    public float ySpeed;

    [Space]
    public int dirMove = 0;
    public int phase;

    [Space]
    public int step;

    [Space]
    public GameObject bulletPrefab;

    [Space]
    public Transform shootPoint1;
    public Transform shootPoint2;
    public Transform shootPoint3;
    public Transform shootPoint4;

    [Space]
    public float firstShot;
    public float nextShot;

    private int shootPoint;


    private void Update()
    {
        BossMove();

        Health();

        SwitchPhase();

    }

    // Boss Moves
    void BossMove()
    {
        SwitchDir();
    }

    // Boss changes Movedirection 
    void SwitchDir()
    {
        switch (dirMove)
        {

            case 0:
                ySpeed = 0;
                transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
                break;

            case 1:
                transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
                break;

            case 2:
                transform.Translate(xSpeed * Time.deltaTime, -ySpeed * Time.deltaTime, 0);
                break;

            default:
                dirMove = 0;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with PlayerBullet
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Boss1 Collsion with PlayerBullet");
            health -= FindObjectOfType<Bullet>().bulletDamage;
        }

        // Collision with BigShot
        if(collision.gameObject.tag == "BigShot")
        {
            Debug.Log("Boss1 Collision with BigShot");
            health -= FindObjectOfType<BigShot>().damage;
            Destroy(collision.gameObject);
        }

        // Collision with TripleShot
        if(collision.gameObject.tag == "TripleShot")
        {
            Debug.Log("Boss1 Collision with tripleShot");
            health -= FindObjectOfType<TripleShotDamage>().damage;
            Destroy(collision.gameObject);
        }

        // Collision with Rocket
        if(collision.gameObject.tag == "Rocket")
        {
            Debug.Log("Boss1 Collision with Rocket");
            health -= FindObjectOfType<Rocket>().damage;
            Destroy(collision.gameObject);
        }
    }

    // Healthsystem
    void Health()
    {
        HealthDown();

        if (health <= 0)
        {
            health = 0;
            if(health == 0)
            {
                Die();
            }
        }
    }

    // By Healthsystem switch to another Phase and step
    void HealthDown()
    {
        switch (health)
        {
            case 500:
                phase = 1;
                step = 0;
                break;

            case 450:
                phase = 1;
                step = 1;
                break;

            case 400:
                phase = 1;
                step = 2;
                break;

            case 350:
                phase = 2;
                step = 0;
                break;

            case 300:
                phase = 2;
                step = 1;
                break;

            case 250:
                phase = 2;
                step = 2;
                break;

            case 200:
                phase = 3;
                step = 0;
                break;

            case 150:
                phase = 3;
                step = 1;
                break;

            case 100:
                phase = 3;
                step = 2;
                break;
        }
    }

    // Boss dies
    void Die()
    {
        FindObjectOfType<PlayerMovement>().points += pointsToGive;
        Destroy(gameObject);
    }

    // Switch Phase
    void SwitchPhase()
    {
        switch (phase)
        {
            case 0:
                dirMove = 0;
                break;

            case 1:
                Phase1();
                break;

            case 2:
                Phase2();
                break;

            case 3:
                Phase3();
                break;
        }
    }

    //Phase 1
    void Phase1()
    {
        Shoot();
        nextShot = Random.Range(0.5f, 1.4f);
        switch (step)
        {
            case 0:
                dirMove = 1;
                ySpeed = 3.2f;
                break;
                
                
            case 1:
                dirMove = 2;
                ySpeed = 4f;
                break;

            case 2:
                dirMove = 1;
                ySpeed = 4f;
                break;
        }
    }

    // Phase 2
    void Phase2()
    {
        Shoot();
        nextShot = Random.Range(0.3f, 1.1f);
        switch (step)
        {
            case 0:
                dirMove = 0;
                break;

            case 1:
                dirMove = 1;
                ySpeed = 2.5f;
                break;

            case 2:
                dirMove = 0;
                break;
        }
    }
    
    //Phase 3
    void Phase3()
    {
        Shoot();
        nextShot = Random.Range(0.2f, 0.8f);
        switch (step)
        {
            case 0:
                dirMove = 2;
                ySpeed = 3f;
                break;

            case 1:
                dirMove = 2;
                ySpeed = 3.7f;
                break;

            case 2:
                dirMove = 0;
                break;
        }
    }

    // Switch ShootPoint and create Bullet
    void SwitchShootPoint()
    {
        shootPoint = Random.Range(0, 5);

        switch (shootPoint)
        {
            case 0:
                GameObject newBullet = Instantiate(bulletPrefab);
                newBullet.transform.position = shootPoint1.transform.position;
                Destroy(newBullet, 2.5f);
                firstShot = nextShot;
                break;

            case 1:
                GameObject newBullet1 = Instantiate(bulletPrefab);
                newBullet1.transform.position = shootPoint2.transform.position;
                Destroy(newBullet1, 2.5f);
                firstShot = nextShot;
                break;

            case 2:
                GameObject newBullet2 = Instantiate(bulletPrefab);
                newBullet2.transform.position = shootPoint3.transform.position;
                Destroy(newBullet2, 2.5f);
                firstShot = nextShot;
                break;

            case 3:
                GameObject newBullet3 = Instantiate(bulletPrefab);
                newBullet3.transform.position = shootPoint4.transform.position;
                Destroy(newBullet3, 2.5f);
                firstShot = nextShot;
                break;

            case 4:
                GameObject newBullet4 = Instantiate(bulletPrefab);
                newBullet4.transform.position = shootPoint1.transform.position;
                Destroy(newBullet4, 2.5f);

                GameObject newBullet5 = Instantiate(bulletPrefab);
                newBullet5.transform.position = shootPoint2.transform.position;
                Destroy(newBullet5, 2.5f);

                GameObject newBullet6 = Instantiate(bulletPrefab);
                newBullet6.transform.position = shootPoint3.transform.position;
                Destroy(newBullet6, 2.5f);

                GameObject newBullet7 = Instantiate(bulletPrefab);
                newBullet7.transform.position = shootPoint4.transform.position;
                Destroy(newBullet7, 2.5f);
                break;
        }
    }

    // Boss shoots
    void Shoot()
    {
        TimeToShoot();
        if (firstShot == 0)
        {
            SwitchShootPoint();
        }
        
    }

    // Time to reload shot
    void TimeToShoot()
    {
        if (firstShot > 0)
        {
            firstShot -= 1 * Time.deltaTime;
            if(firstShot <= 0)
            {
                firstShot = 0;
            }
        }
    }
}
