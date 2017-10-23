using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour {
    public float shootTime;
    public bool timer;
    public float shootTimeSave;

    public GameObject turretCubePrefab;
    public Transform player;
    // Use this for initialization
    void Start () {
        shootTimeSave = shootTime;
    }
	
	// Update is called once per frame
	void Update () {
        float distPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (timer == true)
        {
            shootTime -= 1 * Time.deltaTime;

            if (shootTime < 0)
            {
                shootTime = shootTimeSave;
                if (distPlayer < 18)
                {
                    Fire();
                }
            }
        }

        transform.LookAt(player);
    }

    void Fire()
    {
        GameObject turretCube = Instantiate(turretCubePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        turretCube.GetComponent<Rigidbody>().AddForce(transform.forward * 600, ForceMode.Force);
    }
}
