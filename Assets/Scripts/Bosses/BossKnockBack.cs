using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossKnockBack : MonoBehaviour
{
    //on Collision with enemy a certain damage is delt
    //other is the object that the enemy is colliding with, and other is a Collider2D variable

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if colliding with player
        if (other.gameObject.tag == "Player")
        {
            // add a knockback away from collision
            Vector2 knockback = transform.position - other.transform.position;
            //player knockback
            other.gameObject.transform.Translate(-knockback * .8f);
            other.gameObject.GetComponent<PlayerMovement>().movement = new Vector2(0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // add a knockback away from collision
            Vector2 knockback = transform.position - other.transform.position;
            //player knocked back
            other.gameObject.transform.Translate(-knockback * .8f);
            other.gameObject.GetComponent<PlayerMovement>().movement = new Vector2(0, 0);
        }
    }
}
