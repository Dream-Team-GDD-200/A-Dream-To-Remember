using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Button continueButton;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> sentences;

    private DialogueTrigger original;

    // Start is called before the first frame update
    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueTrigger dt, Dialogue dialogue)
    {

        original = dt;
        animator.SetBool("IsOpen", true);

        names.Clear();
        sentences.Clear();

        foreach(string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        continueButton.interactable = false;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        string sentence = sentences.Dequeue();

        nameText.text = name;
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        continueButton.interactable = true;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        original.DialogueDone();
    }
}
