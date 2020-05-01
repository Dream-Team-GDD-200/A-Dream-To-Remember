using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ContinueFromDeath : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("Overworld");
        }
    }
}
