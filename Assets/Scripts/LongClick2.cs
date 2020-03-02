using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LongClick2 : MonoBehaviour
{
  public Vector3 buttonPos;
  public Image skillImage;
  //used to determine how long the player holds down the mouse button
  private float startTime, endTime;
  //current cooldown time
  private float cooldownTime;
  //the total cooldown time
  private float cooldownMaxTime = 180;
  //the radius of the button
  private double buttonRad = 60;
  //total duration of the speed boost
  private double maxSpeedDuration = 80;
  //current duration of the speed boost
  private double speedDuration = 0;

  //Use for initialization
  private void Start()
  {
    startTime = 0f;
    endTime = 0f;
  }

  //checks to see if the player's mouse is on top of the button (this likely could be improved)
  private bool CheckBounds()
  {
    buttonPos = GameObject.Find("Skill2 BG").transform.position;


    if ((Input.mousePosition.x >= (buttonPos.x - buttonRad)) && (Input.mousePosition.x <= (buttonPos.x + buttonRad)) && (Input.mousePosition.y >= (buttonPos.y - buttonRad)) && (Input.mousePosition.y <= (buttonPos.y + buttonRad)) && cooldownTime == 0)
    {
      return true;
    }
    else
    {
      return false;
    }

    /*
    if ((Input.mousePosition.x >= 890) && (Input.mousePosition.x <= 995) && (Input.mousePosition.y >= 20) && (Input.mousePosition.y <= 120))
    {
        return true;
    }
    else
    {
        return false;
    }
    */
  }

  void Update()
  {
    //sets the fill amount for the skill button
    skillImage.fillAmount = (float)1 - (cooldownTime / cooldownMaxTime);

    if(speedDuration > 0)
    {
      speedDuration = speedDuration - 1;
    }

    if(speedDuration == 0)
    {
      GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().resetSpeed();
    }

    //keeps track of how long the mouse is being held down for if the mouse is on the button
    if (Input.GetMouseButtonDown(0) && CheckBounds() == true)
      startTime = Time.time;
    if (Input.GetMouseButtonUp(0) && CheckBounds() == true)
      endTime = Time.time;

    //fires a cell if the mouse is held down for less that 1/2 of a second
    if (endTime - startTime > 0.5f && Input.mousePosition.x >= 786 && CheckBounds() == true && cooldownTime == 0)
    {
      Debug.Log("Big Heal");
      startTime = 0f;
      endTime = 0f;
      float healVal = 15;
      GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDoctor>().heal(healVal);
      cooldownTime = cooldownMaxTime;
      speedDuration = maxSpeedDuration;
      float speed = 5f;
      GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setSpeed(speed);
      GameObject.FindGameObjectWithTag("Player").GetComponent<HealEffect>().Heal();
    }
    //deploys a cell if the mouse is held down for at least 1/2 of a second
    if ((endTime - startTime <= 0.5f) && (endTime - startTime > 0.001) && CheckBounds() == true && cooldownTime == 0)
    {
      Debug.Log("Small Heal");
      startTime = 0f;
      endTime = 0f;
      float healVal = 15;
      GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDoctor>().heal(healVal);
      cooldownTime = cooldownMaxTime;
      speedDuration = maxSpeedDuration;
      float speed = 5f;
      GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setSpeed(speed);
      GameObject.FindGameObjectWithTag("Player").GetComponent<HealEffect>().Heal();
    }
    //reduces the cooldown time if it is less than 0 each timestep
    if (cooldownTime > 0)
    {
      cooldownTime -= 1;
    }
  }
}
