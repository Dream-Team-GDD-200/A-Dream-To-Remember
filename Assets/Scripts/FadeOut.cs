using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    //more general script, level loading and transitions (puzzle reset transition is different)
    public GameObject UI;
   private bool overWriteJoel =true;
    IEnumerator Start()
    {
        


        yield return new WaitForSeconds(.5f);

        StartCoroutine(DoFade()); //at the start of level, start fading the blacksquare

    
    }
    void LateUpdate() //had to do this to fix  joel's programm from constantly overwritting the ui in overworld
    {
        if(overWriteJoel ==true)
        {
           UI.SetActive(false);
        }
    }

    //Unity didn't like it when i tried to do the startCoroutine method from another script, so I just made it so it called one of these two functions -- change later if I find another way but this will work


    // Update is called once per frame
   public IEnumerator DoFade()  //fade the black square ui element

    { 
        Time.timeScale = 0;
        UI.SetActive(false);


       //pause game during transition (we probably don't want them to be able to move during black screen)
     
        CanvasGroup blackSquare = GetComponent<CanvasGroup>(); //I added the  group component to the black screen object only... so it's a group of one ... kinda jank but it allowed it to work as I couldn't access a spirte or anything 
        while(blackSquare.alpha > 0)
        {
            blackSquare.alpha -= Time.unscaledDeltaTime / 2;
            yield return null; //wait for next frame before doing it again
        }
        yield return null; // extra assurance that it is done 




        
        Time.timeScale = 1; //now that we know for sure that it is done, unpause the game
       overWriteJoel = false;
        UI.SetActive(true);


    }
     public IEnumerator UndoFade() //this will be called at the end of levels or during puzzle reset switch, black sc reen will appear again
    {


        UI.SetActive(false);

        Time.timeScale = 0; //pause game during transition (we probably don't want them to be able to move during black screen
        CanvasGroup blackSquare = GetComponent<CanvasGroup>();
        while (blackSquare.alpha < 1)
        {
            blackSquare.alpha += Time.unscaledDeltaTime / 2;
            yield return null; //wait for next frame before doing it again
        }
        yield return null; // extra assurance that it is done 
                           //changing timescale back to 1 seems unnecessary as when the DoFade function is called (which will almost always be called soon after this one) it resets time back to 1, and if we are changing to a new scene it doesn't matter since time will reset

    }
}
