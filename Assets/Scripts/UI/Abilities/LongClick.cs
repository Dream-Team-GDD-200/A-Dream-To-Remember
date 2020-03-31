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
    
    public AudioClip speedBoost; // audiio clip for the speed boost

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
            float healVal = 15;
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDoctor>().heal(healVal);
            float speed = 5f;
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
                    DeployImage.fillAmount = (float)1 - (CellDuration / DeployCellCooldown);
                    break;
                case 2:
                    HealDuration-= duration;
                    HealImage.fillAmount = (float)1 - (HealDuration / HealCooldown);
                    break;
                case 3:
                    ShockDuration-= duration;
                    ShockImage.fillAmount = (float)1 - (ShockDuration / ShockCooldown);
                    break;
                case 4:
                    NurseDuration-= duration;
                    NurseImage.fillAmount = (float)1 - (NurseDuration / NurseCooldown);
                    break;
            }
        }
    }
}
