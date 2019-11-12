using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public override int UpdateNode(Context con)
    {
        for (int i = 0; i < nList.Count; i++)
        {
            int x = nList[i].UpdateNode(con);

            if (curResult == result.Failure)
                return (int)result.Failure;

            if (curResult == result.Running)
                return (int)result.Running;
        }

        return (int)result.Success;
    }
}
