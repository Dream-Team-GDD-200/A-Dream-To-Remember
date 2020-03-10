using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFragmentEnemy : MonoBehaviour
{
    public bool dropsFragment;

    public GameObject baseMemFrag;
    public GameObject memFrag;
    private int rand;

    private void Start()
    {
        rand = Random.Range(0, 50);
        if (rand < 20 || rand > 40)
        {
            dropsFragment = true;
        }
        else
        {
            dropsFragment = false;
        }
    }
    public void dropMemFragment()
    {
        if (dropsFragment)
        {
            //instanciate a memory fragment prefab
            memFrag = Instantiate(baseMemFrag, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
