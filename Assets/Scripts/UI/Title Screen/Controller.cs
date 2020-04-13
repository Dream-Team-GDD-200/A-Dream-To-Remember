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
        }else{
            StartButton.interactable = true;
        }
        if(!PlayerPrefs.HasKey("LastLevel")){
            PlayerPrefs.SetInt("LastLevel", 1);
        }
        PlayerPrefs.SetInt("MemFrags", 0);
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
        StartCoroutine(Transition()); //starts couroutine for a specific order
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
    void info()
    {

    }
    IEnumerator Transition()
    {
        yield return StartCoroutine(Transitionref.GetComponent<FadeOut>().UndoFade()); //black square appears
        SceneManager.LoadScene(3);
    }
}
