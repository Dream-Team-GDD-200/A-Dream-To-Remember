using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KILLBOSS : MonoBehaviour
{
    public Sprite left;
    bool hasBeenPushed = false;
    public GameObject Boss;
    public GameObject Transition; //reference to transtion ui element
    // Start is called before the first frame update
    public GameObject MemFragUI;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hasBeenPushed == false && other is BoxCollider2D)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
            hasBeenPushed = true;
           StartCoroutine(SceneTransition());
        }
    }

   IEnumerator SceneTransition()
     {

        yield return new WaitForSeconds(.1f); //basically we are waiting until boss death is finsihed
        Boss.SetActive(false);

        yield return StartCoroutine(Transition.GetComponent<FadeOut>().UndoFade()); //wait until the coroutine is done (this is making the black square appear)


        //TO-DO : pass in values to show that level 1 is complete


        // I might make these lines of code in the transition script and just make it call a new function LevelChange with below lines in that method
        Scene scene = SceneManager.GetActiveScene(); //returns current scene --used to accesname

        switch (scene.name)
        {
            case "Level-1": //if scene is on level 1
            PlayerPrefs.SetInt("level1clear", 1); //raises a flag that tells us the level one is done
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasSkill(2,true); //gives the player the shock skill
            //GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().grantSkill(2);
            PlayerPrefs.SetInt("PostStory1Told", 0);
            break;

            case "Level-2": //if scene is on level 2
            PlayerPrefs.SetInt("level2clear", 1); //raises a flag that tells us the level 2 is done
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasSkill(3, true); //gives the player the nurse skill
            //GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().grantSkill(3);
            PlayerPrefs.SetInt("PostStory2Told", 0);
            break;

            case "Level-3": //if scene is on level 2
            PlayerPrefs.SetInt("level3clear", 1); //raises a flag that tells us the level 2 is done
            PlayerPrefs.SetInt("PostStory3Told", 0);
            break;

        }
        MemFragUI.GetComponent<MemoryFragmentsUI>().saveMemoryFragments();
        SceneManager.LoadScene("Overworld"); //return to the overworld, 


        
    }
}
