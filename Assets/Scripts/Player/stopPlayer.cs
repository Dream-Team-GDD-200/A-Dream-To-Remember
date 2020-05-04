using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPlayer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            GameObject.FindWithTag("Player").GetComponent<IceStopper>().stopSlidding = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            GameObject.FindWithTag("Player").GetComponent<IceStopper>().stopSlidding = false;

        }
    }


}
