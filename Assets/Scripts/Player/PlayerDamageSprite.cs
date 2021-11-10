using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSprite : MonoBehaviour
{
    private float health;


    private void Update()
    {
        Die();
    }

    // If Player is dead Sprite is enabled
    void Die()
    {
        health = FindObjectOfType<PlayerMovement>().maxHealth;

        if(health <= 0)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.parent = FindObjectOfType<PlayerMovement>().transform;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent = FindObjectOfType<PlayerMovement>().transform;
        }
    }
}
