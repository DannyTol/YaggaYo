using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2DamageSprite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy2DamageSprite collision with Enemy2");
            transform.parent = collision.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log(" Enemy2DamageSprite collision with Enemy2");
            transform.parent = collision.transform;
        }
        
    }
}
