using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed = 10.0f;
    public float jumpForce = 300.0f;
    private float translation;
    private float straife;

    // Use this for initialization
    void Start () {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;		
	}
	
	// Update is called once per frame
	void Update () {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straife = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straife, 0, translation);

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("space"))
        {
            // turn on the cursor
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
        }
    }
}