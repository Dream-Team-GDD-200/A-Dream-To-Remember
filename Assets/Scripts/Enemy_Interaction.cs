using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Interaction : MonoBehaviour
{
    public float strength;
    // Start is called before the first frame update
    void Start() 
    {
    }
    // Update is called once per frame
    void Update() 
    {
    }

    //on Collision with enemy a certain damage is delt
    //other is the object that the enemy is colliding with, and other is a Collider2D variable
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           other.gameObject.GetComponent<HealthDoctor>().takeDamage(strength);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            // add a force away from enemy after they collide
            Vector2 knockback = transform.position - other.transform.position;
            //knockback.Normalize();
            this.gameObject.transform.Translate(knockback * .35f);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthDoctor>().takeDamage(strength);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            // add a force away from enemy after they collide
            Vector2 knockback = transform.position - other.transform.position;
            //knockback.Normalize();
            this.gameObject.transform.Translate(knockback * .35f);
        }
    }
}
