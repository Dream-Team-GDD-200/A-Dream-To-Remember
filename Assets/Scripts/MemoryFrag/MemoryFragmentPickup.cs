using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFragmentPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If player collides with the memory fragment
        if (other.tag == ("Player"))
        {
            GameObject.FindGameObjectWithTag("UI").GetComponentInChildren<MemoryFragmentsUI>().addMemoryFragment();
            Destroy(this.gameObject);
        }
    }
}
