﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss_EnablePathing : MonoBehaviour
{
    public bool pathfindingActive = true;
    public AIPath aipath;
    public GameObject Player;
    public GameObject Room;
    bool inRoom = false;
    // Update is called once per frame
    void Update()
    {
        //Checks to see if the player is in the room with the enemy (will make this more industrial later)
        if (pathfindingActive == true && Player.transform.position.x > (Room.transform.position.x - (Room.transform.lossyScale.x / 4)) && Player.transform.position.x < (Room.transform.position.x + (Room.transform.lossyScale.x / 4)) && Player.transform.position.y > (Room.transform.position.y - (Room.transform.lossyScale.y / 4)) && Player.transform.position.y < (Room.transform.position.y + (Room.transform.lossyScale.y / 4)) && !inRoom)
        {
            enablePathfinding();
            inRoom = true;
        }
    }

    public void disablePathfinding()
    {
        this.gameObject.GetComponent<AIPath>().enabled = false;
        pathfindingActive = false;
        this.gameObject.GetComponent<Boss_SpawnEnemy>().SpawnHord = false;
    }

    public void enablePathfinding()
    {
        this.gameObject.GetComponent<AIPath>().enabled = true;
        pathfindingActive = true;
        this.gameObject.GetComponent<Boss_SpawnEnemy>().SpawnHord = true;
        this.gameObject.GetComponent<Boss_SpawnEnemy>().StartSpawner();
    }
}
