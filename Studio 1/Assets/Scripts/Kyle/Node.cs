using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public enum result
    {
        Failure,
        Running,
        Success
    }

    public result curResult;

    public List<Node> nList = new List<Node>();

    public virtual int UpdateNode(Context con)
    {
        return 0;
    }

    public void AddNodes(Node node)
    {
        nList.Add(node);
    }
}