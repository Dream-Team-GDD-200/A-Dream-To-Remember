using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LongClick : MonoBehaviour
{
    //public Vector3 buttonPos;
    //public Image skillImage;
    ////used to determine how long the player holds down the mouse button
    //private float startTime, endTime;
    ////current cooldown time
    //private float cooldownTime;
    ////the total cooldown time
    //private float cooldownMaxTime = 125;
    ////the radous of the button
    //private double buttonRad = 60;



    public AudioClip speedBoost;


  //  //Use for initialization
  //  private void Start()
  //  {
  //      startTime = 0f;
  //      endTime = 0f;
  //  }

  ////checks to see if the player's mouse is on top of the button (this likely could be improved)
  //private bool CheckBounds()
  //  {
  //      buttonPos = GameObject.Find("Skill1 BG").transform.position;


  //      if ((Input.mousePosition.x >= (buttonPos.x- buttonRad)) && (Input.mousePosition.x <= (buttonPos.x + buttonRad)) && (Input.mousePosition.y >= (buttonPos.y - buttonRad)) && (Input.mousePosition.y <= (buttonPos.y + buttonRad)) && cooldownTime == 0)
  //      {
  //          return true;
  //      }
  //      else
  //      {
  //          return false;
  //      }

  //      /*
  //      if ((Input.mousePosition.x >= 890) && (Input.mousePosition.x <= 995) && (Input.mousePosition.y >= 20) && (Input.mousePosition.y <= 120))
  //      {
  //          return true;
  //      }
  //      else
  //      {
  //          return false;
  //      }
  //      */
  //  }

  //  void Update()
  //  {
  //      //sets the fill amount for the skill button
  //      skillImage.fillAmount = (float)1 - (cooldownTime / cooldownMaxTime);

  //      //keeps track of how long the mouse is being held down for if the mouse is on the button
  //      if (Input.GetMouseButtonDown(0) && CheckBounds() == true)
  //      {
  //          startTime = Time.time;
  //          GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("attacking", true);
  //      }
  //      if (Input.GetMouseButtonUp(0) && CheckBounds() == true)
  //      {
  //          endTime = Time.time;
  //      }

  //      //fires a cell if the mouse is held down for less that 1/2 of a second
  //      if (endTime - startTime > 0.5f && Input.mousePosition.x >= 786 && CheckBounds() == true && cooldownTime == 0)
  //      {
  //          Debug.Log("Long Click");
  //          startTime = 0f;
  //          endTime = 0f;
  //          GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().Deploy();
  //          cooldownTime = cooldownMaxTime;
  //          StartCoroutine(waitForAnimDeploy());
  //      }
  //      //deploys a cell if the mouse is held down for at least 1/2 of a second
  //      if ((endTime - startTime <= 0.5f) && (endTime - startTime > 0.001) && CheckBounds() == true && cooldownTime == 0)
  //      {
  //          Debug.Log("Short Click");
  //          startTime = 0f;
  //          endTime = 0f;
  //          GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().Shoot(new Vector2(0,0));
  //          cooldownTime = cooldownMaxTime;
  //          StartCoroutine(waitForAnimDeploy());
  //      }
  //      //reduces the cooldown time if it is less than 0 each timestep
  //      if (cooldownTime > 0)
  //      {
  //          cooldownTime -= 1;
  //      }
  //  }

    IEnumerator waitForAnimDeploy()
    {
        yield return new WaitForSeconds(0.417f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("attacking", false);
    }
    IEnumerator waitForAnimHeal()
    {
        yield return new WaitForSeconds(0.75f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().resetSpeed();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("healing", false);
    }
    //this is function is to deploy the cell when the button is clicked
    public void deployCell()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().Deploy();
        StartCoroutine(waitForAnimDeploy());
    }
    public void healPlayer()
    {
        Debug.Log("Small Heal");
       
        float healVal = 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDoctor>().heal(healVal);
        float speed = 5f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setSpeed(speed);
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealEffect>().Heal();
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = speedBoost;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
        StartCoroutine(waitForAnimHeal());
    }
    public void shockEnemy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<StunField>().Shock();
    }
    public void spawnNurse()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<NurseSpawn>().Spawn();
    }
}
