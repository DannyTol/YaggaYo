using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForward : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        gameObject.tag = "TripleShot";
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with Enemy
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("BulletForward Collision with Enemy");
        }
    }
}
