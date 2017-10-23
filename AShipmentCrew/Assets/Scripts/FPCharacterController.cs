using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharacterController : MonoBehaviour {
    public float movementSpeed;
    public float mouseSensitivity;
    public float upDownRange;
    float verticalRotation = 0;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();

        cc.SimpleMove(speed);
    }
}
