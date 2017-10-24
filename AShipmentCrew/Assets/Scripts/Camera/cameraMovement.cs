using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
    public bool shipCam;

    public shipMovement shipMov;
    public Transform player;
    public Transform camLookAt;
    public Transform camObj;

    void LateUpdate()
    {
        if (shipCam == true)
        {
            transform.position = new Vector3(camObj.transform.position.x, camObj.transform.position.y, camObj.transform.position.z);
            transform.LookAt(camLookAt.transform);
        }
    }
}
