using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticToDynamic : MonoBehaviour
{
     private Rigidbody2D body;
    private bool isPushing = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other) //mass of boxes start out very high and are only moveable when it collides with player
    {
        if (other.gameObject.CompareTag("Player"))
        {
      
            body.mass = 1;

        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        body.mass = 10000;
    }
}
