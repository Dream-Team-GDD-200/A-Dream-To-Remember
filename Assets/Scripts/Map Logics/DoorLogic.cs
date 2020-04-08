using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject[] Door;
    [Header("Collider to Block Path")]
    public BoxCollider2D[] Blocker;

    //makes all doors for that room appear
    public void blockPath()
    {
        for(int i = 0; i < Door.Length; i++)
        {
            Door[i].GetComponent<DoorSpriteSwitcher>().close();
            Blocker[i].enabled = true;
        }
    }
    //Makes all doors for that room disapear
    public void openPath()
    {
        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].GetComponent<DoorSpriteSwitcher>().open();
            Blocker[i].enabled = false;
        }
    }
}

