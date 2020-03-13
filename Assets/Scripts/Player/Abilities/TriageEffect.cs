using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriageEffect : MonoBehaviour
{
  public Transform fireLocation;
  public GameObject baseProjectile;
  public GameObject projectile;
  private Vector2 projectileForce;
  private float projectileSpeed = 150f;
  public bool validShot = true;
  private int cellHealth = 0;
  private float shotTimeMax = 100;
  private float shotTime = 100;
  private Vector2 playerLocation = new Vector2(0, 0);

  void Start()
  {
    //Creates a projectile and deployable cell off screen. This allows the Shoot and Deploy functions to call parent objects that cannot be destroyed.
    baseProjectile = Instantiate(projectile, new Vector3(1000, 1000, 1000), fireLocation.rotation);
  }

  // Start is called before the first frame update
  void Update()
  {
    playerLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<WhiteBloodCell>().getPlayerPosition();
    float totalForce = 5;
    float xDistance = playerLocation.x - fireLocation.position.x;
    float yDistance = playerLocation.y - fireLocation.position.y;
    float angle = Mathf.Atan(yDistance / xDistance);
    if(xDistance < 0)
    {
      projectileForce = (new Vector2(Mathf.Cos(angle) * totalForce, Mathf.Sin(angle) * totalForce)) * -1;
    }
    else
    {
      projectileForce = new Vector2(Mathf.Cos(angle) * totalForce, Mathf.Sin(angle) * totalForce);
    }
    shotTime = shotTime - 1;
    if(shotTime <= 0)
    {
      Shoot();
      shotTime = shotTimeMax;
    }

  }

  // Update is called once per frame
  public void Shoot()
  {
    projectile = Instantiate(baseProjectile, fireLocation.position, fireLocation.rotation);
    Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();
    projectileForce.Normalize();
    body.AddForce(projectileForce * projectileSpeed);
    Destroy(projectile, 5f);
    //Debug.Log(projectileSpeed);
  }
}
