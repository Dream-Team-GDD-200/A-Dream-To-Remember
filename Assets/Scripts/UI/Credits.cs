using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public Image Ipanel;

    private bool doFadePanel = false;

    private float timeStarted;
    Color tempColor;

    public GameObject AllText;

    private bool moveText = false;

    private bool creditsDone = false;

    public FadeOut fOut;

    void Start()
    {
        tempColor = Ipanel.color;
        tempColor.a = 0f;
        Ipanel.color = tempColor;
        StartCoroutine(StartCreditRoll());
    }

    void Update()
    {
        if (doFadePanel)
        {
            tempColor.a = Lerp(0f, 0.686f, timeStarted, 5f);
            Ipanel.color = tempColor;
        }

        if (moveText)
        {
            AllText.transform.position = AllText.transform.position + new Vector3(0f, 0.55f, 0f);
            if (AllText.transform.localPosition.y >= (1225f + 400f))
            {
                moveText = false;
                creditsDone = true;
            }
        }

        //If the credits are done, then check for input to go to title screen
        if (creditsDone)
        {
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                StartCoroutine(FadeOutScene());
            }
        }
    }

    private float Lerp(float start, float end, float timeStart, float timeToComplete = 1f)
    {
        float timeSinceStart = Time.time - timeStart;
        float percentComplete = timeSinceStart / timeToComplete;
        float result = Mathf.Lerp(start, end, percentComplete);
        return result;
    }

    IEnumerator StartCreditRoll()
    {
        yield return new WaitForSeconds(3f);

        doFadePanel = true;
        moveText = true;
        timeStarted = Time.time;

        yield return new WaitForSeconds(5f);

        doFadePanel = false;
    }

    IEnumerator FadeOutScene()
    {
        yield return StartCoroutine(fOut.UndoFade());

        SceneManager.LoadScene(0);
    }
}
