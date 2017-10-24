using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFunctions : MonoBehaviour {
    public GameObject blurCam;
    public GameObject normCam;

    // Use this for initialization
    void Start () {
        blurCam.SetActive(false);
        normCam.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnBlurOn()
    {
        blurCam.SetActive(true);
        normCam.SetActive(false);
    }

    public void TurnBlurOff()
    {
        blurCam.SetActive(false);
        normCam.SetActive(true);
    }
}
