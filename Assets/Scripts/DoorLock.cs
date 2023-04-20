using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public int LockCount;
    public int UnlockedCount;

    public bool Lock;



    // Start is called before the first frame update
    void Start()
    {
        Lock = true;
    }

    public void LockCheck()
    {
        if (UnlockedCount == LockCount)
        {
            Lock = false;
            GetComponent<Animator>().SetTrigger("DoorTrigger");
        }
    }
}
