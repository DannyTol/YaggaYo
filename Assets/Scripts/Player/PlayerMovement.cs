using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Space]
    public float maxHealth;
    [Space]
    public float speed;
    public float forwardSpeed;
    [Space]
    public int rockets;
    [Space]
    public int points;
    [Space]
    public GameObject shieldPrefab;
    public Transform shieldPoint;
    [Space]
    public Rigidbody2D rb;
    [Space]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public AudioSource audioShoot;
    [Space]
    public GameObject rocketPrefab;
    [Space]
    public Text scoreText;
    public Text healthText;
    public Text rocketsText;
    [Space]
    public GameObject playerDamagePrefab;
    [Space]
    public GameObject gameOverCanvasPrefab;
    [Space]
    public Canvas target1;

    [Space]
    public int gameOver = 0;


    private void Update()
    {
        Move();

        Shoot();

        ShootRocket();

        UiText();

        Health();
    }

    // Player moves
    private void Move()
    {
        transform.Translate(forwardSpeed * Time.deltaTime,0,0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    // Player shoots
    void Shoot()
    {
        if(maxHealth > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateBullet();
            }
        }
    }

    // Player create a Bullet
    void CreateBullet()
    {
        Debug.Log("Create a Bullet");
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = shootPoint.transform.position;
        audioShoot.Play();
        Destroy(newBullet, 1.5f);
    }

    // Player Shoots Rocket 
    void ShootRocket()
    {
        if (maxHealth > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (rockets > 0)
                {
                    CreateRocket();
                    rockets -= 1;
                }
                else
                {
                    Debug.Log("No Rockets");
                }
            }
        }
    }

    // Player create a Rocket
    void CreateRocket()
    {
        Debug.Log("Player Shoot Rocket");
        GameObject newRocket = Instantiate(rocketPrefab);
        newRocket.transform.position = shootPoint.transform.position;
        Destroy(newRocket, 1.5f);
    }
    
    // Show Score, Points and Rockets
    void UiText()
    {
        scoreText.text = ("Score " + points.ToString());
        healthText.text = ("Health " + maxHealth.ToString());
        rocketsText.text = ("Rockets " + rockets.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with Enemy
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player collision with Enemy");
            Destroy(collision.gameObject);
            maxHealth -= 50;

            DamageSprite();
        }

        // Collision with EnemyBullet
        if (collision.gameObject.tag == "EnemyBullet")
        {
            DamageSprite();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision with Medikit
        if (collision.gameObject.tag == "MediKit")
        {
            if (maxHealth <= 100)
            {
                Destroy(collision.gameObject);
                maxHealth += 50;
            }
        }

        //Collision with Shield
        if(collision.gameObject.tag == "ShieldItem")
        {
            Debug.Log("Player collision with Shield");
            Destroy(collision.gameObject);
            GameObject shield = Instantiate(shieldPrefab);
            shield.transform.position = shieldPoint.transform.position;
            Destroy(shield, 50f);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            DamageSprite();
        }

        // Collision with RocketItem
        if (collision.gameObject.tag == "RocketItem")
        {
            Debug.Log("Player collision with RocketItem");
            Destroy(collision.gameObject);
            rockets += 3;
        }
    }

    // Create DamageSprite
    void DamageSprite()
    {
        Debug.Log("Player creates DamageSprite");
        GameObject newSprite = Instantiate(playerDamagePrefab);
        newSprite.transform.position = gameObject.transform.position;
        Destroy(newSprite, 0.2f);
    }

    // Player Health Managment
    void Health()
    {
        if(maxHealth <= 0)
        {
            maxHealth = 0;
        }

        if (maxHealth == 0)
        {
            Die();
        }
    }

    // Player death
    void Die()
    {
        Debug.Log("Player is dead");
        
        if (gameOver <= 0)
        {
            Instantiate(gameOverCanvasPrefab);
            gameOver = 1;
            speed = 0;
            forwardSpeed = 0;
            FindObjectOfType<DestroyWall>().speed = 0;
            GetComponent<Renderer>().enabled = false;
            Destroy(target1);
        }
    }
}
