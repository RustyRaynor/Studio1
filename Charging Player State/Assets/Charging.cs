using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charging : State
{
    public override void UpdateState(Player context)
    {
        context.battery++;
        if (context.battery == 500)
        {
            context.setState(new PatrolState());
        }
    }
}
