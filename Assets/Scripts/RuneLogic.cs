using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLogic : MonoBehaviour
{
    private List<int> playerInput = new List<int>();//static so that all butttons share this array, this is what the player inputs
    public int orderThatItNeedsToBePushed;
    private bool hasBeenPushed = false;
    private static int timesPressed = 0; //list apparently doesn't have a .length function :<,  this is tracked as a static

    void Start()
    {
        
    }
    private void Update()
    {
        if(timesPressed == 5)
        {
            bool openDoor = true;
            for(int i=0; i < 5; i++) //if one of the inputs does not equal the respective element, then it will return false (It is comparing it to the list 1,2,3,4,5
            {
                if(i != playerInput[i])
                {
                    openDoor = false;
                }
            }
            if(openDoor == true)
            {
                //open door (ask zach how his doors work)
                //don't need to reset values 
                Debug.Log("yay");
            }
            else
            {
                //spawn like 5 enemies on them
                hasBeenPushed = false;
                timesPressed = 0;
                playerInput.Clear();
                Debug.Log("nay");
            }

            
        }
    }

    public void OnTriggerEnter2D(Collider2D other) //whe the player presses it
    {
        if (other.gameObject.tag == "Player" && hasBeenPushed == false)
        {
            playerInput.Add(this.orderThatItNeedsToBePushed);
            hasBeenPushed = true;
            timesPressed++;
            Debug.Log("I booped" + orderThatItNeedsToBePushed);
        }
    }
}
