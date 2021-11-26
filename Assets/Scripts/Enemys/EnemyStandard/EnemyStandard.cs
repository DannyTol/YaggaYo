using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandard : MonoBehaviour
{
    public float health;
    [Space]
    public float speed;
    [Space]
    public int pointsToGive;
    [Space]
    public GameObject damageSpritePrefab;
    [Space]
    public GameObject dieEffectPrefab;
    

    private void Update()
    {
        Health();

        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with Bullet enemy gets Damage and Sprite changes
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet hits Enemy");
            health -= FindObjectOfType<Bullet>().bulletDamage;

            DamageSprite();
        }

        // Collision with BigShot
        if(collision.gameObject.tag == "BigShot")
        {
            Debug.Log("StandardEnemy get hit by BigShot");
            health -= FindObjectOfType<BigShot>().damage;

            DamageSprite();
        }

        // Collision with TripleShot
        if(collision.gameObject.tag == "TripleShot")
        {
            Debug.Log("StandardEnemy get hit by TripleShot");
            health -= FindObjectOfType<TripleShotDamage>().damage;

            DamageSprite();
        }

        // Collision with PlayerRocket
        if(collision.gameObject.tag == "Rocket")
        {
            Debug.Log("EnemyStandard collision with PlayerRocket");
            health -= FindObjectOfType<Rocket>().damage;

            DamageSprite();
        }

        // Collision with DestroyWall StandardEnemy destroys
        if (collision.gameObject.tag == "DestroyWall")
        {
            Debug.Log("StandardEnemy Collision with DestroyWall");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy colllision with Shield
        if(collision.gameObject.tag == "Shield")
        {
            Debug.Log("EnemyStandard collision with Shield");
            Die();
        }
    }

    // Enemy moves
    void Move()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    // Enemy creates DamageSprite
    void DamageSprite()
    {
        Debug.Log("StandardEnemy creates DamageSprite");
        GameObject newSprite = Instantiate(damageSpritePrefab);
        newSprite.transform.position = gameObject.transform.position;
        Destroy(newSprite, 0.1f);
    }

    //Enemy Healthmanagment
    void Health()
    {
        if (health <= 0)
        {
            health = 0;
        }
        if (health == 0)
        {
            Die();
        }
    }

    // Enemy Death
    void Die()
    {
        Debug.Log("Enemy is dead");
        Destroy(gameObject);
        FindObjectOfType<PlayerMovement>().points += pointsToGive;
        Debug.Log("Player get Points");

        Explosion();
    }

    // Enemy creates ExplosionEffect
    void Explosion()
    {
        Debug.Log("StandardEnemy creates ExplosionEffect");
        GameObject newEffect = Instantiate(dieEffectPrefab);
        newEffect.transform.position = gameObject.transform.position;
        Destroy(newEffect, 1.2f);
    }
}
