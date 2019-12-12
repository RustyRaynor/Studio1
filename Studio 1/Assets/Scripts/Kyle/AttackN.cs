using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackN : NodeBT
{
    public GameObject player;
    PlayerHealth playerH;
    float attackTime;
    bool attacking;
    bool attack;

    public override int UpdateNode(Context context)
    {
        playerH = context.player.GetComponent<PlayerHealth>();

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
            context.StartCoroutine(attackE(context));    
            return 2;
        }
        return 1;
    }

    IEnumerator attackE(Context context)
    {
        if (!attacking)
        {
            attacking = true;
            Debug.Log("Attacking");
            context.anim.SetTrigger("isAttacking");
            playerH.health -= context.damage;
            yield return new WaitForSeconds(2.0f);
            attacking = false;
        }
    }
}
