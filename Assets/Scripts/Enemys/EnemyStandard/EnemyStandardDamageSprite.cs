using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardDamageSprite : MonoBehaviour
{

    // DamageSprite gives parent to StandardEnemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("DamageSprite Collision Trigger with Enemy");
            transform.parent = collision.transform;
        }
    }

    // DamageSprite gives Parent to StandardEnemy and follows StandardEnemy
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("DamageSprite Collision Trigger with Enemy");
            transform.parent = collision.transform;
        }
    }
}
