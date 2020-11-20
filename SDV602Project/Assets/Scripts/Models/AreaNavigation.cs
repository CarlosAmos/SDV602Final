using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AreaNavigation : MonoBehaviour
{
    public Areas currentArea;
    public Text DisplayAreaName;
    public Text Status;

    Dictionary<string, Areas> exitDictionary = new Dictionary<string, Areas>();
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    void Update()
    {
        DisplayAreaName.text = currentArea.areaName;
    }

    //This would get all the exits in the room and display them in the display text
    public void UnpackExitsInArea()
    {
        for (int i = 0; i < currentArea.exits.Length; i++)
        {
            exitDictionary.Add(currentArea.exits[i].keyString, currentArea.exits[i].valueArea);
            controller.interactionDescriptionsInArea.Add(currentArea.exits[i].exitDescription);
        }
    }

    //used when the user enters a command into textbox
    public void AttemptToChangeArea(string directionNoun)
    {
        if(exitDictionary.ContainsKey(directionNoun))
        {
            // Used if the user uses the command Wake
            if(directionNoun == "yourself")
            {
                currentArea = exitDictionary[directionNoun];
                controller.LogStringWithReturn("You wake" + " " + directionNoun);
                controller.DisplayAreaText();
            }
            // Used if the user uses the command Go
            else
            {
                currentArea = exitDictionary[directionNoun];
                controller.LogStringWithReturn("You go" + " " + directionNoun);
                controller.DisplayAreaText();
            }
        }
        //This is used for when the command is not recognised
        else
        {
            controller.LogStringWithReturn("I don't think I can do that");
        }
    }

    //This would clear the stored exits of the previous room
    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
