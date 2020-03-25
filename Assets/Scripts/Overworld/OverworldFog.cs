using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldFog : MonoBehaviour
{
    private SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spr.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spr.enabled = true;
        }
    }
}
