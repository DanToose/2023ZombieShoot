using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WipeZombies : MonoBehaviour
{
    public Transform target;
    public GameObject[] zombieList;
    public GameObject[] enemy2List;      //ADD THIS IF YOU WANT TO PURGE ENEMIES WITH OTHER TAGS.

    [Header("Events")]
    public GameEvent allZombiesWiped;


    public void PurgeZombies()
    {
        zombieList = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject z in zombieList)
        {
            Destroy(z.gameObject);
        }


        enemy2List = GameObject.FindGameObjectsWithTag("EnemyStrong");  //PUT THE OTHER TAG IN!!!

        foreach (GameObject y in enemy2List)
        {
            Destroy(y.gameObject);
        }
        

        allZombiesWiped.Raise(this, null); // An event to note all Zombies were wiped if needed.

        Array.Clear(zombieList, 0, zombieList.Length);
        zombieList = null;
        enemy2List=null;
    }

    public void WakeAllZombies()
    {
        // WARNING - This will wake ALL sleeping zombies, including any used in 'waiting traps'
        zombieList = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject z in zombieList)
        {
            NavmeshAgentScript nmaScript = z.gameObject.GetComponent<NavmeshAgentScript>();
            nmaScript.enabled = true;
            nmaScript.TargetPlayer();
        }

        Array.Clear(zombieList, 0, zombieList.Length);
        zombieList = null;
    }

    public void SleepAllZombies()
    {
        zombieList = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject z in zombieList)
        {
            NavmeshAgentScript nmaScript = z.gameObject.GetComponent<NavmeshAgentScript>();
            if (nmaScript.enabled)
            {
                nmaScript.TargetSelf();
                nmaScript.enabled = false;
            }
        }

        Array.Clear(zombieList, 0, zombieList.Length);
        zombieList = null;
    }


}
