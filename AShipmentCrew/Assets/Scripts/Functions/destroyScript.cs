using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyScript : MonoBehaviour {
    public float destroyTime;
	
	void Update () {
        destroyTime -= 1 * Time.deltaTime;

        if (destroyTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
