using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Destruction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if colliding with wall, box, deployed cell, or enemy projectile is destroyed
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("DeployedCell") || other.gameObject.CompareTag("Enemy"))
        {
            // destroy object
            Destroy(this.gameObject);
        }
    }
}
