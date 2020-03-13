using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
public class DetectInRoom : MonoBehaviour
{
    public GameObject Player; // holds player object
    public DoorLogic doors; // holds the script for door logic
    public GameObject spawner; // holds the spawner objects
    private int spawnersDone = 0;
    private bool doorBlock = false;
    private bool SpawnedOnce = false; // will make it so enemies can only spawn once
    private bool roomDone = false;// will stop the update function of constantly calling doors.openPath()
    private void Start()
    {
        doors = this.GetComponent<DoorLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        if (SpawnedOnce && spawner.GetComponent<Spawner>().allEnemiesDead && !roomDone)
        {
            // open path after all enemies are dead
            doors.openPath();
            // set room to be done
            roomDone = true;
        }
    }
    public void activate()
    {
        //Checks to see if the player is in the room with the enemy (will make this more industrial later)
        if (!SpawnedOnce && !doorBlock)
        {
            //block player path
            doors.blockPath();
            // Activate spawner
            spawner.GetComponent<Spawner>().spawnEnemies();
            // set door block and room activation
            doorBlock = true;
            SpawnedOnce = true;
            //Spawn the boss
            try
            {
                GetComponent<Boss_EnablePathing>().spawnBoss();
            }
            catch (Exception e) { print(e.Message); }
        }
    }
    //  && Player.transform.position.x > (transform.position.x - (transform.lossyScale.x / 4)) && Player.transform.position.x < (transform.position.x + (transform.lossyScale.x / 4)) && Player.transform.position.y > (transform.position.y - (transform.lossyScale.y / 4)) && Player.transform.position.y < (transform.position.y + (transform.lossyScale.y / 4))
}
