using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss_SpawnEnemy : MonoBehaviour
{
    // SpawnHord will enable or disable the spawn of the enemies
    public GameObject enemy;
    public bool SpawnHord;
    public float spawnTime;
    public float spawnDelay;
    public AIPath bossPath;
    void Start()
    {
        if (SpawnHord)
        {
            CallEnemySpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CallEnemySpawn()
    {
        Invoke("SpawnEnemy", spawnTime);
        Invoke("SpawnEnemy", spawnTime + spawnDelay);
        //Invoke("SpawnEnemy", spawnTime + spawnDelay + spawnDelay);
        
    }
    public void SpawnEnemy()
    {
        if (SpawnHord)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}
