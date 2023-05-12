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
                Debug.Log("Current Pos: " + e.transform.position + " NMA startPOS" + enemyNMA.startPos.position);
                e.transform.position = enemyNMA.startPos.position;
                e.transform.rotation = enemyNMA.startPos.rotation;
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
 
}
