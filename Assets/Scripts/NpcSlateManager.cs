using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcSlateManager : MonoBehaviour
{
    [SerializeField] GameObject canvasSlate;
    [SerializeField] GameObject recordBook;
    [SerializeField] GameObject recordNamePrefab;
    public GameObject npc;
    [SerializeField] List<GameObject> recordList = new List<GameObject> ();
    [SerializeField] GameObject guestBtn;
    private void Start()
    {
        for (int i = 0; i < recordBook.transform.childCount; i++)
        {
            recordList.Add(recordBook.transform.GetChild(i).gameObject);
            recordBook.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPCGuest"))
        {
            npc=other.gameObject;
            NPC guest = other.GetComponent<NPC>(); 
            canvasSlate = guest.slate;
            canvasSlate.SetActive(true);
            canvasSlate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = guest._name;
            canvasSlate.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = guest.roomType.ToString();
           // other.gameObject.transform.Rotate(0f, -130f, 0f);
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPCGuest"))
        {
            other.gameObject.transform.GetChild(1).Rotate(0f, 0f, 0f);
            guestBtn.SetActive(true); 
        }
    }


}

