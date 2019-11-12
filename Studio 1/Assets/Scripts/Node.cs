using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public enum result { failure, Running, Success };

    public List<Node> list = new List<Node>();

    public virtual int UpdateBehavior(Enemy context)
    {
        return (int)result.failure;
    }
}
