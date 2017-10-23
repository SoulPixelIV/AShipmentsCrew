using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {
    public GameObject wall;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            wall.gameObject.SetActive(false);
        }
    }
}
