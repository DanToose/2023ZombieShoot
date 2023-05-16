using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject gameManager;
    public Respawner respawn;
    public int currentCPID = 0; // The ID number of the current CP
    public List<GameObject> itemList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        respawn = gameManager.GetComponent<Respawner>();
        ResetItemList(currentCPID);
    }


    public void ResetItems() 
    {
        foreach (GameObject item in itemList)
        {
            if (item != null) 
            { 
                item.GetComponent<ItemRespawn>().RestoreItem();
            }
        }
    }

    // THIS RESETS THE LIST OF POWERUP ITEMS TRACKED - JUST THE LIST
    public void ResetItemList(int cpID)
    {
        currentCPID = cpID;
        Debug.Log("Resetting Item List!");
        itemList.Clear();
        ItemRespawn[] respawnableItems = FindObjectsOfType<ItemRespawn>();
        // COPY PASTE FOR ALL OTHER ITEM TYPES YOU NEED TO RESPAWN

        foreach (ItemRespawn rItem in respawnableItems) // 
        {
            if (rItem.checkPointID >= cpID)
            {
                itemList.Add(rItem.gameObject);
            }
        }

        foreach (GameObject item in itemList) // NOW CULL OLD ITEMS from itemList FROM RESPAWN LIST.
        {
            if (item.GetComponent<ItemRespawn>().checkPointID < cpID)
            {
                itemList.Remove(item);
                if (item.GetComponent<ItemRespawn>().isTaken)
                {
                    Destroy(item); // Also destroys any lingering item references from old CP
                    // THIS MEANS UNCOLLECTED ITEMS ARE STILL LEFT IN THE GAME.
                }
            }
        }


    }

}
