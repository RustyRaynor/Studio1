using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
   // public enum result
   // {
   //     Failure,
   //     Running,
   //     Success
   // }

    public int state;

    float Max_See_Ahead = 5f;

   // public result curResult;

    public List<Node> nList = new List<Node>();

    public virtual int UpdateNode(EnemyAbstract con)
    {
        return 0;
    }
}