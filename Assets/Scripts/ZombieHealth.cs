using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float zombieHealth = 100.0f;
    public float maxZombieHealth = 100.0f;

    public Rigidbody rb;

    public EnemyManagerZ emZ;

    [Header("Events")]
    public GameEvent onZombieDies;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        emZ = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManagerZ>();
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
            onZombieDies.Raise(this, null);
            emZ.ResetEnemyList();
            Destroy(gameObject);
        }
        
    }
}
