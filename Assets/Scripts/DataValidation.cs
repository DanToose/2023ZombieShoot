using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataValidation : MonoBehaviour
{
    // THIS SCRIPT RUNS CHECKS TO ENSURE THAT THERE ARE NO CLASHES WITH ID VALUES ON GAMEOBJECTS THAT SHOULD BE UNIQUE

    // Start is called before the first frame update
    void Start()
    {
        CheckInvItemIDs();
        CheckCPIDs();
    }

    private void CheckInvItemIDs()
    {
        bool sharedIDFound = false;
        InvItemID[] invItemsInScene = FindObjectsOfType<InvItemID>();

        foreach (InvItemID invItem in invItemsInScene) 
        {
            int thisID = invItem.ID;
            foreach (InvItemID otherItem in invItemsInScene)
            {
                if (invItem != otherItem)
                {
                    if (otherItem.ID == thisID)
                    {
                        sharedIDFound = true;
                        Debug.Log("Found shared invItemIDs! " + invItem  + " and " + otherItem );
                    }
                }
            }
        }
    }

    private void CheckCPIDs()
    {
        bool sharedCPIDFound = false;
        CheckPoint[] CPsinScene = FindObjectsOfType<CheckPoint>();

        foreach (CheckPoint thisCP in CPsinScene)
        {
            int thisCPID = thisCP.checkPointID;
            foreach (CheckPoint otherCP in CPsinScene)
            {
                if (thisCP != otherCP)
                {
                    if (otherCP.checkPointID == thisCPID)
                    {
                        sharedCPIDFound = true;
                        Debug.Log("Found shared CP value! " + thisCP + " and " + otherCP);
                    }
                }
            }
        }
    }

    private void CheckObjectives()
    {
        bool sharedObjIDFound = false;
        GameObjective[] ObejctivesInScene = FindObjectsOfType<GameObjective>();

        foreach (GameObjective thisObj in ObejctivesInScene)
        {
            int thisObjID = thisObj.objectiveID;
            foreach (GameObjective otherObj in ObejctivesInScene)
            {
                if (thisObj != otherObj)
                {
                    if (otherObj.objectiveID == thisObjID)
                    {
                        sharedObjIDFound = true;
                        Debug.Log("Found shared ObjectiveID value! " + thisObj + " and " + otherObj);
                    }
                }
            }
        }
    }

}
