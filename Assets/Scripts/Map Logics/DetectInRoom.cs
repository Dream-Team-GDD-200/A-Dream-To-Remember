using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
        //Checks to see if the player is in the room with the enemy (will make this more industrial later)
        if (!SpawnedOnce && !doorBlock && Player.transform.position.x > (transform.position.x - (transform.lossyScale.x / 4)) && Player.transform.position.x < (transform.position.x + (transform.lossyScale.x / 4)) && Player.transform.position.y > (transform.position.y - (transform.lossyScale.y / 4)) && Player.transform.position.y < (transform.position.y + (transform.lossyScale.y / 4)))
        {
            //block player path
            doors.blockPath();
            // Activate spawner
            spawner.GetComponent<Spawner>().spawnEnemies();
            // set door block and room activation
            doorBlock = true;
            SpawnedOnce = true;
        }
        if (spawner.GetComponent<Spawner>().allEnemiesDead && !roomDone)
        {
            // open path after all enemies are dead
            doors.openPath();
            // set room to be done
            roomDone = true;
        }
    }
}
