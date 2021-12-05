using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [Space]
    public float speed;
    [Space]
    public float damage;

    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    // Collision with Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("BossBullet collision with Player");
            Destroy(gameObject);
            FindObjectOfType<PlayerMovement>().maxHealth -= damage;
        }
    }

    // Collision with Playershield
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("BossBullet collision Triggerd with Shield");
            Destroy(gameObject);
        }
    }
}

