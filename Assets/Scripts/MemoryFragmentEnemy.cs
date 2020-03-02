using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFragmentEnemy : MonoBehaviour
{
    public bool dropsFragment;

    public GameObject baseMemFrag;
    public GameObject memFrag;

    public void dropMemFragment()
    {
        if (dropsFragment)
        {
            //instanciate a memory fragment prefab
            memFrag = Instantiate(baseMemFrag, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
