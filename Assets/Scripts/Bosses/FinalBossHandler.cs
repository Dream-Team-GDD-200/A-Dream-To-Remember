using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossHandler : MonoBehaviour
{
    public FinalBossHealth bossHealth;

    public GameObject Doctor;

    public GameObject VirusBoss;
    public GameObject WolfBoss;
    public GameObject WardenBoss;

    public GameObject MemFragUI;

    public FadeOut fOut;

    private Vector3 playerWolfSpawn = new Vector3(169.5f, -155.4f, 0f);

    private Vector3 playerVirusSpawn = new Vector3(111.4f, -168.3f, 0f);
    private Vector3 VirusVirusSpawn = new Vector3(96.5f, -167.7946f, 0f);

    private Vector3 playerWardenSpawn = new Vector3(177.8f, -205f, 0f);

    private Vector3 playerIceSpawn = new Vector3(94f, -215f, 0f);
    private Vector3 VirusIceSpawn = new Vector3(105.8f , -225f, 0f);

    private int currentStage = 1;

    private bool triggerOnce = true;

    public void startBossFight()
    {
        bossHealth.EnableUI();
        WolfBoss.SetActive(false);
        WardenBoss.SetActive(false);
    }

    void Update()
    {
        if (currentStage == 1 && bossHealth.GetHealth() <= 80f)
        {
            ChangeStage(2);
        }

        if (currentStage == 2 && bossHealth.GetHealth() <= 60f)
        {
            ChangeStage(3);
        }

        if (currentStage == 3 && bossHealth.GetHealth() <= 40f)
        {
            ChangeStage(4);
        }

        if (currentStage == 4 && bossHealth.GetHealth() <= 20f)
        {
            ChangeStage(5);
        }

        if (currentStage == 5 && bossHealth.GetHealth() <= 0f && triggerOnce) 
        {
            triggerOnce = false;
            StartCoroutine(levelClear());
        }
    }

    public void ChangeStage(int newStage)
    {
        currentStage = newStage;

        switch (newStage)
        {
            case 2:
                VirusBoss.SetActive(false);
                WolfBoss.SetActive(true);
                Doctor.transform.position = playerWolfSpawn;
                break;
            case 3:
                WolfBoss.SetActive(false);
                VirusBoss.SetActive(true);
                VirusBoss.transform.position = VirusVirusSpawn;
                Doctor.transform.position = playerVirusSpawn;
                VirusBoss.GetComponent<BossMechanics>().BossMaxSpeed = 3f;
                break;
            case 4:
                VirusBoss.SetActive(false);
                WardenBoss.SetActive(true);
                Doctor.transform.position = playerWardenSpawn;
                break;
            case 5:
                WardenBoss.SetActive(false);
                VirusBoss.SetActive(true);
                Doctor.transform.position = playerIceSpawn;
                VirusBoss.transform.position = VirusIceSpawn;
                VirusBoss.GetComponent<BossMechanics>().BossMaxSpeed = 4f;
                break;
        }
    }

    IEnumerator levelClear()
    {

        VirusBoss.SetActive(false);

        yield return StartCoroutine(fOut.UndoFade());

        MemFragUI.GetComponent<MemoryFragmentsUI>().saveMemoryFragments();
        PlayerPrefs.SetInt("level3clear", 1); //raises a flag that tells us the level 2 is done
        PlayerPrefs.SetInt("PostStory3Told", 0);

        SceneManager.LoadScene(3);
    }

    public void SwitchHit()
    {
        bossHealth.DealDamage(20f);
    }
}
