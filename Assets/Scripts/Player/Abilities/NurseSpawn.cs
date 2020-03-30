using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseSpawn : MonoBehaviour
{
  public Transform fireLocation;
  public GameObject baseNurse;
  public GameObject nurse;
  private PlayerMovement playerMovement;
  private float NurseDuration = 0;

  void Start()
  {
    //Creates a projectile and deployable cell off screen. This allows the Shoot and Deploy functions to call parent objects that cannot be destroyed.
    baseNurse = Instantiate(baseNurse, new Vector3(2000, 2000, 2000), fireLocation.rotation);

    playerMovement = GetComponent<PlayerMovement>();
  }

  // Start is called before the first frame update
  void Update()
  {
    if (NurseDuration > 0)
    {
      NurseDuration = NurseDuration - 1;
    }
  }

  // Update is called once per frame
  public void Spawn()
  {
    bool clear = false;
    int count = 5;
    Vector3 spawnLocation = new Vector3(fireLocation.position.x + Random.Range(-1, 1), fireLocation.position.y + Random.Range(-1, 1), fireLocation.position.z);
    while (clear == false && count > 0)
    {
      Vector2 rayPos = new Vector2(spawnLocation.x , spawnLocation.y );
      RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
      if (hit)
      {
        clear = false;
      }
      else
      {
        clear = true;
      }
      count = count - 1;
      spawnLocation = new Vector3(fireLocation.position.x + Random.Range(-1, 1), fireLocation.position.y + Random.Range(-1, 1), fireLocation.position.z);
    }

    if (clear == true)
    {
      nurse = Instantiate(baseNurse, new Vector3(spawnLocation.x, spawnLocation.y, spawnLocation.z), fireLocation.rotation);
      Destroy(nurse, 25f);
      NurseDuration = 1500;
    }
    else
    {
      spawnLocation = new Vector3(fireLocation.position.x, fireLocation.position.y, fireLocation.position.z);
      nurse = Instantiate(baseNurse, new Vector3(spawnLocation.x, spawnLocation.y, spawnLocation.z), fireLocation.rotation);
      Destroy(nurse, 25f);
      NurseDuration = 1500;
    }
  }

  public bool isNurseAlive()
  {
    if (NurseDuration > 0)
    {
      return true;
    }

    else
    {
      return false;
    }
  }
}
