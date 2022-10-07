using TMPro;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    [SerializeField] GameObject playerSlate;
    public TextMeshProUGUI objectives;
    public GameObject Welcome;
    public void ShowSlate()
    {
        playerSlate.SetActive(true);
        objectives.text = "Show Slate";
    }

    public void IdentityProved()
    {
        
        GetComponent<PlayerMovement>().agent.enabled = true;
        GetComponent<PlayerMovement>().dialCam.SetActive(false);
        //GetComponent<PlayerMovement>().DialSystem.SetActive(true);
       
        objectives.text = "Go Inside Inn";
       // Welcome.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
