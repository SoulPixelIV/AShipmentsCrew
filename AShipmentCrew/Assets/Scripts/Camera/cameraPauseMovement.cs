using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPauseMovement : MonoBehaviour {
    public Transform mainCam;
    public Transform player;
    void Update()
    {
        transform.position = mainCam.transform.position;
        transform.LookAt(player.transform);
    }
}
