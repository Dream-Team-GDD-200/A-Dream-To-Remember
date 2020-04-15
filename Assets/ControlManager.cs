using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private Vector2 movement;
    [Header("Joystick")]
    public GameObject Joystick;
    [Header("Scripts")]
    private LongClick Skills;
    
    // Start is called before the first frame update
    void Start()
    {
        Skills = GetComponent<LongClick>();
        if(PlayerPrefs.GetInt("Controls") == 1){
            Joystick.SetActive(false);
        }else if (PlayerPrefs.GetInt("Controls") == 0){
            this.GetComponent<ControlManager>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
        }if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
        }if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1; 
        }if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DeployCell();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Heal();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Shock();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Nurse();
        }
    }

    public Vector2 getMovement()
    {
        return movement;
    }

    public void DeployCell()
    {
        Skills.deployCell();
    }
    public void Heal()
    {
        Skills.healPlayer();
    }
    public void Shock()
    {
        Skills.shockEnemy();
    }

    public void Nurse()
    {
        Skills.spawnNurse();
    }


}
