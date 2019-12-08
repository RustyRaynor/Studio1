using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathNode : Node
{
    bool dead = true;
    public override int UpdateNode(EnemyAbstract con)
    {
        { 
           con.anim.SetTrigger("Dead");
           con.dead = true;
           return 2;
        }
    }
}
