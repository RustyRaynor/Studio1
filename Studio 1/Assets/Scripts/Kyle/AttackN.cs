using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackN : NodeBT
{
    public GameObject player;
    float attackTime;
    bool attacking;
    bool attack;

    

    public override int UpdateNode(Context context)
    {
        float distance = Vector3.Distance(context.player.transform.position, context.transform.position);

        if (distance <= 1.0f)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack)
        {
            context.StartCoroutine(attackE());
            return 2;
        }
        return 1;
    }

    IEnumerator attackE()
    {
        if (!attacking)
        {
            attacking = true;
            Debug.Log("Attacking");
            //anim.setTrigger("Attack");
            yield return new WaitForSeconds(1.5f);
            attacking = false;
        }
    }
}
