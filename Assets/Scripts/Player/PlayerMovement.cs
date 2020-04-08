using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
public class PlayerMovement : MonoBehaviour
{

    public Vector2 movement = new Vector2(0, -1);

    static float baseSpeed = 2.5f;
    float runSpeed = baseSpeed;
    float deadZone = .15f;

    public Joystick joystick;

    public RuntimeAnimatorController maleAnim;
    public RuntimeAnimatorController femaleAnim;

    private Rigidbody2D rb2d;
    private Animator anim;

    private int isFemale = 1;
    //A* object


    public GameObject aStarPath;
    public GameObject button;
    public GameObject bar;

    private bool inCutScene = false;

    private Vector2 MaleOffset = new Vector2(0.01450627f, -.13f);
    private Vector2 MaleScale = new Vector2(0.1193589f, 0.03369492f);
    private Vector2 MaleOffset_Box = new Vector2(0, .020571f);
    private Vector2 MaleScale_Box = new Vector2(.176781f, .228620f);
    private void Start()
    {
        Scene ActiveScene = SceneManager.GetActiveScene();
       // Debug.Log(isFemale + " gender of doctor");
       if(ActiveScene.name == "Level-1"){
           PlayerPrefs.SetInt("LastLevel", 1);
       }else if(ActiveScene.name == "Level-2"){
           PlayerPrefs.SetInt("LastLevel", 2);
       }else if(ActiveScene.name == "Level-3"){
           PlayerPrefs.SetInt("LastLevel", 3);
       }
    }
    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFemale = PlayerPrefs.GetInt("isFemale"); // sets the int to the PlayerPrefs int of male or female
        if (isFemale == 1f)
        {
            //Debug.Log("set Female anim");
            anim.runtimeAnimatorController = femaleAnim;
        }
        else
        {
            //Debug.Log("set male anim");
            anim.runtimeAnimatorController = maleAnim;
            GetComponent<CapsuleCollider2D>().offset = MaleOffset_Box;
            GetComponent<CapsuleCollider2D>().size = MaleScale_Box;
            GetComponent<BoxCollider2D>().offset = MaleOffset;
            GetComponent<BoxCollider2D>().size = MaleScale;
        }

        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Updates Pathfinding grid
        // aStarPath.gameObject.GetComponent<AstarPath>().Scan();

        //checking for touches
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).position.y > (button.transform.position.y + (button.transform.lossyScale.y / 4)) && Input.GetTouch(i).position.y < (bar.transform.position.y - (bar.transform.lossyScale.y / 4)))
                {
                    GameObject joystick = GameObject.FindGameObjectWithTag("JoyStick");
                    if (!(Input.GetTouch(i).position.x > joystick.transform.position.x - joystick.transform.lossyScale.x && Input.GetTouch(i).position.x < joystick.transform.position.x + joystick.transform.lossyScale.x && Input.GetTouch(i).position.y > joystick.transform.position.y - joystick.transform.lossyScale.y && Input.GetTouch(i).position.y < joystick.transform.position.y + joystick.transform.lossyScale.y))
                    {
                        Vector2 directional = new Vector2(0, 0);
                        if (Input.GetTouch(i).position.x < Screen.width / 2 - 50)
                        {
                            directional.x = -1;
                        }
                        else if (Input.GetTouch(i).position.x > Screen.width / 2 + 50)
                        {
                            directional.x = 1;
                        }
                        if (Input.GetTouch(i).position.y < Screen.height / 2 - 50)
                        {
                            directional.y = -1;
                        }
                        else if (Input.GetTouch(i).position.y > Screen.height / 2 + 50)
                        {
                            directional.y = 1;
                        }
                        GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().Shoot(directional);
                    }
                }
            }
        }
        //Movement
        if (joystick.Horizontal <= deadZone && joystick.Horizontal >= -deadZone && joystick.Vertical <= deadZone && joystick.Vertical >= -deadZone)
        {
            runSpeed = 0f;
        }
        else
        {
            runSpeed = baseSpeed;
        }

        // Handle animation
        // 1 - idle down | 2 - idle up | 3 - idle right | 4 - idle left
        // -1 - walk down | -2 - walk up | -3 - walk right | -4 - walk left
        if (movement.y > deadZone && movement.y > Mathf.Abs(movement.x))
        {
            // Facing Up
            if (runSpeed != 0f)
            {
                //Walking Up
                anim.SetInteger("direction", -2);
            }
            else
            {
                //Idle Up
                anim.SetInteger("direction", 2);
            }
        }
        else if (Mathf.Abs(movement.y) > deadZone && Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            //Facing Down
            if (runSpeed != 0f)
            {
                //Walking Down
                anim.SetInteger("direction", -1);
            }
            else
            {
                //Idle down
                anim.SetInteger("direction", 1);
            }
        }
        else if (movement.x > deadZone && movement.x > Mathf.Abs(movement.y))
        {
            //Facing Right
            if (runSpeed != 0f)
            {
                //walking right
                anim.SetInteger("direction", -3);
            }
            else
            {
                //idle right
                anim.SetInteger("direction", 3);
            }

        }
        else if (Mathf.Abs(movement.x) > deadZone && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            //Facing Left
            if (runSpeed != 0f)
            {
                // walking left
                anim.SetInteger("direction", -4);
            }
            else
            {
                //walking left
                anim.SetInteger("direction", 4);
            }
        }
    }

    void FixedUpdate()
    {
        // Move our character
        Vector2 movementReal = new Vector2(joystick.Horizontal, joystick.Vertical);
        movementReal.Normalize();
        if (movementReal.x != 0f && movementReal.y != 0f && !inCutScene)
        {
            movement = movementReal;
        }

        transform.Translate(movementReal * runSpeed * Time.deltaTime);

        //Debug.Log(movement);
    }

    public void setincutscene(bool val)
    {
        inCutScene = val;
    }

    public void setSpeed(float speed)
    {
        baseSpeed = speed;
    }

    public void resetSpeed()
    {
        baseSpeed = 3f;
    }

    public int getIsFemale()
    {
        return isFemale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            this.gameObject.GetComponent<HealthDoctor>().takeDamage(10);
        }
    }

}