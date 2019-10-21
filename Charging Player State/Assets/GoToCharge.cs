using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCharge : State
{
    public override void UpdateState(Player context)
    {
        context.transform.position = Vector3.MoveTowards(context.transform.position, context.chargingPosition, 0.2f);
        if (context.transform.position == context.chargingPosition)
        {
            context.setState(new Charging());
        }
    }
}
