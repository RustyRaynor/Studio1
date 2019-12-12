using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNode : NodeBT
{
    public int position = 0;

    public override int UpdateNode(Context context)
    {
        //Debug.Log("Patrolling");
        //context.Seek(context.positions[currentDes]);
        //context.transform.LookAt(context.positions[currentDes]);
        //context.anim.SetBool("isWalking", true);

        Vector3 distance = context.patrolPosition[position] - context.transform.position;
        Vector3 distanceLeft = distance.normalized;

        if (distance.magnitude <= distanceLeft.magnitude)
        {
            context.anim.SetBool("walking", false);
            if (Time.time - context.waitTime >= context.waitTimeR)
            {
                position++;
                if (position == context.patrolPosition.Length)
                {
                    position = 0;
                }
            }
        }
        else
        {
            context.anim.SetBool("isWalking", true);
            context.Seek(context.patrolPosition[position]);
            context.waitTime = Time.time;
            context.transform.LookAt(context.patrolPosition[position]);
        }
        return 1;  
    }
}
