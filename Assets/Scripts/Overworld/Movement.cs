using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Vector2 level1 = new Vector2(-3.5f, -0.1f);
    private Vector2 corner1 = new Vector2(6.5f, -0.1f);
    private Vector2 corner2 = new Vector2(6.5f, -7.1f);
    private Vector2 tWall = new Vector2(13.5f, -7.1f);
    private Vector2 level2 = new Vector2(13.5f, -2.1f);
    private Vector2 corner3 = new Vector2(30.5f, -7.1f);
    private Vector2 level3 = new Vector2(30.5f, 5.9f);

    // Used for Level 1 -> TWall (Going Right)
    private bool moving = false;
    private bool move2 = false;
    private bool move3 = false;

    // Used for TWall -> Level 3 (Going Right)
    private bool move4 = false;
    private bool move5 = false;

    //Used for TWall -> Level 1 (Going Left)
    private bool move6 = false;
    private bool move7 = false;
    private bool move8 = false;

    //Used for Level 3 -> TWall (Going Down)
    private bool move9 = false;
    private bool move10 = false;

    //Used for Level 2 -> TWall (Going Down)
    private bool move11 = false;

    //Used for TWall -> Level 2 (Going Up)
    private bool move12 = false;

    private float timeStartedLerping;

    //1 - Level 1
    //4 - TWall
    //2 - Level 2
    //3 - Level 3
    private int playerPosition = 1;

    //TODO: animations
    //todo: fog of war in different rooms (dont show hallway when in patients room)
    //todo: hide buttons while moving
    //todo: red button over incomplete level
    //todo: remove red button when level is completed
    //todo: don't allow player to move to next area without beating level
    //todo: music for the overworld (different areas, different music) change doctor from source to listener

    public RuntimeAnimatorController maleAnim;
    public RuntimeAnimatorController femaleAnim;

    private Animator anim;
    private int isFemale = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        isFemale = PlayerPrefs.GetInt("isFemale");
        if (isFemale == 1f)
        {
            anim.runtimeAnimatorController = femaleAnim;
        }
        else
        {
            anim.runtimeAnimatorController = maleAnim;
        }
    }

    void Update()
    {
        if (moving)
        {
            transform.position = Lerp(level1, corner1, timeStartedLerping, 3f);

            if (transform.position.x == corner1.x && transform.position.y == corner1.y)
            {
                moving = false;
                timeStartedLerping = Time.time;
                move2 = true;

            }
        }
        else if (move2)
        {
            transform.position = Lerp(corner1, corner2, timeStartedLerping, 3f);

            if (transform.position.x == corner2.x && transform.position.y == corner2.y)
            {
                move2 = false;
                timeStartedLerping = Time.time;
                move3 = true;
            }
        }
        else if (move3)
        {
            transform.position = Lerp(corner2, tWall, timeStartedLerping, 3f);

            if (transform.position.x == tWall.x && transform.position.y == tWall.y)
            {
                move3 = false;
                playerPosition = 4;
            }
        }

        else if (move4)
        {
            transform.position = Lerp(tWall, corner3, timeStartedLerping, 5f);

            if (transform.position.x == corner3.x && transform.position.y == corner3.y)
            {
                move4 = false;
                timeStartedLerping = Time.time;
                move5 = true;

            }
        }
        else if (move5)
        {
            transform.position = Lerp(corner3, level3, timeStartedLerping, 5f);

            if (transform.position.x == level3.x && transform.position.y == level3.y)
            {
                move5 = false;
                playerPosition = 3;
            }
        }

        else if (move6)
        {
            transform.position = Lerp(tWall, corner2, timeStartedLerping, 3f);

            if (transform.position.x == corner2.x && transform.position.y == corner2.y)
            {
                move6 = false;
                timeStartedLerping = Time.time;
                move7 = true;

            }
        }
        else if (move7)
        {
            transform.position = Lerp(corner2, corner1, timeStartedLerping, 3f);

            if (transform.position.x == corner1.x && transform.position.y == corner1.y)
            {
                move7 = false;
                timeStartedLerping = Time.time;
                move8 = true;

            }
        }
        else if (move8)
        {
            transform.position = Lerp(corner1, level1, timeStartedLerping, 3f);

            if (transform.position.x == level1.x && transform.position.y == level1.y)
            {
                move8 = false;
                playerPosition = 1;
            }
        }

        else if (move9)
        {
            transform.position = Lerp(level3, corner3, timeStartedLerping, 5f);

            if (transform.position.x == corner3.x && transform.position.y == corner3.y)
            {
                move9 = false;
                timeStartedLerping = Time.time;
                move10 = true;

            }
        }
        else if (move10)
        {
            transform.position = Lerp(corner3, tWall, timeStartedLerping, 5f);

            if (transform.position.x == tWall.x && transform.position.y == tWall.y)
            {
                move10 = false;
                playerPosition = 4;
            }
        }

        else if (move12)
        {
            transform.position = Lerp(tWall, level2, timeStartedLerping, 3f);

            if (transform.position.x == level2.x && transform.position.y == level2.y)
            {
                move12 = false;
                playerPosition = 2;
            }
        }

        else if (move11)
        {
            transform.position = Lerp(level2, tWall, timeStartedLerping, 3f);

            if (transform.position.x == tWall.x && transform.position.y == tWall.y)
            {
                move11 = false;
                playerPosition = 4;
            }
        }
    }

    private Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        var result = Vector3.Lerp(start, end, percentageComplete);
        return result;
    }

    public void clickBtnRight()
    {
        timeStartedLerping = Time.time;

        if (playerPosition == 1)
        {
            level1toTWall();
        }
        else if (playerPosition == 4)
        {
            tWalltoLevel3();
        }
    }

    public void clickBtnLeft()
    {
        timeStartedLerping = Time.time;
        if (playerPosition == 4)
        {
            tWalltoLevel1();
        }
    }

    public void clickBtnDown() 
    {
        timeStartedLerping = Time.time;
        if (playerPosition == 3)
        {
            level3toTWall();
        } 
        else if (playerPosition == 2)
        {
            level2toTWall();
        }
    }

    public void clickBtnUp()
    {
        timeStartedLerping = Time.time;
        if (playerPosition == 4)
        {
            tWallToLevel2();
        }
    }

    private void level1toTWall()
    {
        moving = true;
        // level 1 to corner 1 -> corner 1 to corner 2 -> corner 2 to twall
    }

    private void tWalltoLevel3()
    {
        move4 = true;
    }

    private void tWalltoLevel1()
    {
        move6 = true;
    }

    private void level3toTWall()
    {
        move9 = true;
    }

    private void level2toTWall()
    {
        move11 = true;
    }

    private void tWallToLevel2()
    {
        move12 = true;
    }

    public void BeginLevel()
    {
        if (playerPosition == 1)
        {
            SceneManager.LoadScene(1);
        } 
        else if (playerPosition == 2)
        {
            SceneManager.LoadScene(4);
        }
        else if (playerPosition == 3)
        {
            SceneManager.LoadScene(5);
        }
    }
}
