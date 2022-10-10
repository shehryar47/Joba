using System.Collections.Generic;
using UnityEngine;

public class TavernMiniGameManager : MonoBehaviour
{
    public GameObject CounterCam,CounterCanvas,ControlCanvas,TableCanvas,GuestSpanwer;
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Outline>().OutlineWidth = 10f;
            CounterCam.SetActive(true);
           CounterCanvas.SetActive(true);
          //  TableCanvas.SetActive(true);
            GuestSpanwer.SetActive(true);
            other.gameObject.SetActive(false);
            ControlCanvas.SetActive(false);

        }
    }
    private void OnTriggerExit(Collider other)
    {
     
        gameObject.GetComponent<Outline>().OutlineWidth = 0f;

    }


}
