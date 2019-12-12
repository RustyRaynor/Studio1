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
            PlayerHealth health = con.player.GetComponent<PlayerHealth>();
            lastAttack = Time.time;
            con.anim.SetTrigger("attack");
            Debug.Log("Attacked");
            Debug.Log(health.health);
            
            Debug.Log(health.health);
            return 2;
        }
        return 1;
    }
}
