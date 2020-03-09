using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneHandler : MonoBehaviour
{
    private List<int> playerInput = new List<int>();
    private int timesPressed = 0;

    public GameObject Rune1; //respective runes
    public GameObject Rune2;
    public GameObject Rune3;
    public GameObject Rune4;

    // Start is called before the first frame update
    void Start()
    {
      //references to sprite renderer potentialy  
    }

    // Update is called once per frame
    void Update()
    {
        if(timesPressed == 4 )
        {
            bool openDoor = true;
            for(int i=0; i < 4; i++)
            {
                if((i+1) != playerInput[i])
                {
                    openDoor = false;
                }
            }

            if(openDoor==true)
            {
                //open door
                //don't need to reset values
                timesPressed = 0; //stops if function from calling anymore
                Debug.Log("yay");
            }
            else
            {
                //spawn 2 enemies
            
                Invoke("ResetBools", 2f); //reset bools after 2s
                //switch images back
                timesPressed = 0; //reset counter
                playerInput.Clear();//clears Array
                Debug.Log("nay");
            }
        }
    }

    public void AddToList(int value)
    {
        playerInput.Add(value);
        timesPressed++;
    }
    public void ResetBools()
    {
        Rune1.GetComponent<RuneLogic>().hasBeenPushed = false;
        Rune2.GetComponent<RuneLogic>().hasBeenPushed = false;
        Rune3.GetComponent<RuneLogic>().hasBeenPushed = false;
        Rune4.GetComponent<RuneLogic>().hasBeenPushed = false;
    }
}
