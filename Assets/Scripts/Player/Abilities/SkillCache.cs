using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCache : MonoBehaviour
{
  /* Set to true if the doctor has unlocked the corresponding skill. index 0 = white blood cell, 1 = speed boost, 2 = shock, 3 = nurse.*/
  public bool[] hasSkill = { true, false, false, false};
  /* Set to true if the doctor has unlocked the corresponding morph. index 0 = shock duration increase.*/
  public bool[] hasMorph = { false };
  //duration of the stun effect
  private float stunDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
      //DELETE THIS ONCE WE PREVENT PLAYERS FROM STARTING WITH ALL SKILLS
      hasSkill[1] = true;
      hasSkill[2] = true;
      hasSkill[3] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getHasSkill(int index)
    {
      if (index < 0 || index > 4)
      {
        return false;
      }

      else
      {
        return hasSkill[index];
      }
    }
    public void setHasSkill(int index, bool val)
    {
      if (index < 0 || index > 4)
      {
        //do nothing
      }

      else
      {
        hasSkill[index] = val;
      }
    }
    public bool getHasMorph(int index)
    {
      if (index < 0 || index > 0)
      {
        return false;
      }

      else
      {
        return hasMorph[index];
      }
    }
    public void setHasMorph(int index, bool val)
    {
      if (index < 0 || index > 0)
      {
        //do nothing
      }

      else
      {
        hasMorph[index] = val;
      }
    }
    public float getStunDuration()
    {
      return stunDuration;
    }
    public void setStunDuration(float val)
    {
      stunDuration = val;
    }


}
