using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;
    // IF YOU NEED MORE THAN 4 - ADD MORE PUBLIC DECLARATIONS HERE.

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
            SpawnZombies();
        }
    }

    public void SpawnZombies()
    {
        Triggered = true;
        if (SpawnPoint1 != null)
            Instantiate(enemyPrefab, SpawnPoint1.transform.position, Quaternion.identity);
        if (SpawnPoint2 != null)
            Instantiate(enemyPrefab, SpawnPoint2.transform.position, Quaternion.identity);
        if (SpawnPoint3 != null)
            Instantiate(enemyPrefab, SpawnPoint3.transform.position, Quaternion.identity);
        if (SpawnPoint4 != null)
            Instantiate(enemyPrefab, SpawnPoint4.transform.position, Quaternion.identity);
    }

    public void ResetSpawner(int cpID) // A function called from EnemyManagerZ to reset current
    {
        if (cpID <= relatedCheckpoint)
        {
            Triggered = false;
        }
    }
}
