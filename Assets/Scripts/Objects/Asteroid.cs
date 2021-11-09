using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Space]
    public float speed;
    [Space]
    public float damageToGive;

    private void Awake()
    {
        gameObject.tag = "Enemy";
    }

    private void Update()
    {
        // Asteroid moves
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        // Asteroid rotate
        transform.Rotate(0,0,speed * Time.deltaTime);
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
    }

    void Die()
    {
        // Destroy Asteroid
        Destroy(gameObject);
    }
}
