using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseOverlay;
    public void openMenu()
    {
        pauseOverlay.SetActive(true);
    }
    public void closeMenu()
    {
        pauseOverlay.SetActive(false);
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
