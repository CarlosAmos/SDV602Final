using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OneManStanding/Area")]
public class Areas : ScriptableObject
{
    //used for the rooms.
    [TextArea]
    public string description;
    public string areaName;
    public Exit[] exits;
    public InteractableObject[] interactableObjectsInArea;

}
