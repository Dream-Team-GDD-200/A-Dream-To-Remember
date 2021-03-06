﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LongClick : MonoBehaviour
{
    [Header("cooldown in seconds")]
    public float DeployCellCooldown;
    public float HealCooldown;
    public float ShockCooldown;
    public float NurseCooldown; // The time for each skill cooldown
    [Header("ticks per second")]
    public float delay; // duration is how long it waits until it fills the next section of the cooldown... Delay is how many times a second the fill is updated
    float duration;
    private float CellDuration = 0f, HealDuration = 0f, ShockDuration = 0f, NurseDuration = 0f; // the current time left of each cooldown
    [Header("Button Images")]
    public Image DeployImage;
    public Image HealImage;
    public Image ShockImage;
    public Image NurseImage; // the image reference for the fill animation
    [Header("Buttons")]
    public Button DeployButton;
    public Button HealButton;
    public Button ShockButton;
    public Button NurseButton;
    private float healVal = 15; //amount of health restored by the heal ability
    private float speed = 5f; //the amount of speed granted by the speed boost ability
    [Header("Speed Sound")]
    public AudioClip speedBoost; // audiio clip for the speed boost
    [Header("Animation Objects")]
    public GameObject ShockAnimation;
    public GameObject HealAnimation;
    [Header("Reference To Text object")]
    //references to the buttons so they can send that button the respective cooldownnumber
    public GameObject buttonDeploy;
    public GameObject buttonHeal;
    public GameObject buttonShock;
    public GameObject buttonNurse;

    void Start()
    {   //disables skills that the player does not have
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(0) == false)
        {
            DeployButton.gameObject.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(1) == false)
        {
            HealButton.gameObject.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(2) == false)
        {
            ShockButton.gameObject.SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(3) == false)
        {
            NurseButton.gameObject.SetActive(false);
        }
    }

    public void onEnable()
    {
        if (CellDuration != 0)
        {
            StartCoroutine(CoolDown(CellDuration, 1));
        }
        if (HealDuration != 0)
        {
            StartCoroutine(CoolDown(HealDuration, 2));
        }
        if (ShockDuration != 0)
        {
            StartCoroutine(CoolDown(ShockDuration, 3));
        }
        if (NurseDuration != 0)
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
        HealAnimation.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().resetSpeed();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("healing", false);
    }
    // delay for the shock animation to stop
    IEnumerator waitForAnimShock()
    {
        yield return new WaitForSeconds(0.833f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("shocking", false);
        ShockAnimation.GetComponent<SpriteRenderer>().enabled = false;
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
            HealAnimation.GetComponent<SpriteRenderer>().enabled = true;
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
            ShockAnimation.GetComponent<SpriteRenderer>().enabled = true;
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
                    buttonDeploy.GetComponent<NumbersCoolDownScript>().currentNumberTime(CellDuration);    //send current cooldown to textbox 
                    DeployImage.fillAmount = (float)1 - (CellDuration / DeployCellCooldown);
                    break;
                case 2:
                    HealDuration -= duration;
                    buttonHeal.GetComponent<NumbersCoolDownScript>().currentNumberTime(HealDuration);
                    HealImage.fillAmount = (float)1 - (HealDuration / HealCooldown);
                    break;
                case 3:
                    ShockDuration -= duration;
                    buttonShock.GetComponent<NumbersCoolDownScript>().currentNumberTime(ShockDuration);
                    ShockImage.fillAmount = (float)1 - (ShockDuration / ShockCooldown);
                    break;
                case 4:
                    NurseDuration -= duration;
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

    //activates a skill
    public void grantSkill(int skill)
    {
        if (skill == 0)
        {
            DeployButton.gameObject.SetActive(true);
        }
        if (skill == 1)
        {
            HealButton.gameObject.SetActive(true);
        }
        if (skill == 2)
        {
            ShockButton.gameObject.SetActive(true);
        }
        if (skill == 3)
        {
            NurseButton.gameObject.SetActive(true);
        }
    }
}
