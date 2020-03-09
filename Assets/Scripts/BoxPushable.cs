using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushable : MonoBehaviour
{
    private Rigidbody2D phys;
    void Start()
    {
        phys = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player") ///if a collider on the player and the collider is not the trigger colider (the capsul colider)
        {
            phys.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            phys.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) //as long as it stay attacfhed to box it stays dynamic
    {
        if (collision.gameObject.tag == "Player")
        {
            phys.bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
