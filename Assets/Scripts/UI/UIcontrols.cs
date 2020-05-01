using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrols : MonoBehaviour
{
    [Header("Menu's")]
    public GameObject SkillTreeMenu;
    public GameObject ControlsMenu;
    [Header("Buttons")]
    public GameObject Controls;
    [Header("Scripts")]
    public PauseController PauseMenu;
    public SkillTree SkillTree;

    private bool pauseMenu = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && SkillTree != null)
        {
            OpenTree();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && PauseMenu != null)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!pauseMenu)
        {
            if(SkillTreeMenu != null && SkillTreeMenu.activeSelf)
            {
                OpenTree();
            }
            else
            {
                PauseMenu.openMenu();
                pauseMenu = true;
            }
        }
        else
        {
            if (ControlsMenu.activeSelf)
            {
                PauseMenu.openControls();
            }
            else
            {
                PauseMenu.closeMenu();
                pauseMenu = false;
            }
        }
    }
    public void OpenTree()
    {
        SkillTree.openMenu();
    }
}
