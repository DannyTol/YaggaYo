using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUp : MonoBehaviour
{
    public float speed;
    private float speed2 = 15;

    private void Awake()
    {
        gameObject.tag = "TripleShot";
    }

    void Update()
    {
        transform.Translate(speed2 *Time.deltaTime, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("BulletUp collision with Enemy");
        }
    }
}
