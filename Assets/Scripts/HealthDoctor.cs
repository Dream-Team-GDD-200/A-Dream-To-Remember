using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDoctor : MonoBehaviour
{

    public float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the doctors health goes below or equal to 0
        if (health <= 0)
        {
            died();
        }
    }

    // Used to have the player take damage.  Pass in the amount of damage to take
    public void takeDamage(float dmg)
    {
        health -= dmg;
    }

    // Used to have the player heal.  Pass in the amount to heal
    public void heal(float healAmt)
    {
        health += healAmt;
    }

    // called when the player died
    private void died()
    {

    }
}
