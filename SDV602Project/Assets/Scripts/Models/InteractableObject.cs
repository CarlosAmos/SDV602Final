using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OneManStanding/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    //Used for creating an interactable object
    public string noun = "name";
    [TextArea]
    public string description = "Description in area";
}
