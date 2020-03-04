using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject Room;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        //check to see if player is in the trigger zone and if so then call for door to appear
        if(Player.transform.position.x > (Room.transform.position.x - (Room.transform.lossyScale.x / 4)) && Player.transform.position.x < (Room.transform.position.x + (Room.transform.lossyScale.x / 4)) && Player.transform.position.y > (Room.transform.position.y - (Room.transform.lossyScale.y / 4)) && Player.transform.position.y < (Room.transform.position.y + (Room.transform.lossyScale.y / 4)))
        {
            blockPath();
        }
    }
    //makes door appear
    void blockPath()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    //Makes door disapear
    void openPath()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}

