using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventZone : MonoBehaviour
{
    private GameObject player;
    private bool isDone;
    public bool isRepeatable;
    public bool isCheckPointLinked;
    public int resetUpToCP;

    [Header("Events")]
    public GameEvent onTriggerEntered;

    // Start is called before the first frame update
    void Start()
    {
        isDone = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isDone)
        {
            isDone = true;

            onTriggerEntered.Raise(this, null);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isDone)
        {
            if (isRepeatable)
            {
                isDone = false;
            }
        }
    }

    public void ResetEventZone(int cpID)
    {
        if (isCheckPointLinked && isDone && cpID <= resetUpToCP)
        {
            isDone = false;
            //Debug.Log("Reset EZ on object: " + this.gameObject.name);
        }
    }
}
