using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleResetMenuHandler : MonoBehaviour
{
    public GameObject currentResetSwitch; //this is how it keeps a reference to what switch is being used - this is important as it needs to know what prefab to reset

    //the rest of the handler is done via the buttons, which call the correct reset/don't reset switch based on the reference above.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void  Yes()
    {
        currentResetSwitch.GetComponent<PuzzleResetScript>().ResetPuzzle();
    }
    public void  No()
    {
        currentResetSwitch.GetComponent<PuzzleResetScript>().DontResetPuzzle();
    }
}
