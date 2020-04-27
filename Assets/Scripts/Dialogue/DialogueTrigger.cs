using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private FadeOut fOut;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(this, dialogue);
        fOut = FindObjectOfType<FadeOut>();
    }

    public void DialogueDone()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && dialogue.isPreStory)
        {
            FindObjectOfType<Movement>().DialogueTransitionLevel();
        } 
        else if (SceneManager.GetActiveScene().buildIndex == 3 && dialogue.isPostStory)
        {
            FindObjectOfType<Movement>().setInDialogue(false);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && dialogue.isOverworldClearTrigger)
        {
            FindObjectOfType<Movement>().setInDialogue(false);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3 && PlayerPrefs.GetInt("level3clear") == 1 && PlayerPrefs.GetInt("PostStory3Told") == 1 && PlayerPrefs.GetInt("GoToWinScreen") == 1)
        {
            PlayerPrefs.SetInt("GoToWinScreen", 0);
            StartCoroutine(triggerWin());
        }
    }

    IEnumerator triggerWin()
    {
        yield return StartCoroutine(fOut.UndoFade());
        SceneManager.LoadScene(8);
    }
}
