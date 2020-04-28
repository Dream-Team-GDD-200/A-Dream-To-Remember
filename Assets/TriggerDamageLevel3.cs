using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageLevel3 : MonoBehaviour
{
    public FinalBossHandler refToHandler;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        refToHandler.SwitchHit();
    }
}
