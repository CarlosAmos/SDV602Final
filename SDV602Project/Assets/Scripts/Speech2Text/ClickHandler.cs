using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ClickHandler : MonoBehaviour
{
    public GameObject btnTurnMicOn;

    void Update()
    {

    }

    public void TurnMicOn()
    {
        btnTurnMicOn.SetActive(false);

    }

    public void TurnMicOff()
    {
        btnTurnMicOn.SetActive(true);

    }
}
