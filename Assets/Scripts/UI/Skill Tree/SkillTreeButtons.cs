using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillTreeButtons : MonoBehaviour
{
  //the description window for the first morph
  //morphOne increases the duration of the shock ability by one second
  public GameObject morphOneWindow;
  public Image morphOneButton;
  //morphTwo increases the radius of the shock ability by 50%
  public GameObject morphTwoWindow;
  public Image morphTwoButton;
  //morphThree increases the duration of the nurse abulity by 5 seconds
  public GameObject morphThreeWindow;
  public Image morphThreeButton;
  //morphFour increases the healing potency of the nurse ability by 2
  public GameObject morphFourWindow;
  public Image morphFourButton;
  //morphFive
  public GameObject morphFiveWindow;
  public Image morphFiveButton;
  //morphSix
  public GameObject morphSixWindow;
  public Image morphSixButton;
  //morphSeven
  public GameObject morphSevenWindow;
  public Image morphSevenButton;
  //morphEight
  public GameObject morphEightWindow;
  public Image morphEightButton;
  //images for the skills
  public Image cellSkill;
  public Image healSkill;
  public Image shockSkill;
  public Image nurseSkill;

  // Start is called before the first frame update
  void Start()
    {
      closeAll();
    }

  private void closeAll(int exception = 0)
  {
    switch (exception)
    {
      case 1:
        morphTwoWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
      case 2:
        morphOneWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
      case 3:
        morphOneWindow.SetActive(false);
        morphTwoWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
      case 4:
        morphOneWindow.SetActive(false);
        morphTwoWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
      case 5:
        morphOneWindow.SetActive(false);
        morphTwoWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
      case 6:
        morphOneWindow.SetActive(false);
        morphTwoWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
      case 7:
        morphOneWindow.SetActive(false);
        morphTwoWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
      case 8:
        morphOneWindow.SetActive(false);
        morphTwoWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        break;
      default:
        morphOneWindow.SetActive(false);
        morphTwoWindow.SetActive(false);
        morphThreeWindow.SetActive(false);
        morphFourWindow.SetActive(false);
        morphFiveWindow.SetActive(false);
        morphSixWindow.SetActive(false);
        morphSevenWindow.SetActive(false);
        morphEightWindow.SetActive(false);
        break;
    }
  }

  // Update is called once per frame
  void Update()
  {
    //sets buttons to red if the doctor does not have the related skill and to green if they have the morph
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(0) == true)
    {
      morphOneButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(1) == true)
    {
      morphTwoButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(2) == true)
    {
      morphThreeButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(3) == true)
    {
      morphFourButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(4) == true)
    {
      morphFiveButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(5) == true)
    {
      morphSixButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(6) == true)
    {
      morphSevenButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(7) == true)
    {
      morphEightButton.color = Color.green;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(2) == false)
    {
      morphOneButton.color = Color.red;
      morphTwoButton.color = Color.red;
      shockSkill.color = Color.red;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(3) == false)
    {
      morphThreeButton.color = Color.red;
      morphFourButton.color = Color.red;
      nurseSkill.color = Color.red;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(1) == false)
    {
      morphFiveButton.color = Color.red;
      morphSixButton.color = Color.red;
      healSkill.color = Color.red;
    }
    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(0) == false)
    {
      morphSevenButton.color = Color.red;
      morphEightButton.color = Color.red;
      cellSkill.color = Color.red;
    }
  }

  public void MorphOneOpen()
  {
    closeAll(1);
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

  public void MorphTwoOpen()
  {
    closeAll(2);
    //opens the window if the player has not purchased the morph but has unlocked the shock skill
    if (morphTwoWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(1) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(2) == true)
    {
      morphTwoWindow.SetActive(true);
    }
    else
    {
      morphTwoWindow.SetActive(false);
    }
  }

  public void MorphThreeOpen()
  {
    closeAll(3);
    //opens the window if the player has not purchased the morph but has unlocked the shock skill
    if (morphThreeWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(2) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(3) == true)
    {
      morphThreeWindow.SetActive(true);
    }
    else
    {
      morphThreeWindow.SetActive(false);
    }
  }

  public void MorphFourOpen()
  {
    closeAll(4);
    //opens the window if the player has not purchased the morph but has unlocked the shock skill
    if (morphFourWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(3) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(3) == true)
    {
      morphFourWindow.SetActive(true);
    }
    else
    {
      morphFourWindow.SetActive(false);
    }
  }

  public void MorphFiveOpen()
  {
    closeAll(5);
    //opens the window if the player has not purchased the morph but has unlocked the shock skill
    if (morphFiveWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(4) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(1) == true)
    {
      morphFiveWindow.SetActive(true);
    }
    else
    {
      morphFiveWindow.SetActive(false);
    }
  }

  public void MorphSixOpen()
  {
    closeAll(6);
    //opens the window if the player has not purchased the morph but has unlocked the shock skill
    if (morphSixWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(5) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(1) == true)
    {
      morphSixWindow.SetActive(true);
    }
    else
    {
      morphSixWindow.SetActive(false);
    }
  }

  public void MorphSevenOpen()
  {
    closeAll(7);
    //opens the window if the player has not purchased the morph but has unlocked the shock skill
    if (morphSevenWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(6) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(0) == true)
    {
      morphSevenWindow.SetActive(true);
    }
    else
    {
      morphSevenWindow.SetActive(false);
    }
  }

  public void MorphEightOpen()
  {
    closeAll(8);
    //opens the window if the player has not purchased the morph but has unlocked the shock skill
    if (morphEightWindow.activeSelf == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasMorph(7) == false && GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().getHasSkill(0) == true)
    {
      morphEightWindow.SetActive(true);
    }
    else
    {
      morphEightWindow.SetActive(false);
    }
  }

  public void MorphOneBuy()
  {
    morphOneWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setStunDuration(3f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(0, true);
    Debug.Log("Duration Increased");
  }

  public void MorphTwoBuy()
  {
    morphTwoWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterCooldown("Shock", 2f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(1, true);
    Debug.Log("Radius Increased");
  }

  public void MorphThreeBuy()
  {
    morphThreeWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("Player").GetComponent<NurseSpawn>().alterNurseDurationMax(30f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(2, true);
    Debug.Log("Duration Increased");
  }

  public void MorphFourBuy()
  {
    morphFourWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("Ally").GetComponent<TriageEffect>().alterHealVal(3f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(3, true);
    Debug.Log("Potency Increased");
  }

  public void MorphFiveBuy()
  {
    morphFiveWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterHealVal(20f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(4, true);
    Debug.Log("Heal Increased");
  }

  public void MorphSixBuy()
  {
    morphSixWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterHealVal(10f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(5, true);
    Debug.Log("Potency Increased");
  }

  public void MorphSevenBuy()
  {
    morphSevenWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(6, true);
    GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().alterCellHealthMax(5);
    Debug.Log("Potency Increased");
  }

  public void MorphEightBuy()
  {
    morphEightWindow.SetActive(false);
    GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterCooldown("DeployedCell", 2f);
    GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(7, true);
    Debug.Log("Potency Increased");
  }
}
