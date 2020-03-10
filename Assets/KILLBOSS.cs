using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLBOSS : MonoBehaviour
{
    public Sprite left;
    bool hasBeenPushed = false;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hasBeenPushed == false && other is BoxCollider2D)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
            hasBeenPushed = true;
            Boss.SetActive(false);
        }
    }
}
