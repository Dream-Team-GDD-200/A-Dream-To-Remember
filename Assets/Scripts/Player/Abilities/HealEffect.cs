using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
  public Transform fireLocation;
  public GameObject baseEffectSmall;
  public GameObject effectSmall;
  public GameObject baseEffectLarge;
  public GameObject effectLarge;
  private PlayerMovement playerMovement;

  void Start()
  {
    //Creates a projectile and deployable cell off screen. This allows the Shoot and Deploy functions to call parent objects that cannot be destroyed.
    baseEffectSmall = Instantiate(baseEffectSmall, new Vector3(2000, 2000, 2000), fireLocation.rotation);
    baseEffectLarge = Instantiate(baseEffectLarge, new Vector3(2000, 2000, 2000), fireLocation.rotation);

    playerMovement = GetComponent<PlayerMovement>();
  }

  // Start is called before the first frame update
  void Update()
  {
  }

  // Update is called once per frame
  public void Heal()
  {
    effectSmall = Instantiate(baseEffectSmall, fireLocation.position, fireLocation.rotation);
    Destroy(effectSmall, 0.2f);
    effectLarge = Instantiate(baseEffectLarge, fireLocation.position, fireLocation.rotation);
    Destroy(effectLarge, 0.1f);
  }
}
