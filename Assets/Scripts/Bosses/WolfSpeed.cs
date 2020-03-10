using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WolfSpeed : MonoBehaviour
{
    public Vector2 speed = new Vector2(0, 0);
    void Update()
    {
        speed = this.gameObject.GetComponent<AIPath>().velocity;
    }
}
