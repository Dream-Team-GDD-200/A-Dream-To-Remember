﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    public GameObject PlayerSelect;
    public GameObject TitleScreen;
    public void startGame()
    {
        PlayerPrefs.SetInt("level1clear", 0);
        PlayerPrefs.SetInt("level2clear", 0);
        PlayerPrefs.SetInt("level3clear", 0);
        SceneManager.LoadScene(3);
    }
    public void playerSelect()
    {
        PlayerSelect.SetActive(true);
        TitleScreen.SetActive(false);
    }
    public void selectMale()
    {
        PlayerPrefs.SetInt("isFemale", 0); // 0 is male
    }
    public void selectFemale()
    {
        PlayerPrefs.SetInt("isFemale", 1); // 1 is female
    }
    void info()
    {

    }
}
