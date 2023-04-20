using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLock : MonoBehaviour
{
    public int LockCount;
    public int UnlockedCount;

    public bool Lock;

    void Start()
    {
        Lock = true;
    }

    public void LockCheck()
    {
        if (UnlockedCount == LockCount)
        {
            Lock = false;
        }
    }
}
