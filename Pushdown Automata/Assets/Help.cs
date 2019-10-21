using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : State
{
    public override void UpdateState(Main context)
    {
        context.mainMenu.SetActive(false);
        context.pauseMenu.SetActive(false);
        context.options.SetActive(false);
        context.help.SetActive(true);
        context.game.SetActive(false);
    }
}
