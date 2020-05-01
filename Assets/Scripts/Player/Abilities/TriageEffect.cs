using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriageEffect : MonoBehaviour
{
    public Transform fireLocation;
    public Transform player;
    public GameObject projectile;
    public float projectileSpeed;
    private float shotTimeMax = 100;
    private float shotTime = 100;
    private Vector2 playerLocation = new Vector2(0, 0);
    private Vector2 NurseLocation = Vector2.zero;
    private float healVal = 2;
    private Vector2 projectileVelocity;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        playerLocation = player.position;
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<NurseSpawn>().isNurseAlive() == true)
        {
            shotTime = shotTime - 1;
            if (shotTime <= 0)
            {
                Shoot();
                shotTime = shotTimeMax;
            }
        }
    }

    // Update is called once per frame
    public void Shoot()
    {
        //create projectile
        GameObject projectile1 = Instantiate(projectile, NurseLocation, Quaternion.identity);
        
        //find what velocity it should have
        projectileVelocity = (playerLocation - NurseLocation).normalized * projectileSpeed;
        Debug.Log(projectileVelocity);
        //apply velocity
        projectile1.GetComponent<Rigidbody2D>().velocity = projectileVelocity;
        projectile1.transform.parent = this.gameObject.transform;
        Debug.Log(projectile1.GetComponent<Rigidbody2D>().velocity);
    }

    public void alterHealVal(float val)
    {
        healVal = val;
    }

    public void setNurseLocation(Vector3 location)
    {
        NurseLocation = new Vector2(location.x, location.y);
    }
}
