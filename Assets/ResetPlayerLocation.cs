using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerLocation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject refToResetLocation;
    bool isStayingInLight = false;
    float timeInLight = 0f;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other is BoxCollider2D)// if colliding with the player, the button can be pushed, and the collider is a BoxCollider2D
        {
            other.gameObject.GetComponent<HealthDoctor>().takeDamage(15f);
            other.gameObject.transform.position = refToResetLocation.transform.position;
        }
    }

    //these bottom two lines are ment to prevent exploiting the boss puzzle (I may also may speed up the boss instead of damaging the player during level 2 puzzle)
    public void OnTriggerStay2D(Collider2D collision) //if player coninues to stay in the spotlight during boss puzzle
    {

        if (collision.gameObject.tag == "Player" && collision is BoxCollider2D)//if the players box collidder stays inside the light
        {
            timeInLight += Time.deltaTime;

            if (timeInLight >= .9f) //if they remain in the light for more than 
            {
                timeInLight = 0;
                collision.gameObject.GetComponent<HealthDoctor>().takeDamage(15f);
            }

        }

    }
    public void OnTriggerExit2D(Collider2D collision) //when the player leaves the light reset timer so they aren't damaged twice in a rapid succession becuase the timeInLight  was .49999 secons
    {
        if (collision.gameObject.tag == "Player" && collision is BoxCollider2D)//if the players box collidder stays inside the light
        {
            timeInLight = 0;

        }
    }
}