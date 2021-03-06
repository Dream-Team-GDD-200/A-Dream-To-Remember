﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int amountOfEnemies; // holds the amount of enemies that you want to spawn
    [Header("Enemy Prefabs")]
    public GameObject[] Enemy; // holds enemy types
    [Header("Enemies Spawned")]
    public List<GameObject> SpawnedEnemies;//Holds all the enemies that where spawned
    [Header("Spawn Locations")]
    public GameObject[] SpawnLocations; // spawnLocations for the enemy
    [Header("Enemy Type (1 = first only | 2+ = first two enemy types)")]
    [SerializeField] public int MaxEnemies;
    [Range(0, 100)] public int EnemySpawnRatio; // left side of slider is melee enemy and right side of slider is projectile enemy
    private bool[] usedPositions;
    private int rand; // random number
    [Header("Bools for spawner Activity")]
    public bool allEnemiesDead = false; // are all enemies dead?
    public bool active = false; // did the spawner activate?

    //spawnEnemies() method will spawn the enemies with wanted results
    private void Start()
    {
        MaxEnemies = SpawnLocations.Length;
        usedPositions = new bool[SpawnLocations.Length];
        //Sets maximum amount of enemies
        if (amountOfEnemies > MaxEnemies)
        {
            amountOfEnemies = MaxEnemies;
        }
        for (int i = 0; i < usedPositions.Length; i++)
        {
            usedPositions[i] = false;
        }
    }
    public void spawnEnemies()
    {
        if (amountOfEnemies > 0)
        {
            Debug.Log(amountOfEnemies);
            for (int i = 0; i < amountOfEnemies; i++)
            {
                //randomly spawn enemy type
                rand = Random.Range(0, 100);
                // set a random position from list of positions
                int temp;
                do
                {
                    temp = Random.Range(0, SpawnLocations.Length - 1);
                } while (usedPositions[temp] == true);
                Debug.Log("Temp " + temp);
                Vector2 position = SpawnLocations[temp].transform.position;
                Debug.Log("Position: " + position);
                usedPositions[temp] = true;

                // spawn enemy
                GameObject spEnemy = null;
                if (rand > EnemySpawnRatio)
                {
                    spEnemy = Instantiate(Enemy[1], position, Quaternion.identity);
                }
                else if (rand < EnemySpawnRatio)
                {
                    spEnemy = Instantiate(Enemy[0], position, Quaternion.identity);
                }

                // add the object to local and master lists
                SpawnedEnemies.Add(spEnemy);
                GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>().push(spEnemy);
                // put the new instantiated object inside the heirarchy correctly
                spEnemy.transform.parent = GameObject.FindGameObjectWithTag("MasterEnemies").transform;
            }
            active = true;
            for (int i = 0; i < MaxEnemies; i++)
            {
                SpawnLocations[i].SetActive(false);
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < SpawnedEnemies.Count; i++)
        {
            if (SpawnedEnemies[i] == null)
            {
                SpawnedEnemies.RemoveAt(i);
            }
        }
        // if all enemeies die then set all enemies dead to true
        // this will be called to allow the door to open
        SpawnedEnemies.TrimExcess();
        if (SpawnedEnemies.Count == 0 && active)
        {
            allEnemiesDead = true;
        }
    }
}
