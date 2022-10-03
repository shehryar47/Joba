using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePopUp : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    private void OnMouseDown()
    {
        Debug.Log("kdsjfak");
    }
    private void OnMouseDrag()
    {
        transform.position = Input.mousePosition;
    }
}

