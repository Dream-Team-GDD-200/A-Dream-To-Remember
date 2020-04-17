using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillCache : MonoBehaviour
{
  /* Set to true if the doctor has unlocked the corresponding skill. 
   * index 0 = white blood cell, 
   * 1 = speed boost, 
   * 2 = shock, 
   * 3 = nurse.*/
  private bool[] hasSkill = { true, true, false, false};

  /* Set to true if the doctor has unlocked the corresponding morph. 
   * index 0 = shock duration increase
   * 1 = shock radius increase
   * 2 = nurse duration increase
   * 3 = nurse heal increase
   * 4 = heal skill heal increase
   * 5 = heal skill speen increase
   * 6 = barrier health increase
   * 7 = barrier cooldown reduction*/
  private bool[] hasMorph = { false, false, false, false, false, false, false, false };

  //duration of the stun effect
  private float stunDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getHasSkill(int index)
    {
      if (index < 0 || index > hasSkill.Length)
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
      if (index < 0 || index > hasSkill.Length)
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
      if (index < 0 || index > hasMorph.Length)
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
      if (index < 0 || index > hasMorph.Length)
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
