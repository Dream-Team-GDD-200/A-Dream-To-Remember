using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunField : MonoBehaviour
{
  public Transform fireLocation;
  public GameObject baseShockField;
  public GameObject shockField;
  private PlayerMovement playerMovement;

  void Start()
  {
    //Creates a projectile and deployable cell off screen. This allows the Shoot and Deploy functions to call parent objects that cannot be destroyed.
    baseShockField = Instantiate(baseShockField, new Vector3(2000, 2000, 2000), fireLocation.rotation);

    playerMovement = GetComponent<PlayerMovement>();
  }

  // Start is called before the first frame update
  void Update()
  {
  }

  // Update is called once per frame
  public void Shock()
  {
    shockField = Instantiate(baseShockField, fireLocation.position, fireLocation.rotation);
    Destroy(shockField, 0.2f);
  }
}
