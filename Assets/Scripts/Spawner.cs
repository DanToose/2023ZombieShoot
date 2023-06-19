using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab; // The prefab to spawn
    public float timeBetweenSpawns = 5.0f;

    public void BeginSpawning()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, timeBetweenSpawns);
    }

    public void CancelSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        //EnemyManagerZ eMZ = FindObjectOfType<EnemyManagerZ>();
        //eMZ.ResetEnemyList(eMZ.currentCP);
    }
}
