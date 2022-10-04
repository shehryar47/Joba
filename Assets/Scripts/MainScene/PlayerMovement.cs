using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] GameObject dialCam;
    [SerializeField] GameObject currentCam;
    NavMeshAgent agent;
    public GameObject guard;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
        if (guard != null && Vector3.Distance(transform.position, guard.transform.position) < 4f)
        {
            //playerCam.gameObject.SetActive(false);
            dialCam.SetActive(true);
        }
    }

    private void CastRay()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                if (hit.transform.name == ("Guard"))
                {
                    guard = hit.transform.gameObject;
                    agent.stoppingDistance = 3f;
                }
                else
                {
                    agent.stoppingDistance = 0f;

                }
            }
        }
    }
}
