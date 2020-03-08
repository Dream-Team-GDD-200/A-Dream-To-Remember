using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnablePathfinding : MonoBehaviour
{
    public AIPath aipath;
    // Update is called once per frame
  public void disablePathfinding()
  {
    this.gameObject.GetComponent<AIPath>().enabled = false;
  }

  public void enablePathfinding()
  {
    this.gameObject.GetComponent<AIPath>().enabled = true;
  }
}
