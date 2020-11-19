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


    public void UnpackExitsInArea()
    {
        for (int i = 0; i < currentArea.exits.Length; i++)
        {
            exitDictionary.Add(currentArea.exits[i].keyString, currentArea.exits[i].valueArea);
            controller.interactionDescriptionsInArea.Add(currentArea.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeArea(string directionNoun)
    {
        


        if(exitDictionary.ContainsKey(directionNoun))
        {
            if(directionNoun == "yourself")
            {
                currentArea = exitDictionary[directionNoun];
                controller.LogStringWithReturn("You wake" + " " + directionNoun);
                controller.DisplayAreaText();
            }
            else
            {
                currentArea = exitDictionary[directionNoun];
                controller.LogStringWithReturn("You go" + " " + directionNoun);
                controller.DisplayAreaText();
            }
        }
        else
        {
            controller.LogStringWithReturn("I don't think I can do that");
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
