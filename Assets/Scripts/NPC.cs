using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    // This Script is placed on all NPCs only

    [SerializeField] Transform table;
    [SerializeField] public GameObject slate;
    [SerializeField] public GameObject recordBook;
    public enum RoomType { Classic, Lower, Luxury, Suite };
    private Button registerNameBtn;
    [SerializeField] int id;
    NavMeshAgent agent;
    public string _name;
    public RoomType roomType;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(table.position);
        slate = transform.GetChild(0).GetChild(0).gameObject;
        registerNameBtn=slate.GetComponentInChildren<Button>();
        registerNameBtn.onClick.AddListener(delegate{RegisterNameOnRecordBook(this.id);});

    }
    
    public void RegisterNameOnRecordBook(int id)
    {
        recordBook.transform.GetChild(id).gameObject.SetActive(true);
        recordBook.transform.GetChild(id).GetComponent<TextMeshProUGUI>().text = _name;
        registerNameBtn.onClick.RemoveListener(delegate{RegisterNameOnRecordBook(this.id); });
        registerNameBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Give Key";
        registerNameBtn.onClick.AddListener(delegate{ GiveKey();});
       
    }

    public void GiveKey()
    {
        Debug.Log("Key Received");
        registerNameBtn.onClick.RemoveAllListeners();
    }
}
