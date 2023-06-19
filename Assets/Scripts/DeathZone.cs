using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    PlayerDamage pD;
    // Start is called before the first frame update
    void Start()
    {
        pD = FindObjectOfType<PlayerDamage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pD.DamagePlayer(110.0f);
        }
    }
}
