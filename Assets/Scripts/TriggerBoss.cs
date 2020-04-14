using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public GameObject bossRef; //reference to the boss
    public GameObject bossPuzzleRef; //reference to the boss puzzle
    public GameObject lastSegmentPuzzleRef;//reference to the last segment of the boss puzzle

    private bool bossTriggered = false; //no reee
    public void OnTriggerEnter2D(Collider2D other)
    {
        //activates the boss and the boss puzzle when the plyaer colides with it
        if (other.gameObject.tag == "Player" && bossTriggered==false && other is BoxCollider2D) // if colliding with the player, the boss has not already been triggered, and the collider is a BoxCollider2D
        {

            //idea for boss intro
            //*cut music
            //light puzzle appears
            //lerp to the left and show the boss (do the roar)
            //boss music
            //potentially for ux polish lerp over to switch and give a red flashing arrow 
            bossRef.SetActive(true);
            bossPuzzleRef.SetActive(true);
            lastSegmentPuzzleRef.SetActive(true);

            //Do cutscene and active boss when finished
            bossRef.GetComponent<MoveLevelTwoBossRight>().enabled = false;
            StartCoroutine(doCutscene());
        }
    }

    IEnumerator doCutscene()
    {
        // start cutscene stuff here
        bossRef.gameObject.GetComponent<Cutscene>().beginCutscene();

        yield return new WaitForSeconds(8f);

        // Enable the boss
        bossRef.GetComponent<MoveLevelTwoBossRight>().enabled = true;
        bossTriggered = true; //REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
    }

}
