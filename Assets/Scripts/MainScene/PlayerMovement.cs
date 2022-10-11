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
    public NavMeshAgent agent;
    public GameObject guard;
    public Animator animator;
    public Vector3 dest;
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
       // animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // CastRay();
       /* if (dest != null && Vector3.Distance(transform.position, dest) < 0.2f)
        {
            animator.SetBool("Walk", false);

        }
        else
        {

            animator.SetBool("Walk", true);
        }*/
        CheckGuard();

    }

    private void CheckGuard()
    {

        if (guard != null && Vector3.Distance(transform.position, guard.transform.position) < 4f)
        {
            if (!dialogueStarted && !dialogueFinished)
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
        GetComponent<PlayerInput>().anim.SetBool("Walk", false); 
        GetComponent<PlayerInput>().enabled = false;
        guard.GetComponent<DialogueTrigger>().TriggerDialogue();

    }

    private void CastRay()
    {
        if (Input.GetMouseButton(0) && agent.enabled)
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && !dialogueStarted)
            {
                agent.SetDestination(hit.point);
                dest = hit.point;
                CheckForGuard(hit);
            }
        }
    }

    private void CheckForGuard(RaycastHit hit)
    {
        if (hit.transform.name == ("Guard"))
        {
            guard = hit.transform.gameObject;
            agent.stoppingDistance = 3f;
            animator.SetBool("Walk", false);
        }
        else
        {
            //agent.stoppingDistance = 0f;

        }
    }
}
