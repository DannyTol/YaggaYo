using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSprite : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.parent = FindObjectOfType<PlayerMovement>().transform;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent = FindObjectOfType<PlayerMovement>().transform;
        }
    }
}
