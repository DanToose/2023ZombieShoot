using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZWipe : MonoBehaviour
{
    [Header("Events")]
    public GameEvent triggerZBomb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerZBomb.Raise(this, null);
        }
    }
}
