using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicToggle : MonoBehaviour
{
    public PlayerController playerControl; // Connects to the control script on the player, not a standard Characcter Controller component.
    public Camera cinematicCam;
    public Camera playerCam;

    public void ToggleCinemaMode()
    {
        cinematicCam.enabled = !cinematicCam.enabled;
        playerCam.enabled = !playerCam.enabled;
        playerControl.enabled = !playerControl.enabled;
    }
}
