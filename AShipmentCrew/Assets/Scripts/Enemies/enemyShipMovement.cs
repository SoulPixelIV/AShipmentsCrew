using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyShipMovement : MonoBehaviour {
    public int currTarget;
    public float distPlayer;
    public bool chasing;
    public int health;
    public bool dead;

    public Transform[] WayPoints;
    public Transform player;
    public FPCharacterController FPcc;
    NavMeshAgent agent;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cannonball")
        {
            health -= 10;
        }
    }

    void Start()
    {
        chasing = false;
        agent = GetComponent<NavMeshAgent>();
        health = 100;
    }
    void Update()
    {
        float distWay = Vector3.Distance(transform.position, WayPoints[currTarget].position);
        distPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (health < 1)
        {
            dead = true;
            Destroy(gameObject);
        }
        if (chasing == false)
        {
            agent.SetDestination(WayPoints[currTarget].position);
        }
        if (distWay < 5 && dead == false)
        {
            if (currTarget == WayPoints.Length - 1)
            {
                currTarget = 0;
            }
            else
            {
                currTarget = currTarget + 1;
            }
        }
        if (distPlayer < 50 && dead == false)
        {
            chasing = true;
            if (distPlayer > 15)
            {
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
            }
            if (distPlayer < 15)
            {
                agent.isStopped = true;
            }
        }
        else
        {
            chasing = false;
        }
    }
}
