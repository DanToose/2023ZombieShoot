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

    public bool Triggered;

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
            Triggered = true;
            Instantiate(enemyPrefab, SpawnPoint1.transform.position, Quaternion.identity);
            Instantiate(enemyPrefab, SpawnPoint2.transform.position, Quaternion.identity);
            Instantiate(enemyPrefab, SpawnPoint3.transform.position, Quaternion.identity);
            Instantiate(enemyPrefab, SpawnPoint4.transform.position, Quaternion.identity);
        }
    }
}
