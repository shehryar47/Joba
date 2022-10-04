using UnityEngine;
using UnityEngine.AI;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] public GameObject dialCam;
    [SerializeField] GameObject currentCam;
    [SerializeField] public GameObject DialSystem;
    [SerializeField] GameObject DialManager;
    public bool dialogueStarted;
    public bool dialogueFinished;
    NavMeshAgent agent;
    GameObject guard;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
        CheckGuard();

    }

    private void CheckGuard()
    {

        if (guard != null && Vector3.Distance(transform.position, guard.transform.position) < 4f)
        {
            if (!dialogueStarted&&!dialogueFinished)
            {

                StartDialogue();
                dialogueStarted = true;
            }
        }
    }

    private void StartDialogue()
    {
        dialCam.SetActive(true);
        DialSystem.SetActive(true);
        guard.GetComponent<DialogueTrigger>().TriggerDialogue();
        //agent.enabled = false;
        //DialManager.GetComponent<DialogueManager>().DisplayNextSentence();
    }

    private void CastRay()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)&& !dialogueStarted)
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
