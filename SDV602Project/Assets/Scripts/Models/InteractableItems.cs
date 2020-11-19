using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{

    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    List<string> nounsInInventory = new List<string>();

    public string GetObjectsNotInInventory(Areas currentArea, int i)
    {
        InteractableObject interactableInArea = currentArea.interactableObjectsInArea[i];

        if(!nounsInInventory.Contains(interactableInArea.noun))
        {
            nounsInRoom.Add(interactableInArea.noun);
            return interactableInArea.description;
        }

        return null;
    }

}
