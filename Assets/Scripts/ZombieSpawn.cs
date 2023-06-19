using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;

    public bool Triggered;
    public int relatedCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (Triggered == false && other.gameObject.tag == "Player")
        {
            if (spawnPoints != null)
            {
                SpawnZombies();
            }
            else
            {
                Debug.Log("Spawner " + this.name + " hit, but no spawn points assigned.");
            }
        }
    }

    public void SpawnZombies()
    {
        Triggered = true;

        foreach (GameObject spawnPoint in spawnPoints)
        {
            Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void ResetSpawner(int cpID) // A function called from EnemyManagerZ to reset current
    {
        if (cpID <= relatedCheckpoint)
        {
            Triggered = false;
        }
    }
}
