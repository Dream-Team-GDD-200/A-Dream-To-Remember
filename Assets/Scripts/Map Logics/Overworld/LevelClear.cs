using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour
{
    public GameObject incLvl1;
    public GameObject incLvl2;
    public GameObject incLvl3;

    void Update()
    {

        if (PlayerPrefs.GetInt("level1clear") == 1)
        {
            incLvl1.SetActive(false);
        }

        if (PlayerPrefs.GetInt("level2clear") == 1)
        {
            incLvl2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("level3clear") == 1)
        {
            incLvl3.SetActive(false);
        }
    }
}
