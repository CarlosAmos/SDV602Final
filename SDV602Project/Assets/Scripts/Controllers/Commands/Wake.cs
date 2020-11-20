using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for the wake command
[CreateAssetMenu(menuName = "OneManStanding/InputActions/Wake")]
public class Wake : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.areaNavigation.AttemptToChangeArea(separatedInputWords[1]);
    }
}
