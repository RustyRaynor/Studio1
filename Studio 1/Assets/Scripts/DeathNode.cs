using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathNode : Node
{
    public override int UpdateNode(EnemyAbstract con)
    {
        {
            if (con.dead == false)
            {
                con.anim.SetTrigger("dead");
                con.dead = true;
            }
           return 2;
        }
    }
}
