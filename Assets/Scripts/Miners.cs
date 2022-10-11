using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Miners : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform dest;
    public Animator anim;
    public GameObject levelPassPanel;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, dest.position) < 1f)
        {
            gameObject.SetActive(false);
            levelPassPanel.SetActive(true);
            player.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Recover", true);
            Invoke("SetDest", 6f);
        }

    }
    void SetDest()
    {

        agent.SetDestination(dest.position);
    }
}
