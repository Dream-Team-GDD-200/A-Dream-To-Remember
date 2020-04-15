using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrols : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject SkillTreeMenu;
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
                SkillTree.openMenu();
            }
            PauseMenu.openMenu();
            pauseMenu = true;
        }
        else
        {
            PauseMenu.closeMenu();
            if (PauseMenu.isactive)
            {
                PauseMenu.openControls();
            }
            pauseMenu = false;
        }
    }
    public void OpenTree()
    {
        SkillTree.openMenu();
    }
}
