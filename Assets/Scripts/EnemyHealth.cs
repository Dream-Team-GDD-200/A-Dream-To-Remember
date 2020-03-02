using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider slider; //creates a reference to our slider--which is the fill portion of the health bar
    public float Health;

    private void Start()
    {
        SetMaxHealth(Health);
    }

    private void SetMaxHealth(float health) //this may be used later on enemies or something... 
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health) //takes in a float and sets health equal to that number
    {
        slider.value = health;
    }
}
