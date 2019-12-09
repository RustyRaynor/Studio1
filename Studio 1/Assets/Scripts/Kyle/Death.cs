using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathN : NodeBT
{
    bool dying;
    public override int UpdateNode(Context context) //Checks if health is 0, if so, then it starts the death process
    {
       
        if (context.health <= 0 && !dying)
        { 
            context.StartCoroutine(DeathProcess(context));
            dying = true;
            return 2;
        }
        else
        {
            return 0;
        }
    }

    IEnumerator DeathProcess(Context context)
    {
        yield return new WaitForSeconds(10.0f);
        context.isDead = true;
    }
}
