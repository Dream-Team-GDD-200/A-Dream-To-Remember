using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
public class PlayerMovement : MonoBehaviour
{

    public Vector2 movement = new Vector2(0, -1);

    static float baseSpeed = 2.5f;
    [Header("Projectile")]
    public float projectileSpeed;
    public int shootCooldown;

    private int shootDuration;

    float runSpeed = baseSpeed;
    float deadZone = .15f;

    
    [Header("Animators For Player")]
    public RuntimeAnimatorController maleAnim;
    public RuntimeAnimatorController femaleAnim;

    private Rigidbody2D rb2d;
    private Animator anim;

    private int isFemale = 1;
    [Header("UI element for deadzone")]
    public GameObject[] UIElements;
    //A* object
    [Header("Other Links")]
    public Joystick joystick;
    public GameObject aStarPath;
    public GameObject button;
    public GameObject bar;
    private GameObject SkillTreeButton;
    public GameObject PauseMenu;
    public GameObject SkillTreeMenu;
    public GameObject ResetMenu;
    private Scene ActiveScene;
    private bool inCutScene = false;

    private Vector2 MaleOffset = new Vector2(0.01450627f, -.13f);
    private Vector2 MaleScale = new Vector2(0.1193589f, 0.03369492f);
    private Vector2 MaleOffset_Box = new Vector2(0, .020571f);
    private Vector2 MaleScale_Box = new Vector2(.176781f, .228620f);
    private void Start()
    {
        SkillTreeButton = GameObject.Find("SkillTreeButton");
        ActiveScene = SceneManager.GetActiveScene();
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
    //checks to see if the screen touch is within a certain UI element
    public bool CheckWithin(GameObject UI_Element, int index){
        if((Input.GetTouch(index).position.x > UI_Element.transform.position.x - UI_Element.GetComponent<RectTransform>().sizeDelta.x/2 && Input.GetTouch(index).position.x < UI_Element.transform.position.x + UI_Element.GetComponent<RectTransform>().sizeDelta.x/2 && Input.GetTouch(index).position.y > UI_Element.transform.position.y - UI_Element.GetComponent<RectTransform>().sizeDelta.y/2 && Input.GetTouch(index).position.y < UI_Element.transform.position.y + UI_Element.GetComponent<RectTransform>().sizeDelta.y/2)){
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        //Updates Pathfinding grid
        // aStarPath.gameObject.GetComponent<AstarPath>().Scan();

        //checking for touches
        if (Input.touchCount > 0){
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began && !PauseMenu.active && !SkillTreeMenu.active && !ResetMenu.active && shootDuration == 0)
                {
                    bool notUIElement = false;
                    GameObject joystick = GameObject.FindGameObjectWithTag("JoyStick");
                    foreach(GameObject element in UIElements){
                        notUIElement = CheckWithin(element, i);
                        if(notUIElement){
                            break;
                        }
                    }
                    if(!notUIElement){
                        //This line changes the touch position on the screen in pixel location to a relative world position
                        Vector3 WorldPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                        //Pass world position and speed of projectile into the shoot function in white blood cell
                        GetComponent<WhiteBloodCell>().Shoot(WorldPosition, projectileSpeed);
                        shootDuration = shootCooldown;
                        StartCoroutine(ShootCooldown());
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

    IEnumerator ShootCooldown(){
        while(shootDuration > 0){
        yield return new WaitForSeconds(shootCooldown);
        shootDuration--;
        }
    }
}
