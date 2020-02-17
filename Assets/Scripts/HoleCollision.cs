using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HoleCollision : MonoBehaviour
{
    bool BoxFallFlag = false;
    bool BoxHasFalled = false;
    float rateOfFall = .1f;
    public Vector2 FinalPosition;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the Puzzle box has collided
        if (other.gameObject.name.Equals("Puzzle Box"))
        {
            //set both objects for hole collision to disapear and not be active
            GameObject.Find("Hole").SetActive(false);
            this.gameObject.SetActive(false);
            //move the box to the holes position
            other.transform.position = transform.position;
            //make it so the box cant be collided with
            other.isTrigger = true;
        }
    }
}

