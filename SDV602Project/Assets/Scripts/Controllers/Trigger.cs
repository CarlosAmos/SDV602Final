using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Text MinigameScore;
    public Text MinigameStatus;

    public string befscore;
    public int aftscore;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameOver");
        MinigameStatus.text = "Game Over";
    }
}
