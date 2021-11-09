using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public float speed;


    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    // Collision with Enemy, Enemy is dead
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Enemy")
        {
            Debug.Log("DestroyWall collision with Enemy");
            Destroy(collision.gameObject);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collision with ShieldItem, ShieldItem destroy
        if (collision.gameObject.tag == "ShieldItem")
        {
            Debug.Log("DestroyWall collision with ShieldItem");
            Destroy(collision.gameObject);
        }

        //Collision with Enemy, Enemy destroys/die
        if (gameObject.tag == "Enemy")
        {
            Debug.Log("DestroyWall collision with Enemy");
            Destroy(collision.gameObject);
        }

    }

}
