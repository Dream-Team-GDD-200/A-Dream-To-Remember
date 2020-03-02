using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    //on Collision with enemy a certain damage is delt
    //other is the object that the enemy is colliding with, and other is a Collider2D variable
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if colliding with player
        if (other.tag == ("Player"))
        {
            // add a knockback away from collision
            Vector2 knockback = transform.position - other.transform.position;
            //enemy knockback
            this.gameObject.transform.Translate(knockback * .35f);
            //player knockback
            other.gameObject.transform.Translate(-knockback * .15f);
            other.gameObject.GetComponent<PlayerMovement>().movement = new Vector2(0, 0);
        }
        // if hit by an projectile or deplyed cell get destroyed
        if (other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("DeployedCell"))
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // add a knockback away from collision
            Vector2 knockback = transform.position - other.transform.position;
            //Enemy Knockback
            this.gameObject.transform.Translate(knockback * .35f);
            //player knocked back
            other.gameObject.transform.Translate(-knockback * .15f);
            other.gameObject.GetComponent<PlayerMovement>().movement = new Vector2(0, 0);
        }
    }
}
