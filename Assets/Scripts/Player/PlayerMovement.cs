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
    public int points;
    [Space]
    public GameObject shieldPrefab;
    public Transform shieldPoint;
    [Space]
    public Rigidbody2D rb;
    [Space]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    [Space]
    public Text scoreText;
    public Text healthText;
    [Space]
    public GameObject playerDamagePrefab;
    [Space]
    public GameObject gameOverCanvasPrefab;

    
    private int gameOver = 0;
    
    


    private void Update()
    {
        Move();

        Shoot();

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
        //if(maxHealth > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Create a Bullet");
                GameObject newBullet = Instantiate(bulletPrefab);
                newBullet.transform.position = shootPoint.transform.position;
                Destroy(newBullet, 1.5f);
            }
        }
    }
    
    // Show Score and Points
    void UiText()
    {
        scoreText.text = ("Score " + points.ToString());
        healthText.text = ("Health " + maxHealth.ToString());

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with Enemy
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player collision with Enemy");
            Destroy(collision.gameObject);
            maxHealth -= 50;
            GameObject newSprite = Instantiate(playerDamagePrefab);
            newSprite.transform.position = gameObject.transform.position;
            Destroy(newSprite, 0.2f);
        }

        // Collision with EnemyBullet
        if (collision.gameObject.tag == "EnemyBullet")
        {
            GameObject newSprite = Instantiate(playerDamagePrefab);
            newSprite.transform.position = gameObject.transform.position;
            Destroy(newSprite, 0.2f);
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
            GameObject newSprite = Instantiate(playerDamagePrefab);
            newSprite.transform.position = gameObject.transform.position;
            Destroy(newSprite, 0.2f);
        }
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
        }
    }

   
}
