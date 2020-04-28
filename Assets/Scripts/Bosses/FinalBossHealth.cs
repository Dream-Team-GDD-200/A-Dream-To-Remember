using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBossHealth : MonoBehaviour
{
    public GameObject barUI;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        barUI.SetActive(false);
    }

    public void SetHealth(float health) //takes in a float and sets health equal to that number
    {
        slider.value = health;
    }

    public float GetHealth()
    {
        return slider.value;
    }

    public void DealDamage(float dmg)
    {
        Debug.Log("New Health: " + slider.value);
        slider.value -= dmg;
        Debug.Log("New Health: " + slider.value);
    }

    public void EnableUI()
    {
        barUI.SetActive(true);
    }
}
