using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GuestScript : MonoBehaviour
{
    public GameObject PositionA;
    public GameObject PositionB;
    public float speed;
    public bool DestA;
    public bool DestB;

    // Start is called before the first frame update
    void Start()
    {
        DestA = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(DestA)
        {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PositionA.transform.position, step);
            if (Vector3.Distance(transform.position, PositionA.transform.position) < 0.1f)
            {
                DestA = false;

            }

        }
        if(DestB)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, PositionB.transform.position, step);
            gameObject.transform.Rotate(0, 70f, 0);
            if (Vector3.Distance(transform.position,PositionB.transform.position) < 1f)
            {
                gameObject.SetActive(false);
                DestB = false;
            }
        }
        
    }
}
