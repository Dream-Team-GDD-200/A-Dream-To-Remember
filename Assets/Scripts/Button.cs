/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this gives me the prebuilt image class as apparently it is not in on default... it also does other things but idk  ¯\_(ツ)_/¯  
//** stars mean potential change needed in the future
//** i couldn't figure out how to fix the images to be circular buttons within a grid-- to be done later
//video that helped me make this-https://www.youtube.com/watch?v=6dQjLoupAw0

public class Button : MonoBehaviour
{
    public List<Skill> skills; //creates a list of skill (the buttons) and calls it skill

    void Update()
    {

       //potentially inefficient if we want more than four buttons-- this may need to be changed in the future**
       
            
            //continue this chain by adding an else if (button you want pressed) if you want more buttons 

        foreach (Skill s in skills)
        {
            if (s.currentCoolDown < s.cooldown) //basically, if the the current cooldown is not yet finished -- keep updating it 
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown; //gives a number between 0 and 1 and will fill that percent of the button accordingly
            }
        }
    }
    public void Click()
    {
        
        if (skills[0].currentCoolDown >= skills[0].cooldown) //if currentCoolDown is greater than or equal to cooldown you can use the skill again (we are counting up here)
        {
            //do something on press -- like the actual skill XD
            skills[0].currentCoolDown = 0; //resets currentCoolDown timer
            GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().Shoot();  
        }
    }
}
    [System.Serializable] //idk what this really does to be honest, but it allowed me to write this class below
    public class Skill //this is our button class for our button layout (may be changed in future but this works for now
    {
        public float cooldown;
        public Image skillIcon;
        //[HideInInspector]
        public float currentCoolDown; //although important to access we don't need to edit this within unity... so i hid it within the editor
    }*/
