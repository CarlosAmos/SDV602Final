using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used for minigame gameover trigger
public class Trigger : MonoBehaviour
{
    public Text MinigameScore;
    public Text MinigameStatus;

    public string befscore;
    public int aftscore;

    //used to say game over when sphere enters trigger zone
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameOver");
        MinigameStatus.text = "Game Over";
    }
}
