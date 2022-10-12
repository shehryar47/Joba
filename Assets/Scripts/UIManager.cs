using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
  public GameObject CounterCam,QuestSuccessPanel,ControlCanvas,COUNTER,PLayer;

    private void Start()
    {
        Instance = this;    
    }
    public void CloseQuest1()
    {
        CounterCam.SetActive(false);
        QuestSuccessPanel.SetActive(false);
        ControlCanvas.SetActive(true);
        COUNTER.GetComponent<Collider>().enabled = false;
        COUNTER.GetComponent<Outline>().OutlineWidth = 0f;
        PLayer.SetActive(true);

    }
}
