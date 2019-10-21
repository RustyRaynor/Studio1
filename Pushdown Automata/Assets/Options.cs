using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : State
{
    public override void UpdateState(Main context)
    {
        context.mainMenu.SetActive(false);
        context.pauseMenu.SetActive(false);
        context.options.SetActive(true);
        context.help.SetActive(false);
        context.game.SetActive(false);
    }
}
