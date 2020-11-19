using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OneManStanding/InputActions/Use")]
public class Use : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.areaNavigation.AttemptToChangeArea(separatedInputWords[1]);
    }
}
