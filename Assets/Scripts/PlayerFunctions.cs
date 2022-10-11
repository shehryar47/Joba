using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    [SerializeField] GameObject playerSlate;
    public TextMeshProUGUI objectives;
    public GameObject Welcome;
    public GameObject Arrow;
    public GameObject InnCamera;
    public void ShowSlate()
    {
        playerSlate.SetActive(true);
        objectives.text = "Show Slate";
    }

    public void IdentityProved()
    {
        
        //GetComponent<PlayerMovement>().agent.enabled = true;
        GetComponent<PlayerMovement>().dialCam.SetActive(false);
        //GetComponent<PlayerMovement>().DialSystem.SetActive(true);
       
        objectives.text = "Go Inside Inn";
        GetComponent<PlayerInput>().enabled = true;
        // Welcome.GetComponent<DialogueTrigger>().TriggerDialogue();
        Invoke("InnCutScene", 3f);
    }
    void InnCutScene()
    {
        InnCamera.SetActive(true);
        Invoke("ArrowOn", 1.5f);
    }

    void ArrowOn()
    {
        Arrow.SetActive(true);
    }
}
