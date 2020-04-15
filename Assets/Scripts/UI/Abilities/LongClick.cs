using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LongClick : MonoBehaviour
{
    public float DeployCellCooldown, HealCooldown, ShockCooldown, NurseCooldown; // The time for each skill cooldown
    public float delay; // duration is how long it waits until it fills the next section of the cooldown... Delay is how many times a second the fill is updated
    float duration;
    private float CellDuration = 0f, HealDuration = 0f, ShockDuration = 0f, NurseDuration = 0f; // the current time left of each cooldown
    public Image DeployImage, HealImage, ShockImage, NurseImage; // the image reference for the fill animation
    private float healVal = 15; //amount of health restored by the heal ability
    private float speed = 5f; //the amount of speed granted by the speed boost ability

    public AudioClip speedBoost; // audiio clip for the speed boost


    //references to the buttons so they can send that button the respective cooldownnumber
    public GameObject buttonDeploy;
    public GameObject buttonHeal;
    public GameObject buttonShock;
    public GameObject buttonNurse;

    public void onEnable()
    {
        if(CellDuration != 0)
        {
            StartCoroutine(CoolDown(CellDuration, 1));
        }
        if(HealDuration != 0)
        {
            StartCoroutine(CoolDown(HealDuration, 2));
        }
        if(ShockDuration != 0)
        {
            StartCoroutine(CoolDown(ShockDuration, 3));
        }
        if(NurseDuration != 0)
        {
            StartCoroutine(CoolDown(NurseDuration, 4));
        }
    }

    //delay for the attacking animation
    IEnumerator waitForAnimDeploy()
    {
        yield return new WaitForSeconds(0.417f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("attacking", false);
    }
    //delay for the healing animation until it stops
    IEnumerator waitForAnimHeal()
    {
        yield return new WaitForSeconds(0.75f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().resetSpeed();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("healing", false);
    }
    // delay for the shock animation to stop
    IEnumerator waitForAnimShock()
    {
        yield return new WaitForSeconds(0.833f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("shocking", false);
    }
    //this is function is to deploy the cell when the button is clicked
    public void deployCell()
    {
        if (CellDuration == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("attacking", true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().Deploy();
            StartCoroutine(waitForAnimDeploy());
            cooldown(1);
        }
    }
    // does the heal player animation, sounds, and logic
    public void healPlayer()
    {
        Debug.Log("Small Heal");
        if (HealDuration == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("healing", true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDoctor>().heal(healVal);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setSpeed(speed);
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealEffect>().Heal();
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = speedBoost;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
            StartCoroutine(waitForAnimHeal());
            cooldown(2);
        }
    }
    // does the shock enemy logic
    public void shockEnemy()
    {
        if (ShockDuration == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("shocking", true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<StunField>().Shock();
            StartCoroutine(waitForAnimShock());
            cooldown(3);
        }
    }
    // does the nurse logic
    public void spawnNurse()
    {
        if (NurseDuration == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<NurseSpawn>().Spawn();
            cooldown(4);
        }
    }
    //starts the cooldown for a specific ability
    void cooldown(int skill)
    {
        duration = 1 / delay;
        switch (skill)
        {
            case 1:
                CellDuration = DeployCellCooldown;
                DeployImage.fillAmount = 0;
                StartCoroutine(CoolDown(CellDuration, 1));
                break;
            case 2:
                HealDuration = HealCooldown;
                HealImage.fillAmount = 0;
                StartCoroutine(CoolDown(HealDuration, 2));
                break;
            case 3:
                ShockDuration = ShockCooldown;
                StartCoroutine(CoolDown(ShockDuration, 3));
                break;
            case 4:
                NurseDuration = NurseCooldown;
                StartCoroutine(CoolDown(NurseDuration, 4));
                break;
        }
    }
    //Cooldown for a given ability
    IEnumerator CoolDown(float time, int type)
    {
        time *= delay;
        while (time > 0)
        {
            yield return new WaitForSeconds(duration);

            time--;
            switch (type)
            {
                case 1:
                    CellDuration -= duration;
                    buttonDeploy.GetComponent<NumbersCoolDownScript>().currentNumberTime( CellDuration);    //send current cooldown to textbox 
                    DeployImage.fillAmount = (float)1 - (CellDuration / DeployCellCooldown);
                    break;
                case 2:
                    HealDuration-= duration;
                    buttonHeal.GetComponent<NumbersCoolDownScript>().currentNumberTime(HealDuration);
                    HealImage.fillAmount = (float)1 - (HealDuration / HealCooldown);
                    break;
                case 3:
                    ShockDuration-= duration;
                    buttonShock.GetComponent<NumbersCoolDownScript>().currentNumberTime(ShockDuration);
                    ShockImage.fillAmount = (float)1 - (ShockDuration / ShockCooldown);
                    break;
                case 4:
                    NurseDuration-= duration;
                    buttonNurse.GetComponent<NumbersCoolDownScript>().currentNumberTime(NurseDuration);
                    NurseImage.fillAmount = (float)1 - (NurseDuration / NurseCooldown);
                    break;
            }
        }
    }

  //manually changes the total duration of a skill's cooldown
  public void alterCooldown(string skill, float val)
    {
        if (skill == "DeployedCell")
        {
            DeployCellCooldown = val;
        }
        if (skill == "Heal")
        {
            HealCooldown = val;
        }
        if (skill == "Shock")
        {
            ShockCooldown = val;
        }
        if (skill == "Nurse")
        {
            NurseCooldown = val;
        }
    }

  //changes the potency of the heal ability
  public void alterHealVal(float val)
  {
    healVal = val;
  }

  //changes the potency of the heal ability
  public void alterSpeed(float val)
  {
    speed = val;
  }
}
