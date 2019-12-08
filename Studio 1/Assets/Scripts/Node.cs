using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public int state;

    float Max_See_Ahead = 5f;


    public List<Node> nList = new List<Node>();

    public virtual int UpdateNode(EnemyAbstract con)
    {
        return 0;
    }
}