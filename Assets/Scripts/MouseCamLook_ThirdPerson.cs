using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook_ThirdPerson : MonoBehaviour
{

    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    public GameObject character;     // the chacter is the capsule
    public GameObject head;     //head 
    private Vector2 mouseLook; // get the incremental value of mouse moving
    private Vector2 smoothV; // smooth the mouse moving

    float initialAngle;
    float initialAngleHead;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject.transform.parent.gameObject;
        head = this.transform.parent.gameObject;
        initialAngle = character.transform.localEulerAngles.y;

    }

    // Update is called once per frame
    void Update()
    {
        // md is mouse delta
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis

        mouseLook.y = Mathf.Clamp(mouseLook.y, -70f, 90f);

        head.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(initialAngle + mouseLook.x, Vector3.up);

    }
}