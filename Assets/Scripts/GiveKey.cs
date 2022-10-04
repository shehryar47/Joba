using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveKey : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    // Update is called once per frame
    void Update()
    {   if(target != null)
        {
            transform.position= Vector3.MoveTowards(transform.position, target.position, 3f*Time.deltaTime );
            if (Vector2.Distance(transform.position, target.position) < 1f)
            {
                target.GetComponentInParent<NPC>().keyImage.SetActive(true);
                gameObject.SetActive(false);
                Destroy(gameObject, 2f);
            }
        }

       
    }
}
