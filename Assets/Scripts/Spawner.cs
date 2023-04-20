using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float timeBetweenSpawns = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
	{
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
	}
}
