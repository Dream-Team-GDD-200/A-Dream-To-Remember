using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMob_shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    private GameObject Player;
    private Vector2 PlayerPosition;
    private Vector2 Force;
    public float projectileSpeed;
    public int timeBetweenShot;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPosition = Player.transform.position;
        StartCoroutine(shoot());
    }

    private void Update()
    {
        PlayerPosition = Player.transform.position;

    }
    private void FixedUpdate()
    {
        
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(timeBetweenShot);

        GameObject projectileTemp;
        projectileTemp = Instantiate(projectile, this.transform.position, Quaternion.identity);
        projectileTemp.GetComponent<Rigidbody2D>().velocity = (Player.transform.position - projectileTemp.transform.position).normalized * projectileSpeed;
        projectileTemp.transform.parent = GameObject.FindGameObjectWithTag("Projectile_Parent").transform;

        StartCoroutine(shoot());
    }
}
