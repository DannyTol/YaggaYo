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
    [Space]
    public GameObject medikitItemPrefab;
    public GameObject shieldItemPrefab;
    public GameObject rocketItemPrefab;
    public GameObject bigShotItemPrefab;
    public GameObject tripleShotItemPrefab;
    [Space]
    public int dropItem;

    private void Awake()
    {
        // Gives Tag Enemy by awake
        gameObject.tag = "Enemy";

        // Give Random Item to drop
        dropItem = Random.Range(0, 6);
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
            Destroy(collision.gameObject);

            Health();
        }

        // Collision with BigShot
        if (collision.gameObject.tag == "BigShot")
        {
            Debug.Log("Asteroid get hit by BigShot");
            health -= FindObjectOfType<BigShot>().damage;

            Health();
        }

        // Collision with TripleShot
        if (collision.gameObject.tag == "TripleShot")
        {
            Debug.Log("Asteroid get hit by TripleShot");
            health -= FindObjectOfType<TripleShotDamage>().damage;

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
            ChooseItemToDrop();
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

    // Switch Item to Drop
    void ChooseItemToDrop()
    {
        switch (dropItem)
        {
            case 0:
                Debug.Log("Asteroid drop MedikitItem");
                GameObject newMedikit = Instantiate(medikitItemPrefab);
                newMedikit.transform.position = gameObject.transform.position;
                break;

            case 1:
                Debug.Log("Asteroid drop ShieldItem");
                GameObject newShield = Instantiate(shieldItemPrefab);
                newShield.transform.position = gameObject.transform.position;
                break;

            case 2:
                Debug.Log("Asteroid drop RocketItem");
                GameObject newRockets = Instantiate(rocketItemPrefab);
                newRockets.transform.position = gameObject.transform.position;
                break;

            case 3:
                Debug.Log("Asteroid drop BigShotItem");
                GameObject newBigShot = Instantiate(bigShotItemPrefab);
                newBigShot.transform.position = gameObject.transform.position;
                break;

            case 4:
                Debug.Log("Asteroid drop TripleShot");
                GameObject newTripleShot = Instantiate(tripleShotItemPrefab);
                newTripleShot.transform.position = gameObject.transform.position;
                break;

            default:
                Debug.Log("Asteroid drops no Item");
                break;
        }
    }
}
