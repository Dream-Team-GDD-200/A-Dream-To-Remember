using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersCoolDownScript : MonoBehaviour
{
    //this script has nothing to do with the actually running the visual cooldowns, it just shows how much time is left on the cooldown
    float coolDownHolder = 0f; //holds value for currentCoolDownTime and is used to see if the text should be active or not
   
    public void currentNumberTime(float currentCoolDownTime)
    {
           this.gameObject.SetActive(true);
           coolDownHolder = currentCoolDownTime;
           this.gameObject.GetComponent<UnityEngine.UI.Text>().text = "" + currentCoolDownTime;
    }

    void Update()
    {
        if (coolDownHolder <= 0f) //if the respective cooldown is less than or equal to 0, make it not active
        {
            this.gameObject.SetActive(false);
            this.gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        }
    }
  
}
