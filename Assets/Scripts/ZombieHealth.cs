using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float zombieHealth = 100.0f;
    public float maxZombieHealth = 100.0f;

    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageZombie(float incomingDamage)
    {
        rb.velocity = new Vector3(0, 0, 0);
        zombieHealth = zombieHealth - incomingDamage;
        Debug.Log(zombieHealth);
        if (zombieHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
