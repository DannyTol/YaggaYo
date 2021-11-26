using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotItem : MonoBehaviour
{
    [Space]
    public int weapon = 2;
    [Space]
    public float time = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision with Player, Playerweapon changes
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("TripleShotItem collision triggerd with Player");
            FindObjectOfType<PlayerMovement>().changeShot = weapon;
            FindObjectOfType<PlayerMovement>().weaponTime = time;
            Destroy(gameObject);
        }
    }
}
