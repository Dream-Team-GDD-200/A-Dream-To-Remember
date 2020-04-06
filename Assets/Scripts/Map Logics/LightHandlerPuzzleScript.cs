using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHandlerPuzzleScript : MonoBehaviour
{
    private bool isRunning = false;
   
    // Update is called once per frame
    void Update()
    {
        if (isRunning == false) //if not currently running coroutine, run coroutine --this is a little jank but it was the quickest way I could think to do this (change later maybe)
        {

            StartCoroutine(Flashing());
            isRunning = true;
        }

    }
    IEnumerator Flashing()
    {
        yield return new WaitForSeconds(1f); //waits .75 seconds at start of period

        for (int i = 0; i < this.gameObject.transform.childCount; i++) //settting all children of the header to active
        {
            var child = this.gameObject.transform.GetChild(i).gameObject;
            child.SetActive(true);
        }

        yield return new WaitForSeconds(1f); //waits .75 secibds

        for (int i = 0; i < this.gameObject.transform.childCount; i++) //settting all children of the header to not active
        {
            var child = this.gameObject.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }

        isRunning = false; //Flashing() ends, so set isRunning to false
    }
}
