using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShot : MonoBehaviour
{

    public float speed;
    public float damage;
   
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // By Collision with Enemy BigShot destroys
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("BigShot hits Enemy");
            Destroy(gameObject);
        }
    }
}
