using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct upgrade
{
    public upgrade(int cost, bool active)
    {
        Cost = cost;
        Active = active;
    }
    public int Cost;
    public bool Active;
}
[CreateAssetMenu(fileName = "New SkillTreeDataset", menuName = "Skill Tree Data Set")]
public class SkillTreeData : ScriptableObject
{
    public upgrade[,] Upgrades = new upgrade[4, 2];
    public bool[] Skill;
    //2d array of the structure
    /*
            left   |  right
            --------------------
     Skill |S1 lft | S1 rht
           |S2 lft | S2 rht
           |S3 lft | S3 rht
           |S4 lft | S4 rht
     */
     [Header("Data - 4 skills 2 per skill")]
    [SerializeField] public List<int> Costs;
    [SerializeField] public List<bool> Activness;

    public void updateData()
    {
        int CostCounter = 0;
        int ActiveCounter = 0;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; i < 2; i++)
            {
                Upgrades[i, j].Cost = Costs[CostCounter];
                CostCounter++;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; i < 2; i++)
            {
                Upgrades[i, j].Active = Activness[ActiveCounter];
                ActiveCounter++;
            }
        }
    }

    public void updateVisual()
    {
        int CostCounter = 0;
        int ActiveCounter = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; i < 2; i++)
            {
                Costs[CostCounter] = Upgrades[i, j].Cost; 
                CostCounter++;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; i < 2; i++)
            {
                Activness[ActiveCounter] = Upgrades[i, j].Active;
                ActiveCounter++;
            }
        }
    }

    public void resetData() //resets data to default values
    {
        for(int i = 0; i < 4; i++)
        {
            if (i < 2)
            {
                Skill[i] = true;
            }
            else
            {
                Skill[i] = false;
            }
        }
        for(int i = 0; i < 8; i++)
        {
            Activness[i] = false;
        }
    }
}
