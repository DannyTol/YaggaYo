using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [Space]
    public float bulletDamage;

   
    void Update()
    {
        // Bullet moves to the right side
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with Objects 
        Debug.Log("Collision with " + collision.gameObject);
        Destroy(gameObject);
    }
}
