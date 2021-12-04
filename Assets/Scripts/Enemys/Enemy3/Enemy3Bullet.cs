using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Bullet : MonoBehaviour
{

    [Space]
    public float speed;
    [Space]
    public float damage;

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision with Player
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy3Bullet hits Player");
            Destroy(gameObject);
            FindObjectOfType<PlayerMovement>().maxHealth -= damage;
        }
    }


}
