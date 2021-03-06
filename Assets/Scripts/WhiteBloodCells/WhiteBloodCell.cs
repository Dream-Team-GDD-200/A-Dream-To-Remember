﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
    public Transform fireLocation;
    public GameObject baseProjectile;
    public GameObject projectile;
    public GameObject baseBarrier;
    public GameObject barrier;
    private PlayerMovement playerMovement;
    private Vector2 projectileVelocity;
    private float projectileSpeed = 150f;
    public bool validShot = true;
    private int cellHealth = 0;
    private int cellHealthMax = 3;

  void Start()
    {
        //Creates a projectile and deployable cell off screen. This allows the Shoot and Deploy functions to call parent objects that cannot be destroyed.
        baseProjectile = Instantiate(projectile, new Vector3(1000, 1000, 1000), fireLocation.rotation);
        baseBarrier = Instantiate(barrier, new Vector3(-1000, -1000, -1000), fireLocation.rotation);
        baseBarrier.transform.parent = GameObject.FindGameObjectWithTag("Projectile_Parent").transform;
        baseProjectile.transform.parent = GameObject.FindGameObjectWithTag("Projectile_Parent").transform;
        playerMovement = GetComponent<PlayerMovement>();
    }
  // Update is called once per frame
  public void Shoot(Vector3 WorldPosition, float projectileSpeed)
    {
        //make the projectileForce go in the direction of the click
        projectileVelocity = (WorldPosition - this.gameObject.transform.position).normalized * projectileSpeed;
        projectile = Instantiate(baseProjectile, fireLocation.position, fireLocation.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileVelocity;
        projectile.transform.parent = GameObject.FindGameObjectWithTag("Projectile_Parent").transform;
    }

    public void Deploy()
    {
        /*THIS CAN BE USED TO PLACE THE CELL IN A RANDOM POSITION IF NO OBJECTS ARE IN THE WAY*/

        //if (cellHealth > 0)
        //{
        //  Destroy(barrier.gameObject);
        //}
        //bool clear = true;
        //int dVal = 4;
        //float X = fireLocation.position.x + playerMovement.movement.x;
        //float Y = fireLocation.position.y + playerMovement.movement.y;
        //Vector3 deployLocation = new Vector3(X, Y, fireLocation.position.z);
        //while(dVal > 0)
        //{
        //  Vector2 rayPos = new Vector2(deployLocation.x / dVal, deployLocation.y / dVal);
        //  RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        //  if(hit)
        //  {
        //    clear = false;
        //  }
        //  dVal = dVal - 1;
        //}

        //if(clear == true)
        //{
        //  barrier = Instantiate(baseBarrier, deployLocation, fireLocation.rotation);
        //  Rigidbody2D body = barrier.GetComponent<Rigidbody2D>();
        //}

        //else
        //{
        //  barrier = Instantiate(baseBarrier, fireLocation.position, fireLocation.rotation);
        //  Rigidbody2D body = barrier.GetComponent<Rigidbody2D>();
        //}
        if (barrier)
        {
            Destroy(barrier);
        }
        barrier = Instantiate(baseBarrier, fireLocation.position, fireLocation.rotation);
        barrier.transform.parent = GameObject.FindGameObjectWithTag("Projectile_Parent").transform;
        Rigidbody2D body = barrier.GetComponent<Rigidbody2D>();

        cellHealth = cellHealthMax;
    }

    public int getCellHealth()
    {
      return cellHealth;
    }

    public void reduceCellHealth(int i)
    {
      cellHealth = cellHealth - i;
    }

    public Vector2 getPlayerPosition()
    {
      return new Vector2(fireLocation.position.x, fireLocation.position.y);
    }

    public void alterCellHealthMax(int val)
    {
      cellHealthMax = val;
    }
}
