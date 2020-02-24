using System.Collections;
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
    private Vector2 projectileForce;
    private float projectileSpeed = 100f;
    public bool validShot = true;


    void Start()
    {
        //Creates a projectile and deployable cell off screen. This allows the Shoot and Deploy functions to call parent objects that cannot be destroyed.
        baseProjectile = Instantiate(projectile, new Vector3(1000, 1000, 1000), fireLocation.rotation);
        baseBarrier = Instantiate(barrier, new Vector3(-1000, -1000, -1000), fireLocation.rotation);

        playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Update()
    {
        projectileForce = playerMovement.movement;
    }

    // Update is called once per frame
    public void Shoot()
    {
        projectile = Instantiate(baseProjectile, fireLocation.position, fireLocation.rotation);
        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
        projectileForce.Normalize();
        body.AddForce(projectileForce * projectileSpeed);
        //Debug.Log(projectileSpeed);
    }

    public void Deploy()
    {
        Vector3 deployLocation = new Vector3(fireLocation.position.x + playerMovement.movement.x, fireLocation.position.y + playerMovement.movement.y, fireLocation.position.z);
        barrier = Instantiate(baseBarrier, deployLocation, fireLocation.rotation);
        Rigidbody2D body = barrier.GetComponent<Rigidbody2D>();
    }
}
