using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlaySound : MonoBehaviour
{
    public AudioClip SoundToPlay;
    AudioSource soundSource;
    public bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        soundSource = gameObject.GetComponent<AudioSource>();
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered == false)
        {
            soundSource.PlayOneShot(SoundToPlay);
            isTriggered = true;
        }
    }
}
