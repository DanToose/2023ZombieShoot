using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public GameObject playerGun;
    public Gun pg;
    public int ammoInPack = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        playerGun = GameObject.Find("Gun");
        pg = playerGun.gameObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (pg.ammoCount != pg.ammoMax)
            {
                pg.ammoCount += ammoInPack;
                if (pg.ammoCount > pg.ammoMax)
                {
                    pg.ammoCount = pg.ammoMax;
                }
                Destroy(gameObject);
            }

        }
    }
}
