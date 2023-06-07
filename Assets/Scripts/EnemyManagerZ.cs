using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyManagerZ : MonoBehaviour
{
    public bool cullOldZombiesOnRespawn = true;
    public List<GameObject> enemyList = new List<GameObject>();

    private NavmeshAgentScript enemyNMA;
    private NavMeshAgent eNMA;
    public int currentCP = 0;

    // Start is called before the first frame update
    void Start()
    {
        ResetEnemyList(currentCP); // Establishes the Enemy List at CP 0 - The Start


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetEnemies(int cpID)
    {
        foreach (GameObject e in enemyList) // LIST WAS UPDATED AT LAST CP TOUCH
        {
            if (e != null)
            {
                enemyNMA = e.GetComponent<NavmeshAgentScript>();
                eNMA = e.GetComponent<NavMeshAgent>();
                eNMA.Warp(enemyNMA.startPos);
                e.GetComponent<ZombieHealth>().ReviveZombie();
                // New target reset
                enemyNMA.target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
        Debug.Log("All Enemies moved to start");
        
        if (cullOldZombiesOnRespawn) // If Inspector checkbox is on, cull any zombies from old CPs when after resetting enemies.
        {
            List<GameObject> cullEnemyList = new List<GameObject>();
            cullEnemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            cullEnemyList.AddRange(GameObject.FindGameObjectsWithTag("EnemyStrong"));
            for (int i = 0; i < cullEnemyList.Count; i++)
            {
                GameObject x = cullEnemyList[i];
                if (x.GetComponent<ZombieHealth>().checkPointNumber < cpID)
                {
                    cullEnemyList.RemoveAt(i);
                    i--;
                    Destroy(x);
                }

            }
        }



    }

    // THIS RESETS THE LIST OF ENEMIES TRACKED - JUST THE LIST
    public void ResetEnemyList(int cpID)
    {
        currentCP = cpID;
        Debug.Log("Resetting Enemy List!");
        enemyList.Clear();
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("EnemyStrong"));
        // COPY PASTE FOR ALL OTHER ENEMY TYPES

        for(int i = 0; i < enemyList.Count; i++)
        {
            GameObject e = enemyList[i];
            if (e.GetComponent<ZombieHealth>().checkPointNumber < cpID)
            {
                enemyList.RemoveAt(i);
                i--;
                if (e.GetComponent<ZombieHealth>().zombieHealth <= 0)
                {
                    Destroy(e); // Also destroys any lingering Zombie Ghosts
                }
            }
        }
    }

    public void StopZombiesMoving()
    {
        foreach (GameObject e in enemyList)
        {
            if (e != null && e.GetComponent<NavmeshAgentScript>().enabled) 
            {
                e.GetComponent<NavmeshAgentScript>().target = e.transform;
            }
        }
    }

    public void UpdateZStartPoints()
    {
        foreach (GameObject e in enemyList)
        {
            if (e != null)
            {
                enemyNMA.startPos = e.transform.position;
            }
        }
    }
}
