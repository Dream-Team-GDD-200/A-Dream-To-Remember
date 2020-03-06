using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss_SpawnEnemy : MonoBehaviour
{
    // SpawnHord will enable or disable the spawn of the enemies
    public GameObject enemy;
    public bool SpawnHord;
    public float spawnTime, spawnDelay;
    public float amountOfEnemies;
    public AIPath bossPath;
    void Start()
    {
        
    }
    public void CallEnemySpawn()
    {
        Invoke("SpawnEnemy", spawnTime);
        for(int i = 0; i < amountOfEnemies; i++)
        {
            Invoke("SpawnEnemy", spawnDelay);
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
    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            
            currCountdownValue--;
            if (currCountdownValue == 0)
            {
                CallEnemySpawn();
            }
        }
        StartCoroutine(StartCountdown());
    }
}
