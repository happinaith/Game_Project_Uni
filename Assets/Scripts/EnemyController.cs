using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Player thePlayer;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        thePlayer = FindObjectOfType<Player>();
        agent.speed = UnityEngine.Random.Range(10f, 30f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
        agent.destination = thePlayer.transform.position;
    }
}
