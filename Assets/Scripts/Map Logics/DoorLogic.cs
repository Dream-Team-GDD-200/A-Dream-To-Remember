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
            Door[i].GetComponent<DoorSpriteSwitcher>().close();
            Door[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }
    //Makes all doors for that room disapear
    public void openPath()
    {
        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].GetComponent<DoorSpriteSwitcher>().open();
            Door[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

