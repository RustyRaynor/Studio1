using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueN : NodeBT
{
    public override int UpdateNode(Context context) //Starts pursuing the player when player is within a certain distance
    {
        float distance = Vector3.Distance(context.player.transform.position, context.transform.position);

        if (distance > context.enemyR)
        {
            context.Pursue(context.player.transform.position);
            context.transform.LookAt(context.player.transform.position);
            Debug.Log("Chasing");
            return 1;
        }
        return 2;
    }
}
