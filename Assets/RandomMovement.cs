using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public Transform[] randomPos;
    NavMeshAgent agent;
    int randomPoint;
    
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        randomPoint = Random.Range(0, randomPos.Length);
        agent.SetDestination(randomPos[randomPoint].position);
        transform.GetChild(1).GetChild(Random.Range(0, transform.GetChild(1).childCount)).gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, randomPos[randomPoint].position) < 0.5f)
        {
            randomPoint = Random.Range(0, randomPos.Length);
            agent.SetDestination(randomPos[randomPoint].position);
        }      
    }

    
}
