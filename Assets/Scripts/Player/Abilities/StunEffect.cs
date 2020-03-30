using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffect : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    // if the enemy contacts the stun field
    if (other.gameObject.CompareTag("StunField"))
    {
      // disable the pathfinding script and restores it after 2 seconds
      this.GetComponent<EnablePathfinding>().disablePathfinding();
      Invoke("restorePathfinding", GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getStunDuration());
    }
  }

  private void restorePathfinding()
  {
    this.GetComponent<EnablePathfinding>().enablePathfinding();
  }
}
