using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerZ : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();

    private NavmeshAgentScript enemyNMA;

    // Start is called before the first frame update
    void Start()
    {
        enemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetEnemies()
    {
        foreach (GameObject e in enemyList)
        {
            enemyNMA = e.GetComponent<NavmeshAgentScript>();
            /*
            if (enemyNMA.jobIsPatrol)
            {
                enemyNMA.AIState = 3;
            }
            else
            {
                enemyNMA.AIState = 4;
            }
            
            e.transform.position = enemyNMA.wayPoints[0].transform.position;
            e.transform.rotation = enemyNMA.wayPoints[0].transform.rotation;
            */

        }
        Debug.Log("All Enemies reset");
    }
}
