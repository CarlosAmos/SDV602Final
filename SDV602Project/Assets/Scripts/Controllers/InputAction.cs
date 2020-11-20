using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for the input commands
public abstract class InputAction : ScriptableObject
{
    public string keyWord;

    public abstract void RespondToInput(GameController controller, string[] separatedInputWords);
}
