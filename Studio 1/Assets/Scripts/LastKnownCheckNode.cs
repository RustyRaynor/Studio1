using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastKnownCheckNode : Node
{
    public override int UpdateNode(EnemyAbstract con)
    {
        if (con.lastKnown == true)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }
}
