using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    // This Script is placed on all NPCs only

    [SerializeField] Transform table;
    [SerializeField] public GameObject keyImage;
    [SerializeField] public GameObject slate;
    [SerializeField] public GameObject recordBook;
    [SerializeField] GameObject keyPrefab;
    [SerializeField] Transform keyTransform;
    public GameObject butler;
    [SerializeField] GameObject callNextGuestBtn;
    public enum RoomType { Classic, Lower, Luxury, Suite };
    private Button registerNameBtn;
    [SerializeField] public int id = 0;
    NavMeshAgent agent;
    public string _name;
    public RoomType roomType;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(table.position);  
        slate = transform.GetChild(0).GetChild(0).gameObject;
        registerNameBtn = slate.GetComponentInChildren<Button>();
        keyImage = slate.transform.GetChild(3).gameObject;
        registerNameBtn.onClick.AddListener(delegate { RegisterNameOnRecordBook(id); });

    }

    public void RegisterNameOnRecordBook(int id)
    {
        recordBook.transform.GetChild(id).gameObject.SetActive(true);
        recordBook.transform.GetChild(id).GetComponent<TextMeshProUGUI>().text = _name;
        registerNameBtn.onClick.RemoveListener(delegate { RegisterNameOnRecordBook(id); });
        registerNameBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Give Key";
        registerNameBtn.onClick.AddListener(delegate { GiveKey(); });
       
    }

    public void GiveKey()
    {
        var key = Instantiate(keyPrefab, keyTransform.position, Quaternion.identity);
        key.GetComponent<GiveKey>().target = this.transform;
        registerNameBtn.onClick.RemoveAllListeners();
        registerNameBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Call Butler";
        registerNameBtn.onClick.AddListener(delegate { CallButler(); });
        gameObject.transform.Rotate(0, 0, 0);
    }

    public void CallButler()
    {

        butler.SetActive(true);
        //butler.GetComponent<ButlerScript>().agent.SetDestination(this.transform.position);
        agent.SetDestination(butler.transform.position);
        callNextGuestBtn.SetActive(true);
        slate.SetActive(false);
        registerNameBtn.onClick.RemoveAllListeners();
        Invoke("Stop", 3f);
    }

    void Stop()
    {
        gameObject.SetActive(false);
    }
}
