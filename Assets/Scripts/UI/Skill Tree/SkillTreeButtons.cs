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
    public Text morphOneCostText;
    //morphTwo increases the radius of the shock ability by 50%
    public GameObject morphTwoWindow;
    public Image morphTwoButton;
    public Text morphTwoCostText;
    //morphThree increases the duration of the nurse abulity by 5 seconds
    public GameObject morphThreeWindow;
    public Image morphThreeButton;
    public Text morphThreeCostText;
    //morphFour increases the healing potency of the nurse ability by 2
    public GameObject morphFourWindow;
    public Image morphFourButton;
    public Text morphFourCostText;
    //morphFive
    public GameObject morphFiveWindow;
    public Image morphFiveButton;
    public Text morphFiveCostText;
    //morphSix
    public GameObject morphSixWindow;
    public Image morphSixButton;
    public Text morphSixCostText;
    //morphSeven
    public GameObject morphSevenWindow;
    public Image morphSevenButton;
    public Text morphSevenCostText;
    //morphEight
    public GameObject morphEightWindow;
    public Image morphEightButton;
    public Text morphEightCostText;
    //images for the skills
    public Image cellSkill;
    public Image healSkill;
    public Image shockSkill;
    public Image nurseSkill;
    [Header("Data")]
    public SkillTreeData Data;
    //cost to purchase a skill upgrade
    private int upgradeCost = 1;

    // Start is called before the first frame update
    void Start()
    {
        closeAll();
        UpdateCosts();
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
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphOneWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setStunDuration(3f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(0, true);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Duration Increased");
        }
    }

    public void MorphTwoBuy()
    {
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphTwoWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterCooldown("Shock", 2f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(1, true);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Radius Increased");
        }
    }

    public void MorphThreeBuy()
    {
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphThreeWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<NurseSpawn>().alterNurseDurationMax(30f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(2, true);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Duration Increased");
        }
    }

    public void MorphFourBuy()
    {
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphFourWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("Ally").GetComponent<TriageEffect>().alterHealVal(3f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(3, true);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Potency Increased");
        }
    }

    public void MorphFiveBuy()
    {
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphFiveWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterHealVal(20f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(4, true);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Heal Increased");
        }
    }

    public void MorphSixBuy()
    {
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphSixWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterHealVal(10f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(5, true);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Potency Increased");
        }
    }

    public void MorphSevenBuy()
    {
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphSevenWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(6, true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().alterCellHealthMax(5);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Potency Increased");
        }
    }

    public void MorphEightBuy()
    {
        if (GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().getCount() >= upgradeCost)
        {
            morphEightWindow.SetActive(false);
            GameObject.FindGameObjectWithTag("DeploySkill").GetComponent<LongClick>().alterCooldown("DeployedCell", 2f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SkillCache>().setHasMorph(7, true);
            GameObject.FindGameObjectWithTag("MemFrag").GetComponent<MemoryFragmentsUI>().removeMemoryFragment(upgradeCost);
            Debug.Log("Potency Increased");
        }
    }
    private void UpdateCosts()
    {
        morphOneCostText.text = Data.Costs[0].ToString();
        morphTwoCostText.text = Data.Costs[1].ToString();
        morphThreeCostText.text = Data.Costs[2].ToString();
        morphFourCostText.text = Data.Costs[3].ToString();
        morphFiveCostText.text = Data.Costs[4].ToString();
        morphSixCostText.text = Data.Costs[5].ToString();
        morphSevenCostText.text = Data.Costs[6].ToString();
        morphEightCostText.text = Data.Costs[7].ToString();
    }
}
