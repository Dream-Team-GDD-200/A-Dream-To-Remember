using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpriteSwitcher : MonoBehaviour
{
    public Sprite Open;
    public Sprite Close;
    public void open()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Open;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder *= -1;
    }
    public void close()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Close;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder *= -1;
    }
}
