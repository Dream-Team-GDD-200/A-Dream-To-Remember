using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knockback : MonoBehaviour
{
    public int hitsCanTake;
    private int remainingHits;

    void Start()
    {
        remainingHits = hitsCanTake;
    }

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
            remainingHits -= 1;
            float h = (float)remainingHits / (float)hitsCanTake;
            this.gameObject.GetComponentInChildren<EnemyHealth>().SetHealth(h * 100f);
            this.gameObject.GetComponentsInChildren<RectTransform>()[1].localScale = new Vector3(h, 1f, 1f);
            if (remainingHits <= 0)
            {
                this.gameObject.GetComponent<MemoryFragmentEnemy>().dropMemFragment();
                Destroy(this.gameObject);
            }
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
