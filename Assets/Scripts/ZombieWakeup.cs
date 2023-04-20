using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWakeup : MonoBehaviour
{
    public GameObject Zombie1;
    public GameObject Zombie2;
    public GameObject Zombie3;
    public GameObject Zombie4;
    public GameObject Zombie5;
    public GameObject Zombie6;
    public GameObject Zombie7;
    public GameObject Zombie8;
    public GameObject Zombie9;
    public GameObject Zombie10;

    public bool Triggered;

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
            Triggered = true;
            Zombie1.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie2.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie3.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie4.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie5.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie6.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie7.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie8.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie9.GetComponent<NavmeshAgentScript>().enabled = true;
            Zombie10.GetComponent<NavmeshAgentScript>().enabled = true;
        }
    }
}
