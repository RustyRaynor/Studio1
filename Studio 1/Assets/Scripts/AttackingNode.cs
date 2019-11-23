using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingNode : Node
{
    float lastAttack;
    public override int UpdateNode(EnemyAbstract con)
    {
        if (Time.time - lastAttack > lastAttack)
        {
            lastAttack = Time.time;
            con.anim.SetTrigger("attack");
            Debug.Log("Attacked");
            return 2;
        }
        return 1;
    }
}
