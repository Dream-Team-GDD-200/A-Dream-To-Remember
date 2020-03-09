using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Room;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > (Room.transform.position.x - (Room.transform.lossyScale.x / 4)) && Player.transform.position.x < (Room.transform.position.x + (Room.transform.lossyScale.x / 4)) && Player.transform.position.y > (Room.transform.position.y - (Room.transform.lossyScale.y / 4)) && Player.transform.position.y < (Room.transform.position.y + (Room.transform.lossyScale.y / 4)))
        {
            this.gameObject.SetActive(false);
        }
    }
}
