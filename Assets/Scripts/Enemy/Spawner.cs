using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int amountOfEnemies; // holds the amount of enemies that you want to spawn
    public GameObject[] Enemy; // holds enemy types
    public List<GameObject> SpawnedEnemies;//Holds all the enemies that where spawned
    public int enemyTypes;// 1 --> all enemies through melee , 2 --> all enemies melee to ranged
    private int rand; // random number
    public bool allEnemiesDead = false; // are all enemies dead?
    public bool active = false; // did the spawner activate?
    //spawnEnemies() method will spawn the enemies with wanted results
    public void spawnEnemies()
    {
        //Sets maximum amount of enemies
        if (amountOfEnemies > 4)
        {
            amountOfEnemies = 4;
        }
        if(amountOfEnemies > 0)
        {
            for (int i = 0; i < amountOfEnemies; i++)
            {
                if (i == 0)//right of spawner
                {
                    //randomly spawn enemy type
                    rand = Random.Range(0, enemyTypes);
                    // set the position to the right of spawner
                    Vector2 position = new Vector2(transform.position.x + 1, transform.position.y);
                    // spawn enemy
                    GameObject spEnemy = Instantiate(Enemy[rand], position, Quaternion.identity);
                    // add the object to local and master lists
                    SpawnedEnemies.Add(spEnemy);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>().push(spEnemy);
                    // put the new instantiated object inside the heirarchy correctly
                    spEnemy.transform.parent = GameObject.FindGameObjectWithTag("MasterEnemies").transform;
                }
                else if (i == 1)//left of spawner
                {
                    //randomly spawn enemy type
                    rand = Random.Range(0, enemyTypes);
                    // set the position to the left of spawner
                    Vector2 position = new Vector2(transform.position.x - 1, transform.position.y);
                    GameObject spEnemy = Instantiate(Enemy[rand], position, Quaternion.identity);
                    // add the object to local and master lists
                    SpawnedEnemies.Add(spEnemy);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>().push(spEnemy);
                    // put the new instantiated object inside the heirarchy correctly
                    spEnemy.transform.parent = GameObject.FindGameObjectWithTag("MasterEnemies").transform;
                }
                else if (i == 2)//above spawner
                {
                    //randomly spawn enemy type
                    rand = Random.Range(0, enemyTypes);
                    // set the position to the top of spawner
                    Vector2 position = new Vector2(transform.position.x, transform.position.y + 1);
                    // spawn enemy
                    GameObject spEnemy = Instantiate(Enemy[rand], position, Quaternion.identity);
                    // add the object to local and master lists
                    SpawnedEnemies.Add(spEnemy);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>().push(spEnemy);
                    // put the new instantiated object inside the heirarchy correctly
                    spEnemy.transform.parent = GameObject.FindGameObjectWithTag("MasterEnemies").transform;
                }
                else if (i == 3)//below spawner
                {
                    //randomly spawn enemy type
                    rand = Random.Range(0, enemyTypes);
                    // set the position to the bottom of spawner
                    Vector2 position = new Vector2(transform.position.x, transform.position.y - 1);
                    // spawn enemy
                    GameObject spEnemy = Instantiate(Enemy[rand], position, Quaternion.identity);
                    // add the object to local and master lists
                    SpawnedEnemies.Add(spEnemy);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>().push(spEnemy);
                    // put the new instantiated object inside the heirarchy correctly
                    spEnemy.transform.parent = GameObject.FindGameObjectWithTag("MasterEnemies").transform;
                }
            }
            active = true;
        }
    }
    private void Update()
    {
        for(int i = 0; i < SpawnedEnemies.Count; i++)
        {
            if(SpawnedEnemies[i] == null)
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
