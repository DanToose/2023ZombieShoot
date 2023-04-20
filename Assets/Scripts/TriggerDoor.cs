using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public GameObject Door;
    public bool Triggered;

    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {
        if (Triggered == false && other.gameObject.tag == "Player")
        {
            Triggered = true;
            Door.GetComponent<DoorLock>().UnlockedCount++;
            Door.GetComponent<DoorLock>().LockCheck();
        }
    }

}
