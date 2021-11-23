using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Space]
    public float health;
    [Space]
    public float speed;
    [Space]
    public float damageToGive;
    [Space]
    public int pointsToGive;

    private void Awake()
    {
        // Gives Tag Enemy by awake
        gameObject.tag = "Enemy";
    }

    private void Update()
    {
        // Asteroid moves
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision with Player, asteroifd destroys and Player gets Damage
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Player");
            FindObjectOfType<PlayerMovement>().maxHealth -= damageToGive;
            Die();
        }

        //Collision with DestroyWall, Asteroid destroys
        if(collision.gameObject.tag == "DestroyWall")
        {
            Debug.Log("Asteroid collision with DestroyWall");
            Destroy(gameObject);
        }

        //Collision with PlayerBullet
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Asteroid Collision Trigger with PlayerBullet");
            health -= 15;

            Health();
        }

        //Collision with PlayerRocket
        if (collision.gameObject.tag == "Rocket")
        {
            Debug.Log("Asteroid Collision with PlayerRocket");
            health -= FindObjectOfType<Rocket>().damage;

            Health();
        }
    }

    // HealthSystem
    void Health()
    {
        if (health <= 0)
        {
            Debug.Log("Asteroid Health = 0");
            health = 0;
            GivePlayerPoints();
            Die();
        }
    }

    void Die()
    {
        // Destroy Asteroid
        Destroy(gameObject);
    }

    // Asteroid gives Points to Player
    void GivePlayerPoints()
    {
        FindObjectOfType<PlayerMovement>().points += pointsToGive;
        Debug.Log("Asteroid gives Points to Player");
    }
}
