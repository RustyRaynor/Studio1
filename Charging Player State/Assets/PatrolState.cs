using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    int position = 0;
    public override void UpdateState(Player context)
    {
        context.transform.position = Vector3.MoveTowards(context.transform.position, context.patrolPosition[position], 0.2f);

        if(context.transform.position == context.patrolPosition[position])
        {
            position++;
            if(position == context.patrolPosition.Length)
            {
                position = 0;
            }
        }
     

        
        context.battery--;
        if (context.battery == 0)
        {
            context.setState(new GoToCharge());
        }
    }
}
