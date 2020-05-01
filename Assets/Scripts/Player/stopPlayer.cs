using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPlayer : MonoBehaviour
{
    //used to stop player during ice puzzles (kinda jank but it works)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindWithTag("Player").GetComponent<IceStopper>().stopSlidding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.FindWithTag("Player").GetComponent<IceStopper>().stopSlidding = false;
    }


}
