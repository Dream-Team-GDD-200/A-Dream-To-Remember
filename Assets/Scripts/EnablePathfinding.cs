using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnablePathfinding : MonoBehaviour
{
    public AIPath aipath;
    public GameObject Player;
    public GameObject Room;
    // Update is called once per frame
    void Update()
    {
        //Checks to see if the player is in the room with the enemy (will make this more industrial later)
        if(Player.transform.position.x > (Room.transform.position.x - (Room.transform.lossyScale.x / 4)) && Player.transform.position.x < (Room.transform.position.x + (Room.transform.lossyScale.x / 4)) && Player.transform.position.y > (Room.transform.position.y - (Room.transform.lossyScale.y / 4)) && Player.transform.position.y < (Room.transform.position.y + (Room.transform.lossyScale.y / 4)))
        {
            this.gameObject.GetComponent<AIPath>().enabled = true;
        }
    }
}
