using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [Space]
    public float health;

    [Space]
    public float xSpeed;
    public float ySpeed;

    [Space]
    public int dirMove = 0;
    public int phase;

    [Space]
    public float moveTime;
    public float newTime;

    [Space]
    public int step;

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
                ySpeed = 1.2f;
                transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
                break;

            case 2:
                ySpeed = 1.2f;
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
    }

    // Healthsystem
    void Health()
    {
        if( health <= 450)
        {
            phase = 1;
            step = 0;
        }
        else if(health <= 400)
        {
            phase = 1;
            step = 1;
        }
        else if (health <= 0)
        {
            health = 0;
            if(health == 0)
            {
                Die();
            }
        }
    }

    // Boss dies
    void Die()
    {
        Destroy(gameObject);
    }

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
        }
    }

    void Timer()
    {
        
        if(moveTime > 0)
        {
            moveTime -= 1 * Time.deltaTime;
            if(moveTime <= 0)
            {
                moveTime = 0;
            }
        }
    }

    void Phase1()
    {
        Timer();

        switch (step)
        {
            case 0:
                
                if(moveTime == 0)
                {
                    dirMove = 0;
                }
                else if (moveTime > 0)
                {
                    dirMove = 1;
                }
                break;

            case 1:
                
                if(moveTime <= 0)
                {
                    dirMove = 0;
                }
                else if( moveTime > 0)
                {
                    dirMove = 2;
                }
                break;
        }
    }
}
