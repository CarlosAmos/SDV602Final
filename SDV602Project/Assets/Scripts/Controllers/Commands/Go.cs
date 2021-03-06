﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for the Go command
[CreateAssetMenu(menuName = "OneManStanding/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.areaNavigation.AttemptToChangeArea(separatedInputWords[1]);
    }
}
