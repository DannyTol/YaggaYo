using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShotItem : MonoBehaviour
{
    [Space]
    public int weapon = 1;
    [Space]
    public float time = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // By Collision with Player, Playerweapon changes
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("BigShotItem collision triggerd with Playert and changed Weapon");
            FindObjectOfType<PlayerMovement>().changeShot = weapon;
            FindObjectOfType<PlayerMovement>().weaponTime = time;
            Destroy(gameObject);
        }
    }
}
