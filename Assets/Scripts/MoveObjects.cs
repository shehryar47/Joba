using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    // This script is on Camera


    
    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);   
                Debug.Log(hit.transform.name); 
                //hit.transform.position=new Vector3(hit.transform.position.x,Input.mousePosition.y,hit.transform.position.z);
            }
        } 
    }


    
}
