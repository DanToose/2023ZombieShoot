using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    public float zombieHealth = 100.0f;
    public float maxZombieHealth = 100.0f;

    public Rigidbody rb;

    public EnemyManagerZ emZ;
    public int checkPointNumber;

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
            //emZ.ResetEnemyList(); NO LONGER REMOVING FROM LIST ON DEATH
            GhostZombie();
        }
        
    }

    public void GhostZombie()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<NavmeshAgentScript>().TargetSelf();
    }

    public void ReviveZombie()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        GetComponent<NavmeshAgentScript>().TargetPlayer();
        zombieHealth = maxZombieHealth;
    }
}
