using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCleanTiles : MonoBehaviour
{
    public GameObject Room1;
    public GameObject TWallHallway;
    public GameObject Room2;
    public GameObject Room3;
    public GameObject LastHallway;

    public Sprite cleanRoom1;
    public Sprite cleanTWallHallway;
    public Sprite cleanRoom2;
    public Sprite cleanRoom3;
    public Sprite cleanLastHallway;

    public Sprite corruptRoom1;
    public Sprite corruptTWallHallway;
    public Sprite corruptRoom2;
    public Sprite corruptRoom3;
    public Sprite corruptLastHallway;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("level1clear") == 1)
        {
            Room1.GetComponent<SpriteRenderer>().sprite = cleanRoom1;
        } else
        {
            Room1.GetComponent<SpriteRenderer>().sprite = corruptRoom1;
        }

        if (PlayerPrefs.GetInt("level2clear") == 1)
        {
            Room2.GetComponent<SpriteRenderer>().sprite = cleanRoom2;
            TWallHallway.GetComponent<SpriteRenderer>().sprite = cleanTWallHallway;
        } else
        {
            Room2.GetComponent<SpriteRenderer>().sprite = corruptRoom2;
            TWallHallway.GetComponent<SpriteRenderer>().sprite = corruptTWallHallway;
        }

        if (PlayerPrefs.GetInt("level3clear") == 1)
        {
            Room3.GetComponent<SpriteRenderer>().sprite = cleanRoom3;
            LastHallway.GetComponent<SpriteRenderer>().sprite = cleanLastHallway;
        } else
        {
            Room3.GetComponent<SpriteRenderer>().sprite = corruptRoom3;
            LastHallway.GetComponent<SpriteRenderer>().sprite = corruptLastHallway;
        }
    }
}
