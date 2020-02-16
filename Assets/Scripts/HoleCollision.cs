using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HoleCollision : MonoBehaviour
{
    bool BoxFallFlag = false;
    
    float lerpPosition = 0.0f;
    float lerpTime = 1.0f; // This is the number of seconds the Lerp will take
    Vector3 start;
    Vector3 end;
    GameObject puzzleBox, Hole;
    // Start is called before the first frame update
    void Start()
    {
        puzzleBox = GameObject.Find("Puzzle Box");
        Hole = GameObject.Find("Hole");
        end = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (BoxFallFlag)
        {
            lerpPosition += Time.deltaTime / lerpTime;
            puzzleBox.transform.position = Vector3.Lerp(start, end, lerpPosition);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the Puzzle box has collided
        if (other.gameObject.name.Equals("Puzzle Box"))
        {
            start = puzzleBox.transform.position;
            other.isTrigger = true;
            Hole.SetActive(false);
            Hole.SetActive(false);
            BoxFallFlag = true;
        }
    }
}

