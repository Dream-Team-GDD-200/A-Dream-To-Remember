using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
    public Transform fireLocation;
    public GameObject projectile;
    private GameObject Active_Projectile;
    private PlayerMovement playerMovement;
    private Vector2 projectileForce;
    private float projectileSpeed = 100f;


    void Start()
    {
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
        Active_Projectile = Instantiate(projectile, fireLocation.position, fireLocation.rotation);
        Rigidbody2D body = Active_Projectile.GetComponent<Rigidbody2D>();
        projectileForce.Normalize();
        body.AddForce(projectileForce * projectileSpeed);
        Debug.Log(projectileSpeed);
    }
}
