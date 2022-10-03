using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    public Transform Player;


    public float EnemyDistance = 15f;
    public float EnemyDistanceRun = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindWithTag("Shell").transform;
        Player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //противник приходит
        agent.SetDestination(Player.position);
    }

    void RunAway()
    {
        //Противник уходит
        float dis = Vector3.Distance(transform.position, playerTransform.transform.position);
        if (dis < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - playerTransform.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
        }
    }
}
