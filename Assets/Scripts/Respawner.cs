using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    public List<GameObject> CPList = new List<GameObject>();
    public GameObject currentCheckpoint;
    private Transform checkpointLocation;
    public GameObject player;
    private GameObject startingPoint;
    //private CharacterController charController;
    private GameObject levelManager;
    private EnemyManagerZ enemyManager;
    private ItemManager itemManager;
    public Material activeMaterial;
    public Material inactiveMaterial;

    public int ammoAtCP; // ammo when the player reached this CP
    public int scoreAtCP; // score when the player reached this CP
    public int currentCPID; // The ID number of the current CP

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindGameObjectWithTag("Player");
        //charController = player.gameObject.GetComponent<CharacterController>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        enemyManager = GetComponent<EnemyManagerZ>();
        itemManager = GetComponent<ItemManager>();

        startingPoint = GameObject.FindGameObjectWithTag("StartPoint");
        if (currentCheckpoint == null)
        {
            startingPoint = GameObject.FindGameObjectWithTag("StartPoint");
            currentCheckpoint = startingPoint;
        }
        currentCheckpoint = startingPoint;
        currentCPID = 0;

        CPList.AddRange(GameObject.FindGameObjectsWithTag("CheckPoint"));
        InitialSpawn();


}

    // THIS JUST MOVES THE PLAYER TO THE START POINT, AND ESTABLISHES STARTING SCORE AND AMMO.

    private void InitialSpawn()
    {            
        //Debug.Log("St: " + startingPoint);
        player.gameObject.transform.position = startingPoint.gameObject.transform.position;

        scoreAtCP = levelManager.GetComponent<LevelManager>().score;
        ammoAtCP = levelManager.GetComponent<LevelManager>().ammo;

    }

    // BOTH RESPAWNS THE PLAYER, AND TRIGGERS THE RESET OF THINGS RELATED TO THE CURRENT CP.
    public void RespawnPlayer()
    {
        enemyManager.ResetEnemies(currentCPID);
        enemyManager.ResetEnemyList(currentCPID);
        itemManager.ResetItems();
        itemManager.ResetAnims(currentCPID);
        itemManager.ResetAnimList(currentCPID);
        ResetCPBasedTriggers();

        // positions the player at the CP
        checkpointLocation = currentCheckpoint.transform;
        player.transform.position = checkpointLocation.position;


        // Sets the ammo and score to be what the player had at CP
        levelManager.GetComponent<LevelManager>().score = scoreAtCP;
        levelManager.GetComponent<LevelManager>().ammo = ammoAtCP;

        Invoke("ReactivateController", 0.5f);

    }

    // CALLED FROM A CP - THIS UPDATES WHICH CP IS VISIBLE, TAKES STOCK OF SCORE/AMMO, AND CPID.
    public void UpdateCheckPoints(int ID)
    {
        foreach (GameObject l in CPList)
        {
            if (l.gameObject.GetComponent<CheckPoint>().isCheckpoint == false)
            {
                l.gameObject.GetComponent<MeshRenderer>().material = inactiveMaterial;
            }
            else
            {
                l.gameObject.GetComponent<MeshRenderer>().material = activeMaterial;
            }
        }
        currentCPID = ID;
        scoreAtCP = levelManager.GetComponent<LevelManager>().score;
        ammoAtCP = levelManager.GetComponent<LevelManager>().ammo;

        enemyManager.ResetEnemyList(currentCPID);
        itemManager.ResetItemList(currentCPID);
        itemManager.ResetAnimList(currentCPID);

    }

    private void ResetCPBasedTriggers()
    {
        EventZone[] ezTriggerList = FindObjectsOfType<EventZone>();
        foreach (EventZone ezTrigger in ezTriggerList)
        {
            if (ezTrigger.isCheckPointLinked)
            {
                ezTrigger.ResetEventZone(currentCPID);
            }
        }

    }

    private void ReactivateController()
    {
        //player.SetActive(true);
    }
}