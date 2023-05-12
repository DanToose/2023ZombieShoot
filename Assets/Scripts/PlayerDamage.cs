using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    // RESPAWNER STUFF
    public float respawnDelay = 3.0f;
    public Respawner respawn;
    public bool playerIsAlive;
    private bool readyToRespawn;
    public Text healthText;
    public Text deathText;
    public Text respawnText;
    public Image deathPanel;

    [Header("Events")]
    public GameEvent onPlayerDies;
    public GameEvent onPlayerResawns;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
        healthText = GameObject.Find("Health Text").GetComponent<Text>();
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
        respawnText = GameObject.Find("RespawnText").GetComponent<Text>();
        deathPanel = GameObject.Find("DeathPanel").GetComponent<Image>();
        playerIsAlive = true;
        respawnText.text = "";
        deathText.text = "";
        deathPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            health = 0;
            playerDeath();
            playerIsAlive = false;
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if (readyToRespawn && Input.anyKeyDown)
        {
            readyToRespawn = false;
            respawnText.text = "";
            deathText.text = "";
            deathPanel.gameObject.SetActive(false);
            ActualRespawn();
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

    public void playerDeath()
    {
        // death stuff
        deathPanel.gameObject.SetActive(true);
        deathText.text = "You Died!";
        playerIsAlive = false;
        Invoke("RespawnFromDeath", respawnDelay);
        onPlayerDies.Raise(this, null);
        // CHAR CONTROLLER SHOULD STOP AT THIS POINT
        //charController.enabled = false;



    }

    void RespawnFromDeath()
    {
        respawnText.text = "Press any key to respawn";
        readyToRespawn = true;
    }

    void ActualRespawn()
    {
        if (!playerIsAlive)
        { 
            health = maxHealth;
            playerIsAlive = true;
            onPlayerResawns.Raise(this, null);
            respawn.RespawnPlayer();
        }
    }
}
