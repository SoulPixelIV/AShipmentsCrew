using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    public bool Invert;
    public bool pause;
    public float speed;
    public float speedSave;
    public float pauseTime;
    public float pauseTimeSave;
    public int currDir;
    public bool scale;
    int direction;
	// Use this for initialization
	void Start () {
        pauseTimeSave = pauseTime;
        speedSave = speed;
        direction = 4;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            speed = 0;
            pause = true;
        }
    }

        // Update is called once per frame
        void Update() {
        if (pause == true)
        {
            pauseTime -= 1 * Time.deltaTime;
            if (scale == false)
            {
                gameObject.transform.localScale += new Vector3(1.6f, 0, 1.6f);
                scale = true;
            }
        }
        if (pauseTime < 0)
        {
            pause = false;
            pauseTime = pauseTimeSave;
            speed = speedSave;
            if (currDir == 0)
            {
                currDir = 1;
            }
            else
            {
                currDir = 0;
            }
            if (scale == true)
            {
                gameObject.transform.localScale -= new Vector3(1.6f, 0, 1.6f);
                scale = false;
            }
        }

        if (direction == 0)
        {
            transform.position += ((transform.up * speed) * Time.deltaTime);
        }

        if (direction == 1)
        {
            transform.position -= ((transform.up * speed) * Time.deltaTime);
        }

        if (direction == 2)
        {
            transform.position += ((transform.right * speed) * Time.deltaTime);
        }

        if (direction == 3)
        {
            transform.position -= ((transform.right * speed) * Time.deltaTime);
        }

        if (currDir == 0)
        {
            if (Invert == true)
            {
                direction = 2;
            }
            else
            {
                direction = 0;
            }
        }
        if (currDir == 1)
        {
            if (Invert == true)
            {
                direction = 3;
            }
            else
            {
                direction = 1;
            }
        }
    }
}
