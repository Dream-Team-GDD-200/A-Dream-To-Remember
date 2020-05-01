using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject Male;
    public GameObject Female;
    public Button ControlButton;
    public Button StartButton;
    public GameObject Transitionref;
    public GameObject UICanvas;
    public GameObject Controls;

    private bool doTransition = false;
    [Header("Camera")]
    public Camera cam;

    private float camSize = 5f;

    private float timeStartedLerping;

    private Vector3 camMoveTo = new Vector3(0, 2.05f, -1);
    private Vector3 docCamPos;

    public GameObject preGameUI;
    public GameObject resetProgressUI;

    private void Start()
    {
        resetProgressUI.SetActive(false);

        //sets the resolution to the same as what we want so it work on all builds
        if(SystemInfo.deviceType == DeviceType.Desktop){
            Screen.SetResolution(1280, 800, false, 60);
            PlayerPrefs.SetInt("Controls", 1); // 1 is the controls for pc
        }else if(SystemInfo.deviceType == DeviceType.Handheld){
            Screen.SetResolution(1280,800, true, 30);
            PlayerPrefs.SetInt("Controls", 0); // 0 is the controls for mobile'
            ControlButton.enabled = false;
        }
       
        if(!PlayerPrefs.HasKey("isFemale")){
            PlayerPrefs.SetInt("isFemale", 0);
        }
        if(!PlayerPrefs.HasKey("LastLevel")){
            PlayerPrefs.SetInt("LastLevel", 1);
        }
        if(!PlayerPrefs.HasKey("FirstStory"))
        {
            PlayerPrefs.SetInt("FirstStory", 0);
        }
        if (!PlayerPrefs.HasKey("MemFrags"))
        {
            PlayerPrefs.SetInt("MemFrags", 0);
        }
        docCamPos = new Vector3(cam.transform.position.x, cam.transform.position.y, -1);
    }
    public void startGame()
    {
 
        //set the 3 levels to not clear
        if (!PlayerPrefs.HasKey("level1clear")){
            PlayerPrefs.SetInt("level1clear", 0);
        }else if(!PlayerPrefs.HasKey("level1clear")){
            PlayerPrefs.SetInt("level2clear", 0);
        }else if(!PlayerPrefs.HasKey("level1clear")){
            PlayerPrefs.SetInt("level3clear", 0);
        }

        if (SceneManager.GetActiveScene().name == "CharacterSelect") //if in characters selsect
        {
            StartCoroutine(AltSwitchScene());
        }
        else //on  main menu
        {
            UICanvas.GetComponent<Canvas>().enabled = false;
            timeStartedLerping = Time.time;
            doTransition = true;
            StartCoroutine(switchScene());
        }
 
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

    IEnumerator switchScene() //zoom in transition for main menu
    {
        yield return new WaitForSeconds(1f);
        doTransition = false;
     

        if (PlayerPrefs.GetInt("FirstStory") == 0)
        {
            PlayerPrefs.SetInt("FirstStory", 1);
            SceneManager.LoadScene(7);
        } else
        {
            SceneManager.LoadScene(3);
        }
    }
    IEnumerator AltSwitchScene() //transition used for character select scene
    {
        //best code, i swear
        GameObject.FindWithTag("CharacterSelectButtonContainer").gameObject.transform.GetChild(0).GetComponent<Button>().interactable = false;
        GameObject.FindWithTag("CharacterSelectButtonContainer").gameObject.transform.GetChild(1).GetComponent<Button>().interactable = false;
        GameObject.FindWithTag("CharacterSelectButtonContainer").gameObject.transform.GetChild(2).GetComponent<Button>().interactable = false;
        GameObject.FindWithTag("CharacterSelectButtonContainer").gameObject.transform.GetChild(3).GetComponent<Button>().interactable = false;
        GameObject.FindWithTag("CharacterSelectButtonContainer").gameObject.transform.GetChild(4).GetComponent<Button>().interactable = false;
        GameObject.FindWithTag("CharacterSelectButtonContainer").gameObject.transform.GetChild(5).GetComponent<Button>().interactable = false;
        
        yield return StartCoroutine(Transitionref.GetComponent<FadeOut>().UndoFade());


        if (PlayerPrefs.GetInt("FirstStory") == 0)
        {
            PlayerPrefs.SetInt("FirstStory", 1);
            SceneManager.LoadScene(7);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }

    public void openControls()
    {
        if (Controls.activeSelf)
        {
            Controls.SetActive(false);
        }
        else
        {
            Controls.SetActive(true);
        }
    }

    public void resetBtn()
    {
        resetProgressUI.SetActive(true);
        preGameUI.SetActive(false);
    }

    public void resetProgress()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("isFemale", 0);

        PlayerPrefs.SetInt("LastLevel", 1);

        PlayerPrefs.SetInt("FirstStory", 0);

        PlayerPrefs.SetInt("MemFrags", 0);

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Screen.SetResolution(1200, 800, false, 60);
            PlayerPrefs.SetInt("Controls", 1); // 1 is the controls for pc
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Screen.SetResolution(1200, 800, true, 30);
            PlayerPrefs.SetInt("Controls", 0); // 0 is the controls for mobile'
            ControlButton.enabled = false;
        }

        resetProgressUI.SetActive(false);
        preGameUI.SetActive(true);
        StartButton.interactable = false;
    }

    public void noBtn()
    {
        resetProgressUI.SetActive(false);
        preGameUI.SetActive(true);
    }
}
