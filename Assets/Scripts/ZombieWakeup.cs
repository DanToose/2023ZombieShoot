using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWakeup : MonoBehaviour
{
    public GameObject[] sleepingZombies;

    public bool Triggered;
    public int relatedCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (Triggered == false && other.gameObject.tag == "Player")
        {
            WakeupZombies();
        }
    }

    public void WakeupZombies()
    {
        Triggered = true;

        foreach (GameObject zombie in sleepingZombies)
        {
            zombie.GetComponent<NavmeshAgentScript>().enabled = true;
        }
    }
}
