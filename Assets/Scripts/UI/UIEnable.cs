using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnable : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnEnable()
    {
        GetComponentInChildren<LongClick>().onEnable();
    }
}
