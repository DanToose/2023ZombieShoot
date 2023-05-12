using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int highScore;
    [HideInInspector] public int score;
    [HideInInspector] public float health;
    [HideInInspector] public int ammo;
    public float damageMultiplyer = 1.0f;
    public Text highScoreText;
    public Text scoreText;
    //public Text healthText;
    public Text ammoText;
    public GameObject playerGun;
    public Gun pg;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HIGHSCORE");
        highScoreText.text = "High Score: " + highScore;
        playerGun = GameObject.Find("Gun");
        pg = playerGun.gameObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {

        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamage>().health;
        ammo = pg.ammoCount;
        scoreText.text = "Score: " + score;
        //healthText.text = "Health: " + health;
        ammoText.text = "Ammo: " + ammo;

        if (highScore < score)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            PlayerPrefs.Save();
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
        }
    }

}
