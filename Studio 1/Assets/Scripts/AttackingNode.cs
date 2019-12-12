using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingNode : Node
{

    public override int UpdateNode(EnemyAbstract con)
    {
        if (Time.time - con.lastAttack >= con.attackRate)
        {
            PlayerHealth health = con.player.GetComponent<PlayerHealth>();
            con.lastAttack = Time.time;
            con.anim.SetBool("walking", false);
            con.anim.SetTrigger("attack");
            Debug.Log("Attacked");
            return 2;
        }
        return 1;
    }
}
