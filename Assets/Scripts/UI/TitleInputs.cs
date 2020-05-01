using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInputs : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GetComponent<Controller>().Controls.activeSelf)
        {
            GetComponent<Controller>().openControls();
        }
    }
}
