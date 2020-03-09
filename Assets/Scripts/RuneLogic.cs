using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLogic : MonoBehaviour
{
    public int orderThatItNeedsToBePushed;
    public bool hasBeenPushed;
    public RuneHandler RuneHandler;
    SpriteRenderer image;

    private void Start()
    {
        hasBeenPushed = false;
        image = GetComponent<SpriteRenderer>(); //gets reference of the spirte component of each rune
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hasBeenPushed == false)
        {
            RuneHandler.AddToList(this.orderThatItNeedsToBePushed);
            hasBeenPushed = true;
            //change image of object
            Debug.Log("I booped" + orderThatItNeedsToBePushed);
        }
    }
}
