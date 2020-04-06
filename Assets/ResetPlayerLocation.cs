using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerLocation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject refToResetLocation;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other is BoxCollider2D)// if colliding with the player, the button can be pushed, and the collider is a BoxCollider2D
        {
            other.gameObject.GetComponent<HealthDoctor>().takeDamage(10f); 
            other.gameObject.transform.position = refToResetLocation.transform.position;
        }
    }
}
