using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject[] Door;

    //makes all doors for that room appear
    public void blockPath()
    {
        for(int i = 0; i < Door.Length; i++)
        {
            Debug.Log("Path Blocked");
            Door[i].GetComponent<SpriteRenderer>().enabled = true;
            Door[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }
    //Makes all doors for that room disapear
    public void openPath()
    {
        for (int i = 0; i < Door.Length; i++)
        {
            Debug.Log("Path unBlocked");
            Door[i].GetComponent<SpriteRenderer>().enabled = false;
            Door[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

