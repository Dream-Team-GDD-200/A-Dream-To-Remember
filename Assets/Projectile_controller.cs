using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Projectile_controller : MonoBehaviour
{

    private Vector2 movement = new Vector2(0, -1);

    private bool isMoving = false;

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
            //Facing Up
            if (isMoving)
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
        else if (Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            //Facing Down
            if (isMoving)
            {
                //walking down
                anim.SetInteger("direction", -1);
            }
            else
            {
                //idle down
                anim.SetInteger("direction", 1);
            }
        }
        else if (movement.x > Mathf.Abs(movement.y))
        {
            //Facing right
            if (isMoving)
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
        else if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            //Facing left
            if (isMoving)
            {
                //walking left
                anim.SetInteger("direction", -4);
            }
            else
            {
                //idle left
                anim.SetInteger("direction", 4);
            }
        }
    }

    void FixedUpdate()
    {
        //TODO: Set isMoving to true when moving and false when stopped
        if (ProjectileMobMovement == new Vector2(0, 0))
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        //TODO: Updated the movement Vector2 when the wolf is moving or stopped
        ProjectileMobMovement = ProjectileMob.velocity;
        movement = ProjectileMobMovement;
    }
}
