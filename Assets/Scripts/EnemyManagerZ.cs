using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManagerZ : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();

    private NavmeshAgentScript enemyNMA;
    private NavMeshAgent eNMA;

    // Start is called before the first frame update
    void Start()
    {
        ResetEnemyList();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetEnemies()
    {
        foreach (GameObject e in enemyList)
        {
            Debug.Log("Checking: " + e.name);
            if (e != null)
            {
                enemyNMA = e.GetComponent<NavmeshAgentScript>();
                eNMA = e.GetComponent<NavMeshAgent>();
                eNMA.Warp(enemyNMA.startPos);

            }


        }
        Debug.Log("All Enemies reset");
    }

    public void ResetEnemyList()
    {
        Debug.Log("Resetting Enemy List!");
        enemyList.Clear();
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("EnemyStrong"));
        // COPY PASTE FOR ALL OTHER ENEMY TYPES


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
