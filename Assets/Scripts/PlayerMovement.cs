using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Vector2 movement = new Vector2(0, -1);

    static float baseSpeed = 4f;
    float runSpeed = baseSpeed;
    float deadZone = .15f;

    public Joystick joystick;

    private Rigidbody2D rb2d;
    private Animator anim;

    bool facingRight = false;
    bool facingLeft = false;

    // Use this for initialization
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (joystick.Horizontal <= deadZone && joystick.Horizontal >= -deadZone && joystick.Vertical <= deadZone && joystick.Vertical >= -deadZone)
        {
            runSpeed = 0f;
        }
        else
        {
            runSpeed = baseSpeed;
        }
    }

    void FixedUpdate()
    {
        // Move our character
        Vector2 movementReal = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (movementReal.x != 0f && movementReal.y != 0f)
        {
           movement = movementReal;
        }

        transform.Translate(movementReal * runSpeed * Time.deltaTime);

        //Debug.Log(movement);

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
            } else
            {
                //Idle Up
                anim.SetInteger("direction", 2);
            }
        } else if (Mathf.Abs(movement.y) > deadZone && Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            //Facing Down
            if (runSpeed != 0f)
            {
                //Walking Down
                anim.SetInteger("direction", -1);
            } else
            {
                //Idle down
                anim.SetInteger("direction", 1);
            }
        } else if (movement.x > deadZone && movement.x > Mathf.Abs(movement.y))
        {
            //Facing Right
            if (runSpeed != 0f)
            {
                //walking right
                anim.SetInteger("direction", -3);
            } else
            {
                //idle right
                anim.SetInteger("direction", 3);
            }

        } else if (Mathf.Abs(movement.x) > deadZone && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            //Facing Left
            if (runSpeed != 0f)
            {
                // walking left
                anim.SetInteger("direction", -4);
            } else
            {
                //walking left
                anim.SetInteger("direction", 4);
            }
        }
    }

}