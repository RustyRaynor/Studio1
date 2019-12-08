using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathN : NodeBT
{
    bool dead = false;

    public override int UpdateNode(Context context)
    {
        if (context.health <= 0)
        {
            context.StartCoroutine(DeathProcess());

            if(dead)
            {
                context.isDead = true;
            }
        }
        return 2;
    }

    IEnumerator DeathProcess()
    {
        yield return new WaitForSeconds(10.0f);
        dead = true;
    }
}
