using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Room"))
        {
            collision.gameObject.GetComponent<DetectInRoom>().activate();
        }
    }
}
