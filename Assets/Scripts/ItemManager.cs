using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject gameManager;
    public Respawner respawn;
    public int currentCPID = 0; // The ID number of the current CP
    public List<GameObject> itemList = new List<GameObject>();

    public List<GameObject> animList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        respawn = gameManager.GetComponent<Respawner>();
        ResetItemList(currentCPID);
        ResetAnimList(currentCPID);
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
        Debug.Log("Items were respawned for " + currentCPID + " and beyond");
    }

    // THIS RESETS THE LIST OF POWERUP ITEMS TRACKED - JUST THE LIST
    public void ResetItemList(int cpID)
    {
        currentCPID = cpID;
        Debug.Log("Resetting Item List! Current CPID = " + currentCPID);
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

        for (int i = 0; i < itemList.Count; i++) // NOW CULL OLD ITEMS from itemList FROM RESPAWN LIST.
        {
            GameObject item = itemList[i];
            if (item.GetComponent<ItemRespawn>().checkPointID < cpID)
            {
                itemList.RemoveAt(i);
                i--;
                if (item.GetComponent<ItemRespawn>().isTaken)
                {
                    Destroy(item); // Also destroys any lingering item references from old CP
                    // THIS MEANS OLD UNCOLLECTED ITEMS ARE STILL LEFT IN THE GAME.
                }
            }
        }
    }

    public void ResetAnimList(int cpID)
    {
        currentCPID = cpID;
        animList.Clear();
        TriggerAnim[] anims = FindObjectsOfType<TriggerAnim>();
        foreach (TriggerAnim anim in anims)
        {
            Debug.Log("Checking ID and played status on " + anim);
            if (anim.associatedCP >= cpID || !anim.playedOnce)
            {
                animList.Add(anim.gameObject);
                Debug.Log("Anim: " + anim + " added to list");
            }
        }

        Debug.Log("Resetting Anim List! Current CPID = " + currentCPID);

        for (int i = 0; i < animList.Count; i++) // NOW CULL OLD ANIMS from animList FROM RESPAWN LIST.
        {
            GameObject anim = animList[i];
            if (anim.GetComponent<TriggerAnim>().associatedCP < cpID)
            {

                if (anim.GetComponent<TriggerAnim>().playedOnce)
                {
                    animList.RemoveAt(i);
                    i--;
                }


            }
        }

    }

    public void ResetAnims(int cpID)
    {
        foreach (GameObject anim in animList)
        {
            if (anim != null && anim.GetComponent<TriggerAnim>().playedOnce)
            {
                if (anim.GetComponent<TriggerAnim>().associatedCP >= cpID)
                {
                    anim.GetComponent<TriggerAnim>().ResetAnim();
                }

            }
        }

        Debug.Log("Anims were reset for " + currentCPID + " and beyond");
    }

}
