using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HoleCollision : MonoBehaviour
{
    bool BoxFallFlag = false;
    
    float lerpPosition = 0.0f;
    float lerpTime = 1.0f; // This is the number of seconds the Lerp will take
    Vector2 start; // Starting position for lerp
    Vector2 end; // destination for lerp
    GameObject puzzleBox, Hole; 
    // Start is called before the first frame update
    void Start()
    {
        end = this.transform.position; // set the destination as the position for the hole
    }

    // Update is called once per frame
    void Update()
    {
        // Only do the lerp after a box collides with the whole
        if (BoxFallFlag)
        {
            // update the position for lerp
            lerpPosition += Time.deltaTime / lerpTime;
            // apply the lerp to the position of the box
            puzzleBox.transform.position = Vector2.Lerp(start, end, lerpPosition);
            // When the box is done moving set the whole as not active
            if (puzzleBox.transform.position.x == transform.position.x && puzzleBox.transform.position.y == transform.position.y)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks for collision and make sure it  isn't doctor
        if (!(other.gameObject.name.Equals("Doctor")))
        {
            // set the object that is falling into the hole as the object colliding with hole
            puzzleBox = other.gameObject;
            // the starting position is the box's position when it collides with the hole
            start = puzzleBox.transform.position;
            // set the box to trigger so you can pass over/through it
            other.isTrigger = true;
            // set the flag for the collision as true which will start the lerp
            BoxFallFlag = true;
        }
    }
}

