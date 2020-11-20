using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ClickHandler : MonoBehaviour
{
    public GameObject btnTurnMicOn;
    //Handles the mic buttons on the screen

    void Update()
    {

    }

    //Button used to start recording
    public void TurnMicOn()
    {
        btnTurnMicOn.SetActive(false);

    }
    //Button used to stop recording
    public void TurnMicOff()
    {
        btnTurnMicOn.SetActive(true);

    }
}
