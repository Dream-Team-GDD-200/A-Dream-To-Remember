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

    private int numOfEnemies = 0;

    //Box spawner Variables
    public int TimeBetweenBossMove;
    public int BossMaxSpeed;
    public int BossDamage;
    public int BoxMaxCount;
    public float timeBoxSpawns;
    //Timer lengths for each spawner so the timer resets after it reaches 0
    private float resetTimer;
    private float resetTimerBox;

    private Animator anim;

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
        anim = GetComponentInChildren<Animator>();
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
        
        if ((int)numOfEnemies < (int)MaxEnemies);
        {
            GameObject enemySpawned = Instantiate(enemy, transform.position, transform.rotation);
            //put enemy in local and master lists
            spawnedEnemies.Add(enemySpawned);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>().push(enemySpawned);
            // put the enemy  unter the parent in heirarchy
            enemySpawned.transform.parent = GameObject.FindGameObjectWithTag("MasterEnemies").transform;
            numOfEnemies++;
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
                BoxSpawner.SpawnBox();
                StartCoroutine(doTheRoar());
            }
        }
        timeBoxSpawns = resetTimerBox;
        StartCoroutine(BoxSpawnCountDown());
    }

    //Does the roar and animation for the roar
    public IEnumerator doTheRoar()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        anim.SetBool("Roaring", true);
        yield return new WaitForSeconds(0.417f);
        anim.SetBool("Roaring", false);
    }
    private void Update()
    {
        spawnedEnemies.ForEach(delegate (GameObject enemy)
        {
            if(enemy == null)
            {
                spawnedEnemies.Remove(enemy);
                numOfEnemies--;
            }
        });
    }
}
