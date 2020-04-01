using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillTreeButtons : MonoBehaviour
{
  //the description window for the first morph
  //morphOne increases the duration of the shock ability by one second
  public GameObject morphOneWindow;
  //the button for the morph that increases the duration of shock
  public Image morphOneButton;

  // Start is called before the first frame update
  void Start()
    {
      morphOneWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      //sets buttons to red if the doctor does not have the related skill and to green if they have the morph
      if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(0) == true)
      {
        morphOneButton.color = Color.green;
      }
      if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(2) == false)
      {
        morphOneButton.color = Color.red;
      }
    }

    public void MorphOneOpen()
    {
      //opens the window if the player has not purchased the morph but has unlocked the shock skill
      if (morphOneWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(0) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(2) == true)
      {
        morphOneWindow.SetActive(true);
      }
      else
      {
        morphOneWindow.SetActive(false);
      }
    }

    public void MorphOneBuy()
    {
      morphOneWindow.SetActive(false);
      GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setStunDuration(3f);
      GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(0, true);
      Debug.Log("Duration Increased");
    }
}
