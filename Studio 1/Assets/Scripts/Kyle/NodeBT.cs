using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeBT
{
    public int result;

    public List<NodeBT> nodeList = new List<NodeBT>();

    public virtual int UpdateNode(Context context)
    {
        return 0;
    }
}
