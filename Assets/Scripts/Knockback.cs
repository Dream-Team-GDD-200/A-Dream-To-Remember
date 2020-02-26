using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    //on Collision with enemy a certain damage is delt
    //other is the object that the enemy is colliding with, and other is a Collider2D variable
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            // add a knockback away from collision
            Vector2 knockback = transform.position - other.transform.position;
            //enemy knockback
            this.gameObject.transform.Translate(knockback * .35f);
            //player knockback
            other.gameObject.transform.Translate(-knockback * .15f);
        }
        if (other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("DeployedCell"))
        {
            Destroy(this.gameObject);
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
        }
    }
}
