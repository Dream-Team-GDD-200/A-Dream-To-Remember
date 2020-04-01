using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using System;

public class PauseController : MonoBehaviour
{
    public GameObject pauseOverlay;
    public GameObject UI;
    AllThings MasterList;
    private void Start()
    {
        MasterList = GameObject.FindGameObjectWithTag("Player").GetComponent<AllThings>();
    }
    public void openMenu()
    {
        pauseOverlay.SetActive(true);
        UI.SetActive(false);
        try
        {
            GameObject.FindGameObjectWithTag("Boss").GetComponent<AIPath>().enabled = false;
        }catch(Exception e) { }
        MasterList.disableAll();
    }
    public void closeMenu()
    {
        UI.SetActive(true);
        pauseOverlay.SetActive(false);
        try
        {
            GameObject.FindGameObjectWithTag("Boss").GetComponent<AIPath>().enabled = true;
        }
        catch (Exception e) { }
        MasterList.enableAll();
    }
    public void worldSelect()
    {
        SceneManager.LoadScene("Overworld");
    }
    public void characterSelect()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
