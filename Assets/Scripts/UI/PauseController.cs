using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject pauseOverlay;
    public GameObject UI;
    AllThings MasterList;
    Transform deactivateButton;
    public Button WorldSelect, MainMenu;
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
    }
    public void openMenu()
    {
        pauseOverlay.SetActive(true);
        UI.SetActive(false);
        try
        {
            MasterList.disableAll();
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
            GameObject.FindGameObjectWithTag("Boss").GetComponent<AIPath>().enabled = true;
        }
        catch (Exception e) { }
    }
    public void worldSelect()
    {
        SceneManager.LoadScene("Overworld");
    }
    public void characterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
}
