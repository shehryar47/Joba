using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject CutCamera;
    private void OnEnable()
    {

        Invoke("SetOff", 2f);
    }

    void SetOff()
    {
        gameObject.SetActive(false);
        CutCamera.SetActive(false);
    }
}
