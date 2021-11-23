using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Space]
    public float damage;
    [Space]
    public float speed;


    // Rocket is moving to the right side
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    // Collision with Enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            Debug.Log("Rocket Collision with " + collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Collision Trigger with Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Rocket Collision Trigger with Enemy");
            Destroy(gameObject);
        }
    }
}
