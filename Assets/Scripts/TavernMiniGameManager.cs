using System.Collections.Generic;
using UnityEngine;

public class TavernMiniGameManager : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
       
        
            gameObject.GetComponent<Outline>().OutlineWidth = 10f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
     
        gameObject.GetComponent<Outline>().OutlineWidth = 0f;
    }


}
