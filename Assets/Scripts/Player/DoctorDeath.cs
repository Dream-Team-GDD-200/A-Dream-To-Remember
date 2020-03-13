﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
public class DoctorDeath : MonoBehaviour
{

    private bool isFemale = false;

    public Sprite FemaleDeathFrame1;
    public Sprite FemaleDeathFrame2;
    public Sprite FemaleDeathFrame3;
    public Sprite FemaleDeathFrame4;
    public Sprite FemaleDeathFrame5;

    public Camera mainCamera;

    public GameObject aStar;

    private Animator anim;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onDeath()
    {
        // pull in the bool for if the player is male or female
        int isFemale = PlayerPrefs.GetInt("isFemale");

        anim.runtimeAnimatorController = null;
        //Disable AIPath for all enemies

        //aStar.SetActive(false);
        GetComponent<AllThings>().disableAll();
        GameObject.FindGameObjectWithTag("Boss").GetComponent<AIPath>().enabled = false;
        //zoom into player
        mainCamera.orthographicSize = 1.3f;

        if (isFemale == 1)
        {
            StartCoroutine(femaleDeath());
        }
        else
        {

            //TODO MALE DOCTOR DYING

            //Last thing, go to game over
            GetComponent<AllThings>().destroyAll(); // destroys all enemy and box objects that were spawned
            SceneManager.LoadScene(1);
        }
        
    }

    IEnumerator femaleDeath()
    {
        spr.sprite = FemaleDeathFrame1;

        yield return new WaitForSeconds(0.5f);

        spr.sprite = FemaleDeathFrame2;

        yield return new WaitForSeconds(0.6f);

        spr.sprite = FemaleDeathFrame3;

        yield return new WaitForSeconds(0.7f);

        spr.sprite = FemaleDeathFrame4;

        yield return new WaitForSeconds(0.8f);

        spr.sprite = FemaleDeathFrame5;

        yield return new WaitForSeconds(1f);
        GetComponent<AllThings>().destroyAll();// destroys all enemy and box objects that were spawned
        SceneManager.LoadScene(1);
    }
}