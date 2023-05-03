using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public float health = 100.0f;
    public float maxHealth = 100.0f;
    public float timer = 0.0f;
    GameObject LevelManager;
    public GameObject painEffect;
    public float painTimer = 0.0f;
    public float damageScaleNormal = 1.0f;
    public float damageScaleElite1 = 1.5f;
    public float damageScaleElite2 = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HurtMeDaddy(damageScaleNormal);
        }
        else if (collision.gameObject.tag == "EnemyStrong")
        {
            HurtMeDaddy(damageScaleElite1);
        }
        else if (collision.gameObject.tag == "EnemyBoss")
        {
            HurtMeDaddy(damageScaleElite2);
        }
    }

    public void HurtMeDaddy(float scale)
    {
        timer = timer + Time.deltaTime;
        painTimer = painTimer - Time.deltaTime;
        if (timer >= 0.05)
        {
            health = health - 1 * LevelManager.GetComponent<LevelManager>().damageMultiplyer * scale;
            timer = 0.0f;
        }

        if (painTimer <= 0.0)
        {
            Instantiate(painEffect, transform.position, Quaternion.identity);
            painTimer = 1.0f;
        }
    }
}
