using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLogic : MonoBehaviour
{
    private Collider2D other = null;
    public static bool PlayerIsSlidding = false; //variable that value is the same across all gameobjects with the script IceLogic
    public float slideSpeed = 0;

    private Vector3 direction = new Vector3(0, 0, 0);
    private GameObject referenceToPlayer = null;
    private bool useUpdate = false;
    private GameObject refToUserInput;

    public void Start()
    {
        refToUserInput = GameObject.FindWithTag("UI");
        referenceToPlayer = GameObject.FindWithTag("Player");

    }
        //I did this to  make sure that when it enters another iceblock tag it doesn't mess with it 
        // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if(collision.tag=="Player" && collision is BoxCollider2D && PlayerIsSlidding == false)//when the player enters a ice block trigger, it checks to see if it is in fact the player, the players feet, and that the palyer isn't already slidding
        {
          
            PlayerIsSlidding = true; //player has begun the slidding process
            refToUserInput.SetActive(false); //turns off ui controls 

            Vector2 SlideDirectionTemp = collision.gameObject.GetComponent<PlayerMovement>().movement;//technically, we never actually gave player a speed (addforce) as we just transformed him so rigidbody.velocity would always be zero. Thus is a vector with player current movement in playermovement script


            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false; //enabled was only way to make it work
            //Turn off player movement script
            //sets a var equal to the players current  vector (direction) as a vector 3 (since player can't move in z axis it will be 0, I did this to access the translate function)

            Debug.Log(SlideDirectionTemp);

            Vector3 SlideDirection = new Vector3(0, 0, 0); //for final direction
            //split up x and y and see which olne is the greater value (we don't want them to slide diagonally)
            float x = SlideDirectionTemp.x;
            float y = SlideDirectionTemp.y;

            Debug.Log("" + x);
            Debug.Log("" + y);

            
            if ((x*x) > (y*y)) //if x direction is greater than the y (these are comparing the squares of the two values which is equivalent--results based-- of comparing their absolute values)
            {
                if (x > 0) //checks to see if x is pos or neg
                {
                    SlideDirection = new Vector3(1, 0, 0);
                }
                else //if x is 0 or less than 0
                {
                    SlideDirection = new Vector3(-1, 0, 0);
                }
            }
            else //check if y is greater than x or if x and y are equal to eachother
            {
                if(y > 0)
                {
                    SlideDirection = new Vector3(0, 1, 0);
                }
                else //if y is 0 or less than 0
                {
                    
                    SlideDirection = new Vector3(0, -1, 0);
                }
               
            }

             direction = SlideDirection;
             useUpdate = true;
             

        }
    }

 

    private void Update()
    {
        if(useUpdate==true)
        { 
          
            referenceToPlayer.transform.Translate(direction * slideSpeed * Time.deltaTime); //transforms object by speeed every 1 second
            if (GameObject.FindWithTag("Player").GetComponent<IceStopper>().stopSlidding == true)
             {
                PlayerIsSlidding = false; //player is no longer slidding
                useUpdate = false; //no longer run this function
                Debug.Log(PlayerIsSlidding);
                //turn ui and input back on
                refToUserInput.SetActive(true);
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
                GameObject.FindWithTag("Player").GetComponent<IceStopper>().stopSlidding = false;
            }

        }
    }



}
