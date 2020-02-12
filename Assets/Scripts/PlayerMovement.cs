using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    static float baseSpeed = 10f;
    float runSpeed = baseSpeed;

    public Joystick joystick;

    private Rigidbody2D rb2d;

    // Use this for initialization
    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (joystick.Horizontal <= .1f && joystick.Horizontal >= -.1f && joystick.Vertical <= .1f && joystick.Vertical >= -.1f) {
            runSpeed = 0f;
        } else {
            runSpeed = baseSpeed;
        }
    }

    void FixedUpdate()
    {
        // Move our character
        Vector2 movement = new Vector2(joystick.Horizontal, joystick.Vertical);
        Debug.Log("movement:" + movement + " ruNSpeed: " + runSpeed + " Time: " + Time.deltaTime);
        transform.Translate(movement * runSpeed * Time.deltaTime); 
    }
}