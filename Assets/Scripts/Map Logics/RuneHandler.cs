using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneHandler : MonoBehaviour
{
    private List<int> playerInput = new List<int>();
    private int timesPressed = 0; //list doesn't have a prebuilt size function so i'm using this ;-; as a place holder for its size

    public GameObject Rune1; //references to respective runes
    public GameObject Rune2;
    public GameObject Rune3;
    public GameObject Rune4;

    public Sprite runeOneNotPressed;
    public Sprite runeTwoNotPressed;
    public Sprite runeThreeNotPressed;
    public Sprite runeFourNotPressed;

    public GameObject Enemy; //reference to the enemy that will be spawned if incorrect 

    public GameObject door; //reference to boss door
    // Start is called before the first frame update
    void Start()
    {
        //door.GetComponent<DoorSpriteSwitcher>().close();      not necessary
        //door.GetComponent<BoxCollider2D>().enabled = false;
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
                //most likely I will have a reference to one of the doors 
                door.GetComponent<DoorSpriteSwitcher>().open(); //will change to openPathWay latter
                door.GetComponent<BoxCollider2D>().enabled = false;
                    
                timesPressed = 0; //stops function from calling anymore, 
                Debug.Log("yay");
            }
            else
            {
                Vector2 position1 = new Vector2(transform.position.x + 1, transform.position.y); //I believe that this is based of the position of the attached script 
                GameObject spEnemy = Instantiate(Enemy, position1, Quaternion.identity);

                Vector2 position2 = new Vector2(transform.position.x - 1, transform.position.y);
                GameObject spEnemy2 = Instantiate(Enemy, position2, Quaternion.identity);

                Invoke("ResetBools", 2f); //reset bools after 2s, then changes images 
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
        ResetSpriteImages(); //image reset function is called here invoke as lines of code below invoke are still executed right after the invoke call even if the invoked function hasn't even ran yet
    }
    public void ResetSpriteImages() //resets to notPressedImages
    {
        Rune1.GetComponent<SpriteRenderer>().sprite = runeOneNotPressed;
        Rune2.GetComponent<SpriteRenderer>().sprite = runeTwoNotPressed;
        Rune3.GetComponent<SpriteRenderer>().sprite = runeThreeNotPressed;
        Rune4.GetComponent<SpriteRenderer>().sprite = runeFourNotPressed;
    }
}
