using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    //the skill tree
    public GameObject skillTree;

    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetActive(false); //set the menu as inactive
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void openMenu()
    {
        if (skillTree.activeSelf == false)
        {
            skillTree.SetActive(true);
        }
        else
        {
            skillTree.SetActive(false);
            skillTree.GetComponent<SkillTreeButtons>().closeAll(0);
        }
    }
}
