using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostLevelStory : MonoBehaviour
{
    public DialogueTrigger postLevel1;
    public DialogueTrigger postLevel2;
    public DialogueTrigger postLevel3;

    void Update()
    {
        if (PlayerPrefs.GetInt("level1clear") == 1 && PlayerPrefs.GetInt("PostStory1Told") == 0) 
        {
            postLevel1.TriggerDialogue();
            PlayerPrefs.SetInt("PostStory1Told", 1);
            FindObjectOfType<Movement>().setInDialogue(true);
        }

        if (PlayerPrefs.GetInt("level2clear") == 1 && PlayerPrefs.GetInt("PostStory2Told") == 0)
        {
            postLevel2.TriggerDialogue();
            PlayerPrefs.SetInt("PostStory2Told", 1);
            FindObjectOfType<Movement>().setInDialogue(true);
        }

        if (PlayerPrefs.GetInt("level3clear") == 1 && PlayerPrefs.GetInt("PostStory3Told") == 0)
        {
            postLevel3.TriggerDialogue();
            PlayerPrefs.SetInt("PostStory3Told", 1);
            PlayerPrefs.SetInt("GoToWinScreen", 1);
            FindObjectOfType<Movement>().setInDialogue(true);
        }
    }
}
