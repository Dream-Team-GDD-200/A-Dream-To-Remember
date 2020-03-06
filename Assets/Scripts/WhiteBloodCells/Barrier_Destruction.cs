using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Destruction : MonoBehaviour
{
  // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Projectile"))
        {
          GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().reduceCellHealth(1);
        }

        int health = GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().getCellHealth();
        if (health <= 0)
            {
              Destroy(this.gameObject);
            }
    }
}
