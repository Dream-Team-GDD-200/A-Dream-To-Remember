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
 
    // Start is called before the first frame update
    void Start()
    {
        resetButton = GetComponent<SpriteRenderer>();
        resetPuzzleMenu.SetActive(false); //set the menu as not active by default
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
            resetPuzzleMenu.SetActive(true); //menu is active now

            resetPuzzleMenu.GetComponent<PuzzleResetMenuHandler>().currentResetSwitch = this.gameObject;
            Time.timeScale = 0f; //pauses game during this time
            //this.GetComponent<GameObject>(); //sets the reference in the resetPuzzleMenuHandler to this gameswitch
        }
    }
    public void ResetPuzzle() //player pressed yes on resetPuzzleMenu, will reset puzzle to prefab default settings
    {
     
        Destroy(currentPrefabInstance); //destroys current prefab instance
        currentPrefabInstance = (GameObject)Instantiate(refToPrefabDefault);
        resetPuzzleMenu.SetActive(false);
        Time.timeScale = 1f; //unpauses game
        Invoke("AllowPlayerToPressButtonAgain", 2f);

    }
    public void DontResetPuzzle() //player pressed no on resetPuzzleMenu, returns game to normal
    {
        resetPuzzleMenu.SetActive(false);
        Time.timeScale = 1f; //unpuases game
        Invoke("AllowPlayerToPressButtonAgain", 2f);
    }
    public void AllowPlayerToPressButtonAgain()
    {
        hasBeenPushed = false;
        resetButton.color = Color.white;
    }
}

