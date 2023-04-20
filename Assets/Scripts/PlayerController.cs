using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 300.0f;
    public float speed = 10.0f;
    public float maxGroundDistance = 1.5f;
    private bool isGrounded;
    public bool allowDoubleJump = false;
    private int amountOfJumps = 0;
    private float Zmovement = 0f;
    private float Xmovement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxGroundDistance);
        if (isGrounded == true)
        {
            amountOfJumps = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Zmovement = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Zmovement = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Xmovement = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Xmovement = -1;
        }

        if ((Xmovement != 0) && (Zmovement != 0))
        {
            transform.position = transform.position + ((transform.forward * Zmovement) * speed * Time.deltaTime * 0.7f);
            transform.position = transform.position + ((transform.right * Xmovement) * speed * Time.deltaTime * 0.7f);
        }

        if ((Xmovement == 0) || (Zmovement == 0))
        {
            transform.position = transform.position + ((transform.forward * Zmovement) * speed * Time.deltaTime);
            transform.position = transform.position + ((transform.right * Xmovement) * speed * Time.deltaTime);
        }

        Xmovement = 0;
        Zmovement = 0;

        /* OLD MOVEMENT SCRIPT - ALLOWED FOR FASTER MOVEMENT BY MOVING DIAGONALLY.
         
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (-transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (-transform.right * speed * Time.deltaTime);
        }
         */



        if (Input.GetKeyDown("space"))
        {

            if (isGrounded)
            {
                // turn on the cursor
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                amountOfJumps = 1;
            }
            else if (amountOfJumps < 2 && allowDoubleJump)
            {
                // turn on the cursor
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                amountOfJumps = 2;
            }

        }
    }
}
