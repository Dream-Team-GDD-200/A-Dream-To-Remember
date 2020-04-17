using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(this, dialogue);
    }

    public void DialogueDone()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            FindObjectOfType<Movement>().DialogueTransitionLevel();
        }
    }
}
