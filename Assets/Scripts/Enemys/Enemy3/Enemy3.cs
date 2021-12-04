using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [Space]
    public float health;
    [Space]
    public int pointsToGive;

    [Space]
    public float xSpeed;
    public float ySpeed;

    [Space]
    public float dirTime;
    public float nextDirTime;
    public int switchDir;

    [Space]
    public float firstShot;
    public float nextShot;

    [Space]
    public GameObject bulletPrefab;
    public Transform shootPoint;

    

    void Update()
    {
        EnemyMove();

        Health();

        Shoot();
    }

    // Enemy moves in random direction if time is zero
    void EnemyMove()
    {
        TimerMove();
        
        ChangeDirection();

        if(dirTime == 0)
        {
            switchDir = Random.Range(0, 4);
            dirTime = nextDirTime;
        }
    }

    // Timer for switch direction
    void TimerMove()
    {
        if(dirTime > 0)
        {
            dirTime -= 1 * Time.deltaTime;

            if (dirTime <= 0)
            {
                dirTime = 0;
            }
        }
        
    }

    // switch to another direction
    void ChangeDirection()
    {
        switch (switchDir)
        {
            case 0:
                Debug.Log("Enemy3 Direction Case 0");
                transform.Translate(xSpeed * Time.deltaTime, 0, 0);
                break;

            case 1:
                Debug.Log("Enemy3 Direction Case 1");
                transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
                break;

            case 2:
                Debug.Log("Enemy3 Direction Case 2");
                transform.Translate(xSpeed * Time.deltaTime, -ySpeed * Time.deltaTime, 0);
                break;

            default:
                Debug.Log("Enemy3 Direction default");
                switchDir = 0;
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with PlayerBullet
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy3 Collision with PlayerBullet");
            health -= FindObjectOfType<Bullet>().bulletDamage;
        }

        // Collision with BigShot
        if (collision.gameObject.tag == "BigShot")
        {
            Debug.Log("Enemy3 Collision with BigShot");
            health -= FindObjectOfType<BigShot>().damage;
        }

        // Collision with TripleShot
        if (collision.gameObject.tag == "TripleShot")
        {
            Debug.Log("Enemy3 Collision with TripleShot");
            health -= FindObjectOfType<TripleShotDamage>().damage;
        }

        // Collision with PlayerRocket
        if (collision.gameObject.tag == "Rocket")
        {
            Debug.Log("Enemy3 Collision with Rocket");
            health -= FindObjectOfType<Rocket>().damage;
        }
    }

    //Healthsystem
    void Health()
    {
        if (health <= 0)
        {
            health = 0;
            FindObjectOfType<PlayerMovement>().points += pointsToGive;
            Die();
        }
    }

    //Enemy dies
    void Die()
    {
        Destroy(gameObject);
    }

    //Time to shoot
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

    //Enemy shoot
    void Shoot()
    {
        TimeToShoot();

        if (firstShot == 0)
        {
            Debug.Log("Enemy3 shoots");
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = shootPoint.transform.position;
            Destroy(newBullet, 1.9f);
            firstShot = nextShot;
        }
    }
}
