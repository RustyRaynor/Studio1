﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    public override void UpdateState(Main context)
    {
        context.mainMenu.SetActive(false);
        context.pauseMenu.SetActive(false);
        context.options.SetActive(false);
        context.help.SetActive(false);
        context.game.SetActive(true);
    }
}
