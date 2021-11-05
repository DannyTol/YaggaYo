using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : MonoBehaviour
{
    [Space]
    public float speed;
    [Space]
    public float bulletDamage;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Bullet moves to the left side
    void Move()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        // Collision with Player
        if(collision.gameObject.tag == "Player")
        {   
            Debug.Log("EnemyBullet hits Player");
            FindObjectOfType<PlayerMovement>().maxHealth -= bulletDamage;
            Destroy(gameObject);
        }

        // Collisiom with DestroyWall, Enemy is dead
        if(collision.gameObject.tag == "DestroyWall")
        {
            Destroy(gameObject);
        }
    }
}
