using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss_SpawnEnemy : MonoBehaviour
{
    // SpawnHord will enable or disable the spawn of the enemies
    public GameObject enemy;
    public bool SpawnHord;
    public float spawnDelay;
    public float amountOfEnemies;
    public AIPath bossPath;
    void Start()
    {
        
    }
    public void CallEnemySpawn()
    {
        Invoke("SpawnEnemy", spawnDelay);
        for(int i = 0; i < amountOfEnemies; i++)
        {
            Invoke("SpawnEnemy", spawnDelay + spawnDelay);
        }
    }
    //will spawn enemies only if you have the feature turned on
    public void SpawnEnemy()
    {
        if (SpawnHord)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
    public void StartSpawner()
    {
        StartCoroutine(StartCountdown());
    }
    public float timeBetweenSpawns;
    public IEnumerator StartCountdown()
    {
        //timeBetweenSpawns = countdownValue;
        while (timeBetweenSpawns > 0)
        {
            Debug.Log("Countdown: " + timeBetweenSpawns);
            yield return new WaitForSeconds(1.0f);

            timeBetweenSpawns--;
            if (timeBetweenSpawns == 0)
            {
                CallEnemySpawn();
            }
        }
        StartCoroutine(StartCountdown());
    }
}
