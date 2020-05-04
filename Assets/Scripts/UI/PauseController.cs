using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [Header("UI and Overlays")]
    public GameObject pauseOverlay;
    public GameObject UI;
    public GameObject ControlsOverlay;
    public GameObject ReferenceToTransition;
    [Header("Scripts and Transforms")]
    AllThings MasterList;
    Transform deactivateButton;
    [Header("Buttons")]
    public Button WorldSelect, MainMenu;
    public Button Controls;
    [Header("Other")]
    public bool isactive;
    private void Start()
    {
        try
        {
            MasterList = GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>();
        }catch(Exception e) { }
        if(SceneManager.GetActiveScene().name == "Overworld")
        {
            WorldSelect.interactable = false;
        }else if (SceneManager.GetActiveScene().name == "Title Screen")
        {
            MainMenu.interactable = false;
        }
        if(PlayerPrefs.GetInt("Controls") == 0)
        {
            Controls.gameObject.SetActive(false);
        }
    }
    public void openMenu()
    {
        pauseOverlay.SetActive(true);
        UI.SetActive(false);
        try
        {
            MasterList.disableAll();
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Boss").GetComponent<AIPath>().enabled = false;
        }catch(Exception e) { }
       
    }
    public void closeMenu()
    {
        UI.SetActive(true);
        pauseOverlay.SetActive(false);
        try
        {
            MasterList.enableAll();
            Time.timeScale = 1;
            GameObject.FindGameObjectWithTag("Boss").GetComponent<AIPath>().enabled = true;
        }
        catch (Exception e) { }
    }
    public void worldSelect()
    {
        StartCoroutine(transitionToOverWorld());
    }
    public void characterSelect()
    {
        StartCoroutine(transitionToCharacterSelect());
    }
    public void openControls()
    {
        if (ControlsOverlay.activeSelf)
        {
            ControlsOverlay.SetActive(false);
            isactive = false;
        }
        else
        {
            ControlsOverlay.SetActive(true);
            isactive = true;
        }
    }

    IEnumerator transitionToOverWorld() //transition to overworld with fade script
    {
        pauseOverlay.SetActive(false);
        yield return StartCoroutine(ReferenceToTransition.GetComponent<FadeOut>().UndoFade());
        SceneManager.LoadScene("Overworld");
    }

    IEnumerator transitionToCharacterSelect()
    {
        pauseOverlay.SetActive(false);
        yield return StartCoroutine(ReferenceToTransition.GetComponent<FadeOut>().UndoFade());
        SceneManager.LoadScene("CharacterSelect");
    }
}
