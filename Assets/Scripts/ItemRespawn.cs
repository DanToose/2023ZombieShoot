using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    public int checkPointID;
    public bool isTaken;

    // ONLY WORKS ON RUN-OVER-TRIGGER ITEMS FOR NOW

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GhostItem();
            isTaken = true;
        }
    }

    public void GhostItem()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    public void RestoreItem()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
