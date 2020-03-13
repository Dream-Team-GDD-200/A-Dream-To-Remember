using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GoInRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            try
            {
                collision.gameObject.GetComponent<DetectInRoom>().activate();
            } catch (Exception e) { print(e.Message); }
            
        }
    }
}
