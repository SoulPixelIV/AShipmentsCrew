using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopScript : MonoBehaviour {

    public GameObject shopCam;
    public GameObject normCam;
    public Button buttonSpeedUpgrade;
    public Button buttonCannonUpgrade;
    public Button buttonTurnUpgrade;
    public Button buttonBrakeUpgrade;
    public Button buttonShipUpgrade;
    public Button buttonExit;
    public Transform ship;

    public bool speedUpgradeBought;
    public bool cannonUpgradeBought;
    public bool inShop;

    public FPCharacterController FPcc;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ship")
        {
            shopEnter();
        }
    }

    void shopEnter () {
        inShop = true;
        FPcc.move = false;
        normCam.SetActive(false);
        shopCam.SetActive(true);
        buttonSpeedUpgrade.gameObject.SetActive(true);
        buttonCannonUpgrade.gameObject.SetActive(true);
        buttonExit.gameObject.SetActive(true);
        buttonTurnUpgrade.gameObject.SetActive(true);
        buttonBrakeUpgrade.gameObject.SetActive(true);
        buttonShipUpgrade.gameObject.SetActive(true);
    }

    void shopExit()
    {
        inShop = false;
        FPcc.move = true;
        normCam.SetActive(true);
        shopCam.SetActive(false);
        buttonSpeedUpgrade.gameObject.SetActive(false);
        buttonCannonUpgrade.gameObject.SetActive(false);
        buttonExit.gameObject.SetActive(false);
        buttonTurnUpgrade.gameObject.SetActive(false);
        buttonBrakeUpgrade.gameObject.SetActive(false);
        buttonShipUpgrade.gameObject.SetActive(false);
        ship.transform.position = ship.transform.position + new Vector3(0, 0, -15);
    }

    public void buttonLeaveShop()
    {
        shopExit();
    }

    public void upgradeSpeed()
    {
        if (FPcc.money > 2199 && speedUpgradeBought == false)
        {
            FPcc.money -= 2200;
            FPcc.itemSpeed = true;
            speedUpgradeBought = true;
        }
    }

    public void upgradeCannon()
    {
        if (FPcc.money > 2559 && cannonUpgradeBought == false)
        {
            FPcc.money = FPcc.money - 2560;
            GameObject cannon = GameObject.FindGameObjectWithTag("cannon");
            cannon.SetActive(true);
            cannonUpgradeBought = true;
        }
    }
}
