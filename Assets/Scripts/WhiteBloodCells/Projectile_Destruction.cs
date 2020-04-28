using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Destruction : MonoBehaviour
{

    private AudioSource audioS;
    private SpriteRenderer spr;
    private BoxCollider2D collr;
    void Start()
    {
        audioS = this.gameObject.GetComponent<AudioSource>();
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        collr = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // if colliding with wall, box, deployed cell, or enemy projectile is destroyed
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("DeployedCell") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("UnDmgBoss"))
        {
            audioS.Play();

            spr.enabled = false;
            collr.enabled = false;
            StartCoroutine(waitForSound());
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            audioS.Play();

            spr.enabled = false;
            collr.enabled = false;
            StartCoroutine(waitForSound());

            try
            {
                FindObjectOfType<FinalBossHealth>().DealDamage(2f);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
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
