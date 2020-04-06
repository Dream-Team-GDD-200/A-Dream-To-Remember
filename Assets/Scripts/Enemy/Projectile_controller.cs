using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Projectile_controller : MonoBehaviour
{

    private Vector2 movement = new Vector2(0, -1);

    private Animator anim;
    public Vector2 ProjectileMobMovement;
    public AIPath ProjectileMob;
    void Start()
    {
        anim = GetComponent<Animator>();
        ProjectileMobMovement = ProjectileMob.velocity;
    }



    // Handle animation
    // 1 - idle down | 2 - idle up | 3 - idle right | 4 - idle left
    // -1 - walk down | -2 - walk up | -3 - walk right | -4 - walk left
    void Update()
    {
        
        if (movement.y > Mathf.Abs(movement.x))
        {
                //Walking Up
                anim.SetInteger("direction", -2);
            Debug.Log("here 1");
        }
        else if (Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
                //walking down
                anim.SetInteger("direction", -1);
            Debug.Log("here 2");
        }
        else if (movement.x > Mathf.Abs(movement.y))
        {
                //walking right
                anim.SetInteger("direction", -3);
            Debug.Log("here 3");
        }
        else if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
                //walking left
                anim.SetInteger("direction", -4);
            Debug.Log("here 4");
        }
    }

    void FixedUpdate()
    {
        //TODO: Updated the movement Vector2 when the wolf is moving or stopped
        ProjectileMobMovement = ProjectileMob.velocity;
        movement = ProjectileMobMovement;
    }
}
