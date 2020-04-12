using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHandlerPuzzleScript : MonoBehaviour
{
    private bool isRunning = false;
    public float flashDuration = 0; //the time it stays active  and the time it stays inactive (full cycle is 2 * flashDuration)
   
    // Update is called once per frame
    void Update()
    {
        if (isRunning == false) //if not currently running coroutine, run coroutine --this is a little jank but it was the quickest way I could think to do this (change later maybe)
        {

            StartCoroutine(Flashing());
            isRunning = true;
        }

    }
    IEnumerator Flashing() //lights will start out active in scene, they will contiunue to be active in the scene for flashDuration seconds, they will then turn off for flashDuration seconds
    {
      
       yield return new WaitForSeconds(flashDuration); //waits flashDuration (active period)


        for (int i = 0; i < this.gameObject.transform.childCount; i++) //settting all children of the header to not active
        {
            var child = this.gameObject.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }


        yield return new WaitForSeconds(flashDuration); //waits flashDuration (cooldown period)

        for (int i = 0; i < this.gameObject.transform.childCount; i++) //settting all children of the header to active
        {
            var child = this.gameObject.transform.GetChild(i).gameObject;
            child.SetActive(true);
        }

      
        isRunning = false; //Flashing() ends, so set isRunning to false
    }
}
