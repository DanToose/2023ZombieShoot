using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPlayerMovement : MonoBehaviour
{
    public GameObject player;
    public PlayerController controller;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (controller == null)
        {
            controller = player.GetComponent<PlayerController>();
        }
    }

    public void ToggleDoubleJump()
    {
        controller.allowDoubleJump = !controller.allowDoubleJump;
    }

    public void SetJumpForce(float jForce)
    {
        controller.jumpForce = jForce;
    }

    public void SetSpeed(float nSpeed)
    {
        controller.speed = nSpeed;
    }
}
