using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployBox : MonoBehaviour
{
    public Transform[] spawnLocation;
    public int MaxBoxes;
    public GameObject[] Box;
    public List<GameObject> madeBoxes;
    private int rand, rand2;
    public void SpawnBox()
    {
        if(madeBoxes.Count < MaxBoxes)
        {
            Debug.Log("SpawnBox");
            rand = Random.Range(0, Box.Length);
            rand2 = Random.Range(0, spawnLocation.Length);
            GameObject crate = Instantiate(Box[rand], spawnLocation[rand2].position, Quaternion.identity);
            madeBoxes.Add(crate);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>().push(crate);
            crate.transform.parent = GameObject.FindGameObjectWithTag("MasterBoxes").transform;
        }
    }
    private void Update()
    {
        madeBoxes.ForEach(delegate (GameObject box)
        {
            if (box == null)
            {
                madeBoxes.Remove(box);
            }
        });
    }
}
