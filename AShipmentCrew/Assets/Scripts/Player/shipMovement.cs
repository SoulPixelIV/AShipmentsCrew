using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipMovement : MonoBehaviour {
	public float speed;
	public float rotSpeed;
    public float shipHealth;
    public int shipHealthDisplay;

	public FPCharacterController FPcc;
    public GameObject canonball;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject damagePart1;
    public GameObject damagePart2;
    public GameObject damagePart3;
    public GameObject damagePart4;
    public Transform canon;
    public Text shipHealthVar;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "island")
        {
            speed = -speed;
        }
        if (other.gameObject.tag == "wall")
        {
            speed = -speed;
        }
        if (other.gameObject.tag == "enemyShip")
        {
            speed = -speed / 3;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cannonball")
        {
            shipHealth -= 15;
        }
    }

    void Update ()
    {
        shipHealthDisplay = Mathf.RoundToInt(shipHealth);
        shipHealthVar.text = "Ship Health: " + shipHealth;

        if (shipHealth > 70)
        {
            fire1.gameObject.SetActive(false);
            fire2.gameObject.SetActive(false);
            damagePart1.gameObject.SetActive(true);
            damagePart2.gameObject.SetActive(true);
            damagePart3.gameObject.SetActive(true);
            damagePart4.gameObject.SetActive(true);
        }
        if (shipHealth < 70)
        {
            damagePart1.gameObject.SetActive(false);
        }
        if (shipHealth < 50)
        {
            fire1.gameObject.SetActive(true);
            damagePart2.gameObject.SetActive(false);
            damagePart3.gameObject.SetActive(false);
        }
        if (shipHealth < 30)
        {
            damagePart4.gameObject.SetActive(false);
            fire1.gameObject.SetActive(true);
            fire2.gameObject.SetActive(true);
        }
        if (shipHealth < 1)
        {
            FPcc.exitShip();
            Destroy(gameObject);
        }

        if (FPcc.pause == true)
        {
            speed = 0;
            rotSpeed = 0;
        }
        if (FPcc.itemSpeed == true)
        {
            if (speed > 24f)
            {
                speed = 24f;
            }
            if (speed < -20.5f)
            {
                speed = -20.5f;
            }
        }
        else
        {
            if (speed > 16f)
            {
                speed = 16f;
            }
            if (speed < -13.5f)
            {
                speed = -13.5f;
            }
        }
		if (rotSpeed > 32)
		{
			rotSpeed = 32;
		}
		if (rotSpeed < -32)
		{
			rotSpeed = -32;
		}

        if (Input.GetKey(KeyCode.W) && FPcc.inShip == true && FPcc.move == false) {
            transform.position += ((transform.forward * speed) * Time.deltaTime);
			speed += 6f * Time.deltaTime;
		} 
		else 
		{
			if (speed > 0 && !Input.GetKey(KeyCode.S)) 
			{
				transform.position += ((transform.forward * speed) * Time.deltaTime);
				speed -= 6f * Time.deltaTime;
			}
		}

		if (Input.GetKey(KeyCode.S) && FPcc.inShip == true && FPcc.move == false)
		{
            transform.position -= ((-transform.forward * speed) * Time.deltaTime);
			speed -= 6f * Time.deltaTime;
		}
		else 
		{
			if (speed < 0 && !Input.GetKey(KeyCode.W)) 
			{
                transform.position -= ((-transform.forward * speed)) * Time.deltaTime;
				speed += 6f * Time.deltaTime;
			}
		}


		if (Input.GetKey(KeyCode.A) && FPcc.inShip == true && FPcc.move == false)
		{
			transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
			rotSpeed -= 12 * Time.deltaTime;
		}
		else 
		{
			if (rotSpeed < 0 && !Input.GetKey(KeyCode.D)) 
			{
				transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
				rotSpeed += 10 * Time.deltaTime;
			}
		}

		if (Input.GetKey(KeyCode.D) && FPcc.inShip == true && FPcc.move == false)
		{
			transform.Rotate (0, rotSpeed * Time.deltaTime, 0);
			rotSpeed += 12 * Time.deltaTime;
		}
		else 
		{
			if (rotSpeed > 0 && !Input.GetKey(KeyCode.A)) 
			{
				transform.Rotate (0, rotSpeed * Time.deltaTime, 0);
				rotSpeed -= 10 * Time.deltaTime;
			}
		}
    }
}
