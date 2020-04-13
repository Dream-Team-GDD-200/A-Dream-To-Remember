using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    public GameObject Male;
    public GameObject Female;
    public Button StartButton;
    public GameObject Transitionref;
    public GameObject UICanvas;

    private bool doTransition = false;

    public Camera cam;

    private float camSize = 5f;

    private float timeStartedLerping;

    private Vector3 camMoveTo = new Vector3(0, 2.05f, -1);
    private Vector3 docCamPos;

    private void Start()
    {
        //sets the resolution to the same as what we want so it work on all builds
        if(SystemInfo.deviceType == DeviceType.Desktop){
            Screen.SetResolution(1200, 800, false, 60);
        }else if(SystemInfo.deviceType == DeviceType.Handheld){
            Screen.SetResolution(1200,800, true, 30);
        }
       
        if(!PlayerPrefs.HasKey("isFemale")){
            PlayerPrefs.SetInt("isFemale", 0);
        }
        if(!PlayerPrefs.HasKey("LastLevel")){
            PlayerPrefs.SetInt("LastLevel", 1);
        }
        PlayerPrefs.SetInt("MemFrags", 0);
        docCamPos = new Vector3(cam.transform.position.x, cam.transform.position.y, -1);
    }
    public void startGame()
    {
        //set the 3 levels to not clear
        if(!PlayerPrefs.HasKey("level1clear")){
            PlayerPrefs.SetInt("level1clear", 0);
        }else if(!PlayerPrefs.HasKey("level1clear")){
            PlayerPrefs.SetInt("level2clear", 0);
        }else if(!PlayerPrefs.HasKey("level1clear")){
            PlayerPrefs.SetInt("level3clear", 0);
        }
        UICanvas.GetComponent<Canvas>().enabled = false;
        timeStartedLerping = Time.time;
        doTransition = true;
        StartCoroutine(switchScene());
    }
    public void playerSelect()
    {
        Male.SetActive(true);
        Female.SetActive(true);
    }
    public void selectMale()
    {
        PlayerPrefs.SetInt("isFemale", 0); // 0 is male
        StartButton.interactable = true;
    }
    public void selectFemale()
    {
        PlayerPrefs.SetInt("isFemale", 1); // 1 is female
        StartButton.interactable = true;
    }
    void Update()
    {
        if (doTransition)
        {
            cam.transform.position = Lerp(docCamPos, camMoveTo, timeStartedLerping, 1f);
            cam.orthographicSize = shrink(camSize, .1f, timeStartedLerping, 1f);
        }
    }

    private Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        var result = Vector3.Lerp(start, end, percentageComplete);
        return result;
    }

    private float shrink(float initSize, float endSize, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = 1 - timeSinceStarted / lerpTime;
        float difference = initSize - endSize;
        float result = difference * percentageComplete + endSize;
        Debug.Log("percent: " + percentageComplete + " difference: " + difference + " result: " + result);
        return result;
    }

    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(1f);
        doTransition = false;
        SceneManager.LoadScene(3);
    }
}
