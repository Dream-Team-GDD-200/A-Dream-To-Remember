using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPushable : MonoBehaviour
{
    Rigidbody2D phys;
    void Start()
    {
        phys = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        if(!collision.isTrigger && collision.tag=="Player") ///if a collider on the player and the collider is not the trigger colider (the capsul colider)
        {
            phys.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        phys.bodyType = RigidbodyType2D.Static;
    }

    private void OnTriggerStay2D(Collider2D collision) //as long as it stay attacfhed to box it stays dynamic
    {
        if (!collision.isTrigger && collision.tag == "Player")
        {
            phys.bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
