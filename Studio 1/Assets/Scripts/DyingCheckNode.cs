using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingCheckNode : Node
{
    public override int UpdateNode(EnemyAbstract con)
    {
        if (con.health <= 0)
        {
            return 2;
        }
        return 0;
    }
}
