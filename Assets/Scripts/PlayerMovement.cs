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
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Create a Bullet");
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = shootPoint.transform.position;
            Destroy(newBullet, 1f);
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision with Medikit
        if(collision.gameObject.tag == "MediKit")
        {
            if(maxHealth <= 100)
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
        SceneManager.LoadScene(0);
    }
}
