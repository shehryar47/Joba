using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    [SerializeField] GameObject playerSlate;
    public void ShowSlate()
    {
        playerSlate.SetActive(true);
    }

    public void ProveIdentity()
    {
        GetComponent<PlayerMovement>().agent.enabled = true;
        GetComponent<PlayerMovement>().dialCam.SetActive(false);
    }
}
