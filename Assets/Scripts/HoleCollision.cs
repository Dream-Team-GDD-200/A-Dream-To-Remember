using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HoleCollision : MonoBehaviour
{
    bool BoxFallFlag = false;
    
    float lerpPosition = 0.0f;
    float lerpTime = 1.0f; // This is the number of seconds the Lerp will take
    Vector2 start;
    Vector2 end;
    GameObject puzzleBox, Hole;
    // Start is called before the first frame update
    void Start()
    {
        end = this.transform.position;
        Hole = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoxFallFlag)
        {
            lerpPosition += Time.deltaTime / lerpTime;
            puzzleBox.transform.position = Vector2.Lerp(start, end, lerpPosition);
            if (puzzleBox.transform.position.x == transform.position.x && puzzleBox.transform.position.y == transform.position.y)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the Puzzle box has collided
        if (!(other.gameObject.name.Equals("Doctor")))
        {
            puzzleBox = other.gameObject;
            start = puzzleBox.transform.position;
            other.isTrigger = true;
            //this.gameObject.SetActive(false);
            BoxFallFlag = true;
        }
    }
}

