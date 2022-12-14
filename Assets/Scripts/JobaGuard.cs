using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobaGuard : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    
    private void OnMouseOver()
    {
        GetComponentInChildren<Renderer>().material.color = Color.red;
    }
    private void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material.color = Color.white; 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().guard = this.gameObject;
        }
    }
}
