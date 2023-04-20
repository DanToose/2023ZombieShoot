using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{

    public GameObject[] dimLights;
    public float newIntensity;
    
    // Start is called before the first frame update
    
    
    void Start()
    {
        if (dimLights == null)
        {
            dimLights = GameObject.FindGameObjectsWithTag("Dimmer");
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("dimmer zone hit");

            dimLights = GameObject.FindGameObjectsWithTag("Dimmer");

            foreach (GameObject light in dimLights)
            {
                light.gameObject.GetComponent<Light>().intensity = newIntensity;
                Debug.Log("light dimmed");
            }
        }
    }
}
