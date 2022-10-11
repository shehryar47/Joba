using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestSpawner : MonoBehaviour
{

    public GameObject guestPrefab;
    public int count;
    public GameObject gameFullPanel;
    

    public void SpawnGuest()
    {
        if(count <5)
        {

        count++;
        guestPrefab.transform.GetChild(count).gameObject.SetActive(true);
        var guest = guestPrefab.transform.GetChild(count).gameObject;
        guest.transform.GetChild(1).GetChild(Random.Range(0, guest.transform.GetChild(1).childCount)).gameObject.SetActive(true);
        }
        else
        {
            gameFullPanel.SetActive(true);
        }
    }
}
