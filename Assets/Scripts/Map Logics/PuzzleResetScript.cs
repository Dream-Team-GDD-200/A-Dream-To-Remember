using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleResetScript : MonoBehaviour
{
    //
  
    public GameObject currentPrefabInstance;
    public GameObject refToPrefabDefault;
    public GameObject resetPuzzleMenu; //reference used to set if menu is active or not
    private SpriteRenderer resetButton; //temp using this to tell when button has been pressed
    bool hasBeenPushed = false;
    private GameObject tempSwitchHolder;

    private IEnumerator fade;
    private IEnumerator unFade;



    private GameObject puzzleResetTransition;
    
    public GameObject refToUI;

    // Start is called before the first frame update
    void Start()
    {
        resetButton = GetComponent<SpriteRenderer>();
        resetPuzzleMenu.SetActive(false); //set the menu as not active by default
        puzzleResetTransition = GameObject.FindGameObjectWithTag("Transition");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hasBeenPushed == false && other is BoxCollider2D)
        {
            hasBeenPushed = true;//makes sure multiple menus aren't open during this time
            resetButton.color = Color.green; //indicate button is currently pressed down
            
            //have to have ui stay on for menu to show up, and loop was giving me errors, this worked though XD... make into loop later
            //basically, this is looking at the first attached child to ui element, then the second and then so on
        
            //disabling joystick had a weird glitch attached where it would jam in last pushed location. For now, it will stay active as it doesn't cause any problems 
            refToUI.gameObject.transform.GetChild(1).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(2).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(3).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(4).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(5).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(6).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(7).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(8).gameObject.SetActive(false); //sets UI as not active at first
            refToUI.gameObject.transform.GetChild(9).gameObject.SetActive(false); //sets UI as not active at first
           

            resetPuzzleMenu.SetActive(true); //menu is active now (and is the only active piece of UI)

            resetPuzzleMenu.GetComponent<PuzzleResetMenuHandler>().currentResetSwitch = this.gameObject; //sets the current reset switch to the one that was just pressed
            Time.timeScale = 0f; //pauses game during this time -- this line is kinda redundant with FadeOut, but I want to make sure that time is stopped when the player is selecting an option for the reset puzzle menu
        }
    }
    public void ResetPuzzle() //player pressed yes on resetPuzzleMenu, will reset puzzle to prefab default settings
    {

       StartCoroutine(fadeInAndOut());

    }
    public void DontResetPuzzle() //player pressed no on resetPuzzleMenu, returns game to normal
    {

        //have to have ui stay on for menu to show up, and loop was giving me errors, this worked though XD... make into loop later
       // puzzlereset menu, skill trees stay off

   
        refToUI.gameObject.transform.GetChild(1).gameObject.SetActive(true); 
        refToUI.gameObject.transform.GetChild(2).gameObject.SetActive(true); 
        refToUI.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        refToUI.gameObject.transform.GetChild(4).gameObject.SetActive(true); 
        refToUI.gameObject.transform.GetChild(5).gameObject.SetActive(true); 
        refToUI.gameObject.transform.GetChild(9).gameObject.SetActive(true); 
        resetPuzzleMenu.SetActive(false);
        Time.timeScale = 1f; //unpauses game  -- this one is still needed in this function (unlike the restpuzzle function) as neither fade functions are called here
        Invoke("AllowPlayerToPressButtonAgain", 2f);
    }
    public void AllowPlayerToPressButtonAgain()
    {
        hasBeenPushed = false;
        resetButton.color = Color.white;
    }


    private IEnumerator fadeInAndOut() //dont judge me, it works --unique version of it that requires it to be resued as it needs to be executed in a very specific order
    {
        
        Time.timeScale = 0; //pause game during transition (we probably don't want them to be able to move during black screen
        CanvasGroup blackSquare = puzzleResetTransition.GetComponent<CanvasGroup>();
        while (blackSquare.alpha < 1)
        {
            blackSquare.alpha += Time.unscaledDeltaTime / 2;
            yield return null; //wait for next frame before doing it again
        }
        yield return null; // extra assurance that it is done 
                           //changing timescale back to 1 seems unnecessary as when the DoFade function is called (which will almost always be called soon after this one) it resets time back to 1, and if we are changing to a new scene it doesn't matter since time will reset

        Destroy(currentPrefabInstance); //destroys current prefab instance
        currentPrefabInstance = (GameObject)Instantiate(refToPrefabDefault);
        resetPuzzleMenu.SetActive(false);


    
        while (blackSquare.alpha > 0)
        {
            blackSquare.alpha -= Time.unscaledDeltaTime / 2;
            yield return null; //wait for next frame before doing it again
        }
        yield return null; // extra assurance that it is done 

    
        refToUI.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        refToUI.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        refToUI.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        refToUI.gameObject.transform.GetChild(4).gameObject.SetActive(true);
        refToUI.gameObject.transform.GetChild(5).gameObject.SetActive(true);
        refToUI.gameObject.transform.GetChild(9).gameObject.SetActive(true);
        Time.timeScale = 1; //now that we know for sure that it is done, unpause the game


        Invoke("AllowPlayerToPressButtonAgain", 2f); // after two seconds, button is pressable again
    }
}

