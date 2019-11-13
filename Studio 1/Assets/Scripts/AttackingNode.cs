using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingNode : Node
{
    public override int UpdateNode(NewEnemy con)
    {
        Debug.Log("Attacked");
        return 2;
    }
}
