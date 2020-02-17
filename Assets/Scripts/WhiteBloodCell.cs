using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
  public Transform fireLocation;
  public GameObject projectile;
  private PlayerMovement playerMovement;
  private Vector2 projectileForce;
  public float projectileSpeed = 50000f;
    

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
    projectile = Instantiate(projectile, fireLocation.position, fireLocation.rotation);
    Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
    //projectileForce.Normalize();
    body.AddForce(projectileForce * projectileSpeed);
    Debug.Log(projectileSpeed);
  }
}
