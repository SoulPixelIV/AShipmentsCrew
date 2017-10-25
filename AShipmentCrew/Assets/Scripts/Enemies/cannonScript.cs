using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonScript : MonoBehaviour {

    public bool selfControl;
    public bool timer;
    public bool enemyControl;
    public bool distPlayer;
    public float shootTime;
    public float shootStrength;
    public float distance;

    float shootTimeSave;

    public GameObject cannonballPrefab;
    public FPCharacterController FPcc;
    public enemyShipMovement enMov;
    public Transform player;

	void Start () {
        shootTimeSave = shootTime;
	}
	
	void Update () {
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (timer == true)
        {
            shootTime -= 1 * Time.deltaTime;

            if (shootTime < 0)
            {
                if (distPlayer == false)
                {
                    Fire();
                    shootTime = shootTimeSave;
                }
                else
                {
                    if (distToPlayer < distance)
                    {
                        Fire();
                        shootTime = shootTimeSave;
                    }
                }
            }
        }
        if (selfControl == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && FPcc.inShip == true && FPcc.move == true)
            {
                Fire();
            }
        }
        if (enemyControl == true)
        {
            if (enMov.distPlayer < 30)
            {
                shootTime -= 1 * Time.deltaTime;

                if (shootTime < 0)
                {
                    Fire();
                    shootTime = shootTimeSave;
                }
            }
        }
    }

    void Fire()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        cannonball.GetComponent<Rigidbody>().AddForce(transform.forward * shootStrength, ForceMode.Impulse);
    }
}
