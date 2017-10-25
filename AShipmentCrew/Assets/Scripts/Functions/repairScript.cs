using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class repairScript : MonoBehaviour {

    public GameObject repairCam;
    public GameObject normCam;
    public Button buttonRepairShip;
    public Button buttonExit;
    public Transform ship;

    public FPCharacterController FPcc;
    public shipMovement spMov;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ship")
        {
            repairEnter();
        }
    }

    void repairEnter () {
        FPcc.move = false;
        normCam.SetActive(false);
        repairCam.SetActive(true);
        buttonExit.gameObject.SetActive(true);
        buttonRepairShip.gameObject.SetActive(true);
    }

    void repairExit()
    {
        FPcc.move = true;
        normCam.SetActive(true);
        repairCam.SetActive(false);
        buttonExit.gameObject.SetActive(false);
        buttonRepairShip.gameObject.SetActive(false);
        ship.transform.position = ship.transform.position + new Vector3(0, 0, 15);
    }

    public void buttonLeaveShop()
    {
        repairExit();
    }

    public void repairShip()
    {
        if (FPcc.money > 699 && spMov.shipHealth < 100)
        {
            FPcc.money -= 700;
            spMov.shipHealth = 100;
        }
    }
}
