using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryFragmentsUI : MonoBehaviour
{

    private int fragmentCount;

    void Start()
    {
        //TODO: Load in fragment count from other levels

        //Remove later
        fragmentCount = 0;
    }

    public void addMemoryFragment()
    {
        fragmentCount++;
        updateMemoryFragmentUI();
    }

    public void removeMemoryFragment(int num)
    {
        fragmentCount -= num;
        updateMemoryFragmentUI();
    }

    private void updateMemoryFragmentUI()
    {
        this.gameObject.GetComponentInChildren<Text>().text = fragmentCount.ToString();
    }
}
