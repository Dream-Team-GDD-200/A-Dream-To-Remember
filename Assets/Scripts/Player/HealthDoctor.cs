using System.Collections;
using System.Collections.Generic;
using UnityEditor; //used to end game if dead
using UnityEngine;


public class HealthDoctor : MonoBehaviour
{

    public AudioClip playerHitSound;

    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public HealthBar healthBar;
    public GameObject joyStick; //reference to joystick to stop movement when dead 
    public GameObject buttons; //reference to buttons to stop being able to press buttons when dead
    public GameObject player; //reference to player to stop
                              // Start is called before the first frame update

    private bool calledDied = false;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // If the doctors health goes below or equal to 0
        if (currentHealth <= 0)
        {
            if (!calledDied)
            {
                died();
                calledDied = true;
            }
            
        }
        /* not needed anymore
        if(Input.GetKeyDown(KeyCode.F))
        {
            takeDamage(10f);
        }
        */
    }

    // Used to have the player take damage.  Pass in the amount of damage to take
    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
        if (!calledDied)
        {
            this.gameObject.GetComponent<AudioSource>().clip = playerHitSound;
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Used to have the player heal.  Pass in the amount to heal
    public void heal(float healAmt)
    {
        currentHealth += healAmt;
        healthBar.SetHealth(currentHealth);
    }

    // called when the player died
    private void died() //might be better to switch over to a completly different scene if this function causes problems later down the line
    {
        //make joystick disappear
        joyStick.SetActive(false); ;
        //make buttons disappear ***white blood cells will still keep moving--collision boxes might need to be turned off
        buttons.SetActive(false); //wasn't working 
        //stops movement of doctor and possibly other things
        player.GetComponent<PlayerMovement>().enabled = false; //*** might not be the greatest way to stop him, replace later if better method is found

        this.gameObject.GetComponent<DoctorDeath>().onDeath();

    }
    private void endGame()
    {
        //if (EditorApplication.isPlaying)
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
    }
}
