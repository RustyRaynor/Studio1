﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueN : NodeBT
{
    public override int UpdateNode(Context context) //Starts pursuing the player when player is within a certain distance
    {
        float distance = Vector3.Distance(context.player.transform.position, context.transform.position);

        if (distance > 2.5f)
        {
            context.Pursue(context.player.transform.position);
            return 1;
        }
        return 2;
    }
}
