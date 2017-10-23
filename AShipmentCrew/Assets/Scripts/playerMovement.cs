using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {
    public bool shipArea;
    public bool inShip;
    public bool wall;
    public bool islandArea;
    public bool spawnArea;
    public float money;
    public float health;
    public bool move;
    public bool gameOver;
    public bool pause;
    public bool itemSpeed;
    public bool invincible;
    public float invincibleTimer;
    public float knockback;
    public float knockbackSave;
    public bool hit;
    public int healthDisplay;
    public int knockbackDir;
    public bool dirLock;

    private float invincibleSave;

    public Transform ship;
    public Transform playerShipSpawn;
    public GameObject canon;
    public GameObject pauseCam;
    public GameObject mainCam;
    public cameraMovement cM;
    public Quaternion rotSave;
    public Text moneyVar;
    public Text healthVar;
    public Text pauseTxt;
    public Text gameOverTxt;
    public Text enterShipTxt;
    public cameraFunctions camFun;
    public AudioClip coinSound;
    public AudioClip hitSound;
    public GameObject flagUp;
    public shopScript shopScr;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

    GameObject currSpawnpoint;
    void Start () {
        FindObjectOfType<AudioManager>().Play("OceanSound");
        invincibleSave = invincibleTimer;
        health = 100;
        move = true;
        knockbackSave = knockback;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "island")
        {
            islandArea = true;
            if (inShip == false)
            {
                cM.shipCam = false;
            }
        }
        if (other.gameObject.tag == "spawnpoint")
        {
            currSpawnpoint = other.gameObject;
            Instantiate(flagUp, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), Quaternion.identity);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "spawn1")
        {
            spawnArea = true;
        }
        if (other.gameObject.tag == "money")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = coinSound;
            audio.Play();
            money = money + 25;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "enemy")
        {
            if (invincible == false)
            {
                health = health - 25;
                invincible = true;
                invincibleTimer = invincibleSave;
                Hit();
            }
        }
        if (other.gameObject.tag == "turretCube")
        {
            if (invincible == false)
            {
                health = health - 20;
                invincible = true;
                invincibleTimer = invincibleSave;
                Hit();
            }
        }
        if (other.gameObject.tag == "ship")
        {
            shipArea = true;
        }
        if (other.gameObject.tag == "canonItem")
        {
            if (money > 499)
            {
                money = money - 500;
                Destroy(other.gameObject);
                canon.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ship")
        {
            shipArea = false;
        }
        if (other.gameObject.tag == "island")
        {
            cM.shipCam = false;
        }
        if (other.gameObject.tag == "spawn1")
        {
            spawnArea = false;
        }
    }

    void Hit()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.clip = hitSound;
        audio.Play();
        if (knockbackDir == 0)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 1000);
        }
        if (knockbackDir == 1)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }
        if (knockbackDir == 2)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right * 1000);
        }
        if (knockbackDir == 3)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.right * 1000);
        }
        hit = true;
    }

    void HitEnd()
    {
        if (knockbackDir == 0)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }
        if (knockbackDir == 1)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 1000);
        }
        if (knockbackDir == 2)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.right * 1000);
        }
        if (knockbackDir == 3)
        {
            dirLock = true;
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right * 1000);
        }
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void GameOver()
    {
        move = false;
        camFun.TurnBlurOn();
        gameOver = true;
        gameOverTxt.gameObject.SetActive(true);
    }

    void PauseStart()
    {
        Debug.Log("PAUSE ON");
        move = false;
        pauseCam.SetActive(true);
        mainCam.SetActive(false);
        Time.timeScale = 0;
        pauseTxt.gameObject.SetActive(true);
    }

    void PauseStop()
    {
        Debug.Log("PAUSE OFF");
        pauseCam.SetActive(false);
        mainCam.SetActive(true);
        Time.timeScale = 1;
        move = true;
        pauseTxt.gameObject.SetActive(false);
    }

    void Update () {
        healthDisplay = Mathf.RoundToInt(health);
        moneyVar.text = "Money: " + money;
        healthVar.text = "Health: " + healthDisplay;

        if (shipArea == true)
        {
            enterShipTxt.gameObject.SetActive(true);
        }
        else
        {
            enterShipTxt.gameObject.SetActive(false);
        }

        if (inShip == true)
        {
            enterShipTxt.gameObject.SetActive(false);
            BoxCollider boxCol = gameObject.GetComponent<BoxCollider>();
            boxCol.enabled = false;
            if (health < 100)
            {
                health += 2 * Time.deltaTime;
            }
        }
        else
        {
            BoxCollider boxCol = gameObject.GetComponent<BoxCollider>();
            boxCol.enabled = true;
        }

        if (hit == true)
        {
            knockback -= Time.deltaTime;
        }

        if (knockback < 0)
        {
            hit = false;
            HitEnd();
            knockback = knockbackSave;
            dirLock = false;
        }
        invincibleTimer -= Time.deltaTime;

        if (invincible == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        if (invincibleTimer < 0)
        {
            invincibleTimer = 0;
            invincible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && shopScr.inShop == false)
        {
            if (pause == false)
            {
                pause = true;
                PauseStart();
            }
            else
            {
                pause = false;
                PauseStop();
            }
        }

        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                health = 100;
                gameOver = false;
                camFun.TurnBlurOff();
                move = true;
                gameOverTxt.gameObject.SetActive(false);
                exitShip();
                if (currSpawnpoint != null)
                {
                    transform.position = currSpawnpoint.transform.position;
                }
            }
        }

        if (health < 1)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (move == true)
            {
                if (inShip == false)
                {
                    if (shipArea == true)
                    {
                        enterShip();
                    }
                }
                else
                {
                    exitShip();
                }
            }
        }
    }

    void enterShip()
    {
        if (ship != null)
        {
            transform.position = playerShipSpawn.transform.position;
            transform.parent = ship.transform;
            cM.shipCam = true;
            inShip = true;
            fps.move = false;
        }
    }

    public void exitShip()
    {
        transform.parent = null;
        cM.shipCam = false;
        inShip = false;
        transform.position = ship.transform.position + new Vector3(10, 0.85f, 0);
        fps.move = true;
    }
}
