﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    public GameObject Male;
    public GameObject Female;
    public Button StartButton;
    private void Start()
    {
        PlayerPrefs.SetInt("isFemale", 0);
    }
    public void startGame()
    {
        //set the 3 levels to not clear
        PlayerPrefs.SetInt("level1clear", 0);
        PlayerPrefs.SetInt("level2clear", 0);
        PlayerPrefs.SetInt("level3clear", 0);
        SceneManager.LoadScene(3);
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
}
