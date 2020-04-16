using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreStory : MonoBehaviour
{
    public Text UpperText;
    public Text MiddleText;
    public Text LowerText;
    public Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        UpperText.color = new Color(UpperText.color.r, UpperText.color.g, UpperText.color.b, 0);
        MiddleText.color = new Color(MiddleText.color.r, MiddleText.color.g, MiddleText.color.b, 0);
        LowerText.color = new Color(LowerText.color.r, LowerText.color.g, LowerText.color.b, 0);
        ColorBlock cb = continueButton.colors;
        cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, 0);
        continueButton.colors = cb;
        StartCoroutine(FadeAll());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continueBtn()
    {
        SceneManager.LoadScene(3);
    }


    IEnumerator FadeAll()
    {
        yield return StartCoroutine(FadeIn(3f, UpperText));

        yield return StartCoroutine(FadeIn(4f, MiddleText));

        yield return StartCoroutine(FadeIn(3f, LowerText));

        yield return StartCoroutine(FadeInBtn(3f, continueButton));
    }
    
    IEnumerator FadeIn(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    IEnumerator FadeInBtn(float t, Button i)
    {
        ColorBlock cb = i.colors;
        cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, 0);
        while (cb.normalColor.a < 1.0f)
        {
            cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, cb.normalColor.a + (Time.deltaTime / t));
            i.colors = cb;
            yield return null;
        }
    }
}
