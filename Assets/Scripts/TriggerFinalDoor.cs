using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalDoor : MonoBehaviour
{
    public GameObject Door;
    public bool Triggered;

    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame


    public void OnTriggerEnter(Collider other)
    {
        if (Triggered == false && other.gameObject.tag == "Player")
        {
            Triggered = true;
            Door.GetComponent<Animator>().SetTrigger("FinalDoorTrigger"); // What I used for a one-off
        }
    }

}