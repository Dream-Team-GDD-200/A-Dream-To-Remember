using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossMechanics: MonoBehaviour
{
    // SpawnHord will enable or disable the spawn of the enemies
    //Player
    public GameObject enemy;
    //Spawn enemies? yes or no
    public bool SpawnHord;
   //Scripts to reference
    public AIPath bossPath;
    public DamagePlayer Damage;
    public DeployBox BoxSpawner;
    //enemy spawner variables
    public float spawnDelay;
    public float amountOfEnemies;
    public float timeBetweenSpawns;
    public List<GameObject> spawnedEnemies;
    public float MaxEnemies;
    //Box spawner Variables
    public int TimeBetweenBossMove;
    public int BossMaxSpeed;
    public int BossDamage;
    public int BoxMaxCount;
    public float timeBoxSpawns;
    //Timer lengths for each spawner so the timer resets after it reaches 0
    private float resetTimer;
    private float resetTimerBox;
    

    void Start()
    {
        //Variables for the Mechanics/Controller
        BoxSpawner = GetComponent<DeployBox>();
        Damage = GetComponent<DamagePlayer>();
        bossPath.repathRate = TimeBetweenBossMove;
        bossPath.maxSpeed = BossMaxSpeed;
        Damage.strength = BossDamage;
        BoxSpawner.MaxBoxes = BoxMaxCount;
        resetTimer = timeBetweenSpawns;
        resetTimerBox = timeBoxSpawns;
    }
    //Will spawn enemies
    public void CallEnemySpawn()
    {
        Invoke("SpawnEnemy", spawnDelay);
        if(amountOfEnemies > 0)
        {
            for (int i = 0; i < amountOfEnemies - 1; i++)
            {
                Invoke("SpawnEnemy", spawnDelay);
            }
        }
    }
    //will spawn enemies only if you have the feature turned on
    public void SpawnEnemy()
    {
        if (spawnedEnemies.Count < 2f);
        {
            GameObject enemySpawned = Instantiate(enemy, transform.position, transform.rotation);
            spawnedEnemies.Add(enemySpawned);
        }
    }
    // Starts both spawners
    public void StartSpawner()
    {
        StartCoroutine(StartCountdown());
        StartCoroutine(BoxSpawnCountDown());
    }
    
    //Counter for enemies
    public IEnumerator StartCountdown()
    {
        //timeBetweenSpawns = countdownValue;
        while (timeBetweenSpawns > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeBetweenSpawns--;
            if (timeBetweenSpawns == 0)
            {
                CallEnemySpawn();
            }
        }
        timeBetweenSpawns = resetTimer;
        StartCoroutine(StartCountdown());
    }
    //counter for boxes
    public IEnumerator BoxSpawnCountDown()
    {
        //timeBetweenSpawns = countdownValue;
        while (timeBoxSpawns > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeBoxSpawns--;
            if (timeBoxSpawns == 0)
            {
                Debug.Log("Box Being Spawned");
                BoxSpawner.SpawnBox();
                this.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        timeBoxSpawns = resetTimerBox;
        StartCoroutine(BoxSpawnCountDown());
    }
    private void Update()
    {
        spawnedEnemies.ForEach(delegate (GameObject enemy)
        {
            if(enemy == null)
            {
                spawnedEnemies.Remove(enemy);
            }
        });
    }
}
