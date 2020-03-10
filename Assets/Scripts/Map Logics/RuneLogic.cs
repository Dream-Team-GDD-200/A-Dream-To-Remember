using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLogic : MonoBehaviour
{
    public int orderThatItNeedsToBePushed;
    public bool hasBeenPushed;
    public RuneHandler RuneHandler;
  
    public Sprite runePressed; //reference to basic image (the notPressedImage will be default)
    //handler will have references to notPressed sprite as that's where it changes them back 

    private void Start()
    {
        hasBeenPushed = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hasBeenPushed == false && other is BoxCollider2D) // if colliding with the player, the button can be pushed, and the collider is a BoxCollider2D
        {
            RuneHandler.AddToList(this.orderThatItNeedsToBePushed);
            hasBeenPushed = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = runePressed;//sets whatever gameobject that this script is attached to and changes the image to the pressed state
            Debug.Log("I booped" + orderThatItNeedsToBePushed);
        }
    }
}
