﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss_EnablePathing : MonoBehaviour
{
    public bool pathfindingActive = true;
    public AIPath aipath;
    public GameObject Boss;
    public GameObject Room;
    bool inRoom = false;
    public int BossDelay;
    private int bossDelayReset;
    
    private void Start()
    {
        bossDelayReset = BossDelay;
    }
    // Update is called once per frame
    public void spawnBoss()
    {
        //Checks to see if the player is in the room with the enemy (will make this more industrial later)
        if (!inRoom)
        {
            Boss.SetActive(true);
            //DO CUTSCENE AND THEN INIT
            StartCoroutine(cutsceneStart());
            inRoom = true;
        }
    }

    public void disablePathfinding()
    {
        Boss.gameObject.GetComponent<AIPath>().enabled = false;
        Boss.gameObject.GetComponent<BossMechanics>().SpawnHord = false;
    }

    public void enablePathfinding()
    {
        Boss.gameObject.GetComponent<AIPath>().enabled = true;
        Boss.gameObject.GetComponent<BossMechanics>().SpawnHord = true;
    }

    IEnumerator cutsceneStart()
    {
        // start cutscene stuff here
        Boss.gameObject.GetComponent<Cutscene>().beginCutscene();

        yield return new WaitForSeconds(8f);

        // Enable the boss
        StartCoroutine(initialize());
    }

    IEnumerator initialize()
    {
        //timeBetweenSpawns = countdownValue;
        while (BossDelay > 0)
        {
            yield return new WaitForSeconds(1.0f);
            BossDelay--;
            if (BossDelay == 0)
            {
                enablePathfinding();
                Boss.gameObject.GetComponent<BossMechanics>().StartSpawner();
            }
        }
        BossDelay = bossDelayReset;
    }
}
