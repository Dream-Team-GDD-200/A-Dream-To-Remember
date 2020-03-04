using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Destruction : MonoBehaviour
{

    private AudioSource audioS;
    private SpriteRenderer spr;

    void Start()
    {
        audioS = this.gameObject.GetComponent<AudioSource>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // if colliding with wall, box, deployed cell, or enemy projectile is destroyed
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("DeployedCell") || other.gameObject.CompareTag("Enemy"))
        {
            audioS.Play();

            spr.enabled = false;
            
            StartCoroutine(waitForSound());
        }
    }

    IEnumerator waitForSound()
    {
        //Wait Until Sound has finished playing
        while (audioS.isPlaying)
        {
            yield return null;
        }

        //Auidio has finished playing, destroy GameObject
        Destroy(this.gameObject);
    }
}
