using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Vector2 movement = new Vector2(1, 0);

    static float baseSpeed = 4f;
    float runSpeed = baseSpeed;
    float deadZone = .15f;

    public Joystick joystick;

    private Rigidbody2D rb2d;

    // Use this for initialization
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
    }

}