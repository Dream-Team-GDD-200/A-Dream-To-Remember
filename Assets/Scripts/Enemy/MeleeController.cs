using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MeleeController : MonoBehaviour
{
    public Animator MeleeMob;
    public AIPath MobPathing;
    private Vector2 movement;
    private bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {
        movement = MobPathing.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.y > Mathf.Abs(movement.x))
        {
            //Walking Up
            MeleeMob.SetInteger("direction", -2);
        }
        else if (Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            //walking down
            MeleeMob.SetInteger("direction", -1);
        }
        else if (movement.x > Mathf.Abs(movement.y))
        {
            //walking right
            if (!flipped)
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                this.gameObject.transform.position += new Vector3(1, 0, 0);
                flipped = true;
            }
            MeleeMob.SetInteger("direction", -3);
        }
        else if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            //walking left
            if (flipped)
            {
               this.gameObject.transform.localScale = new Vector3(1, 1, 1);
               this.gameObject.transform.position += new Vector3(-1, 0, 0);
               flipped = false;
            }
            MeleeMob.SetInteger("direction", -4);
        }
    }

    private void FixedUpdate()
    {
        movement = MobPathing.velocity;
    }
}
