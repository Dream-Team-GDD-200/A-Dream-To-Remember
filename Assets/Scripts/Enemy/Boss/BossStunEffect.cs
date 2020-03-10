using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStunEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the enemy contacts the stun field
        if (other.gameObject.CompareTag("StunField"))
        {
            // disable the pathfinding script and restores it after 2 seconds
            this.GetComponent<Boss_EnablePathing>().disablePathfinding();
            Invoke("restorePathfinding", 2f);
        }
    }

    private void restorePathfinding()
    {
        this.GetComponent<Boss_EnablePathing>().enablePathfinding();
    }
}
