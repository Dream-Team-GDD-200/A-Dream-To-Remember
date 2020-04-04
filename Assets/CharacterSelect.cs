using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharacterSelect : MonoBehaviour
{
    public GameObject MaleCharacter;
    public GameObject FemaleCharacter;
    public Button StartButton2;
    private void Start()
    {
        PlayerPrefs.SetInt("isFemale", 0);
    }
    public void startGame()
    {
        //set the 3 levels to not clear
        SceneManager.LoadScene(3);
    }
    public void playerSelect()
    {
        MaleCharacter.SetActive(true);
        FemaleCharacter.SetActive(true);
    }
    public void selectMale()
    {
        PlayerPrefs.SetInt("isFemale", 0); // 0 is male
        StartButton2.interactable = true;
    }
    public void selectFemale()
    {
        PlayerPrefs.SetInt("isFemale", 1); // 1 is female
        StartButton2.interactable = true;
    }
    void info()
    {

    }
}
