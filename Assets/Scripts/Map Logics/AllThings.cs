using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class AllThings : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<GameObject> Boxes;
    // Update is called once per frame
    private void CleanUp()
    {
        //clean up lists
        for(int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i] == null)
            {
                Enemies.RemoveAt(i);
            }
        }
        for (int i = 0; i < Boxes.Count; i++)
        {
            if (Boxes[i] == null)
            {
                Boxes.RemoveAt(i);
            }
        }
    }
    //Add item to the lists
    public void push(GameObject n_element)
    {
        if (n_element.CompareTag("Enemy"))
        {
            Enemies.Add(n_element);
        }
        else
        {
            Boxes.Add(n_element);
        }
        CleanUp();
    }
    //disable all currently spawned enemies AIPath
    public void disableAll()
    {
        Enemies.ForEach(delegate (GameObject enemy)
        {
            try
            {
                enemy.GetComponent<AIPath>().enabled = false;
            }
            catch (Exception e) { }
        });
    }
    //enable all currently spawned enemies AIPath
    public void enableAll()
    {
        Enemies.ForEach(delegate (GameObject enemy)
        {
            try
            {
                enemy.GetComponent<AIPath>().enabled = true;
            }
            catch (Exception e) { }
        });
    }
    //destroy all enemies
    public void destroyAllEnemies()
    {
        Enemies.ForEach(delegate (GameObject enemy)
        {
            Destroy(enemy);
        });
        CleanUp();
    }
    //destroy all boxes
    public void destroyAllBoxes()
    {
        Boxes.ForEach(delegate (GameObject box)
        {
            Destroy(box);
        });
        CleanUp();
    }
    //destroy everything
    public void destroyAll()
    {
        Boxes.ForEach(delegate (GameObject box)
        {
            Destroy(box);
        });
        Enemies.ForEach(delegate (GameObject enemy)
        {
            Destroy(enemy);
        });
        CleanUp();
    }
}
