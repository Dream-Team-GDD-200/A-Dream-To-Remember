using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelTwoBossRight : MonoBehaviour
{
    //***this section of code might want to be changed, wasn't sure what method was best at the time and i needed to start working on other hw.
    public float bossSpeed = 3;
    public GameObject bossEndPoint; //this is where the boss is lerping to

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bossSpeed, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"  && collision.collider is BoxCollider2D)//if it collides with the players box collider
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.rigidbody.velocity = new Vector2(0, 0); //sets player movement to zero 
        }
    }

}
