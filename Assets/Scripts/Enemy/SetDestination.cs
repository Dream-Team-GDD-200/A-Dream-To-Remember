using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SetDestination : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
