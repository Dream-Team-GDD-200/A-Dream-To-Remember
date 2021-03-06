﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    private float startLerpToBossTime;

    private bool moveToBoss = false;
    private bool moveToPlayer = false;
    private bool moveBarsIn = false;
    private bool moveTextIn = false;
    private bool moveTextOut = false;
    private bool moveBarsOut = false;
    private bool moveToSwitch = false;
    private bool switchToPlayer = false;

    public Camera doctorCamera;
    public GameObject UI;
    public GameObject doctor;
    public Joystick joyStick;

    public GameObject BossIntroUI;
    public GameObject upperBar;
    public GameObject lowerBar;
    public GameObject bossText;

    private Vector3 docCamPos;
    private Vector3 bossPos;

    private Vector3 switchPos;

    private float lerpT = 1f;

    private float camSize = 5f;

    // Start is called before the first frame update
    void Start()
    {
        BossIntroUI.GetComponent<Canvas>().enabled = false;
        bossPos = new Vector3(this.gameObject.transform.position.x + 1.5f, this.gameObject.transform.position.y, -1);
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            switchPos = GameObject.FindGameObjectWithTag("KillSwitch").transform.position;
            switchPos.z = -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToBoss)
        {
            doctorCamera.transform.position = Lerp(docCamPos, bossPos, startLerpToBossTime, lerpT);
        }

        else if (moveToPlayer)
        {
            doctorCamera.transform.position = Lerp(bossPos, docCamPos, startLerpToBossTime, lerpT);
        }

        else if (moveBarsIn)
        {
            upperBar.GetComponent<RectTransform>().localPosition = Lerp(new Vector3(0, 210, 0), new Vector3(0, 0, 0), startLerpToBossTime, lerpT / 2);
            lowerBar.GetComponent<RectTransform>().localPosition = Lerp(new Vector3(0, -210, 0), new Vector3(0, 0, 0), startLerpToBossTime, lerpT / 2);   
        }

        else if (moveTextIn)
        {
            bossText.GetComponent<RectTransform>().localPosition = Lerp(new Vector3(-180, 550, 0), new Vector3(-180, -270, 0), startLerpToBossTime, lerpT);
        }

        else if (moveTextOut)
        {
            bossText.GetComponent<RectTransform>().localPosition = Lerp(new Vector3(-180, -270, 0), new Vector3(1080, -270, 0), startLerpToBossTime, lerpT / 2);
        }

        else if (moveBarsOut)
        {
            upperBar.GetComponent<RectTransform>().localPosition = Lerp(new Vector3(0, 0, 0), new Vector3(0, 210, 0), startLerpToBossTime, lerpT / 2);
            lowerBar.GetComponent<RectTransform>().localPosition = Lerp(new Vector3(0, 0, 0), new Vector3(0, -210, 0), startLerpToBossTime, lerpT / 2);
        }

        else if (moveToSwitch)
        {
            doctorCamera.transform.position = Lerp(bossPos, switchPos, startLerpToBossTime, lerpT);
        }

        else if (switchToPlayer)
        {
            doctorCamera.transform.position = Lerp(switchPos, docCamPos, startLerpToBossTime, lerpT);
        }
    }

    public void beginCutscene()
    {
        startLerpToBossTime = Time.time;
        docCamPos = new Vector3(doctorCamera.transform.position.x, doctorCamera.transform.position.y, -1);

        // DISABLE UI and movement
        doctor.GetComponent<PlayerMovement>().setincutscene(true);
        doctor.GetComponent<PlayerMovement>().enabled = false;
        UI.GetComponent<Canvas>().enabled = false;

        StartCoroutine(cutsceneStuff());
    }

    IEnumerator cutsceneStuff()
    {
        moveToBoss = true;

        yield return new WaitForSeconds(lerpT);

        moveToBoss = false;

        yield return new WaitForSeconds(lerpT);

        BossIntroUI.GetComponent<Canvas>().enabled = true;
        startLerpToBossTime = Time.time;
        moveBarsIn = true;

        yield return new WaitForSeconds(lerpT / 2);

        moveBarsIn = false;

        yield return new WaitForSeconds(lerpT / 2);

        startLerpToBossTime = Time.time;
        moveTextIn = true;

        yield return new WaitForSeconds(lerpT);

        moveTextIn = false;

        yield return new WaitForSeconds(lerpT * 1.5f);

        startLerpToBossTime = Time.time;
        moveTextOut = true;

        yield return new WaitForSeconds(lerpT / 2);

        moveTextOut = false;
        startLerpToBossTime = Time.time;
        moveBarsOut = true;

        yield return new WaitForSeconds(lerpT / 2);

        moveBarsOut = false;

        yield return new WaitForSeconds(lerpT / 2);

        BossIntroUI.SetActive(false);
        startLerpToBossTime = Time.time;

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            moveToSwitch = true;

            yield return new WaitForSeconds(lerpT * 3);

            startLerpToBossTime = Time.time;
            moveToSwitch = false;

            switchToPlayer = true;

            yield return new WaitForSeconds(lerpT);

            switchToPlayer = false;
        }
        else
        {
            moveToPlayer = true;

            yield return new WaitForSeconds(lerpT);

            moveToPlayer = false;
        }
        

        // ENABLE UI
        UI.GetComponent<Canvas>().enabled = true;
        doctor.GetComponent<PlayerMovement>().setincutscene(false);
        doctor.GetComponent<PlayerMovement>().enabled = true;
        
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            FindObjectOfType<FinalBossHandler>().startBossFight();
        }
    }

    private Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        var result = Vector3.Lerp(start, end, percentageComplete);
        return result;
    }
}
