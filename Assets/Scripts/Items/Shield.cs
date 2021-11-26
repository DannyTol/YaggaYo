using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision with EnemyBullet, Bullet destroys
        if(collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
        // Collision with Enemy, enemy is dead
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    // Shield is following Player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent = collision.transform;
        }
    }
}
