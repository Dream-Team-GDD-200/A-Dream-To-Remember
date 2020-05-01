using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriageProjectileDestruction : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthDoctor>().heal(6);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
