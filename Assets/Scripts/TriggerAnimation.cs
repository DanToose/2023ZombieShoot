using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    public GameObject objectToMove;
    public string TriggerName; // Me having NFI what variable type I need.
    
    // Start is called before the first frame update
    void Start() 
    {
        //TriggerName = "ButtonPress";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToMove.GetComponent<Animator>().SetTrigger("PlateTrigger"); // What I used for a one-off
          //  objectToMove.GetComponent<Animator>().SetTrigger(TriggerName); // Me wanting to make this a thing to be set in Inspector
        }
    }
}
