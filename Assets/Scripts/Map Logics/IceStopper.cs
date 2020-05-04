using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceStopper : MonoBehaviour
{
    public bool stopSlidding = false;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( (collision.gameObject.tag =="Wall"||collision.gameObject.tag=="Rock") && IceLogic.PlayerIsSlidding==true)//if player collides with a wall or a rock stop slidding
        {
            stopSlidding = true;
            Vector2 temp = gameObject.GetComponent<PlayerMovement>().movement;
            temp *= -0.10f; //mvoes them a little ways a way from the wall dadadadadadadadad
            Debug.Log(temp);
            gameObject.transform.position = gameObject.transform.position + new Vector3(temp.x, temp.y, 0); //bump player a bit away from where they collided
            

        }
    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
       if(collision.collider is BoxCollider2D)
        {
            stopSlidding = false; // can slide again
        }
     
    }
    */


}
