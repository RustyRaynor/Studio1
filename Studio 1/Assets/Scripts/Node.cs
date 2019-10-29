using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public int state;

    public List<Node> list = new List<Node>();

    public virtual int UpdateBehavior(Enemy context)
    {
        return 0;
    }
}
