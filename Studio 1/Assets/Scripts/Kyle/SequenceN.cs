using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceN : NodeBT
{
    public override int UpdateNode(Context context)
    {
        for (int i = 0; i < nodeList.Count; i++)
        {
            int result = nodeList[i].UpdateNode(context);

            if (result == 0)
                return 0;

            if (result == 1)
                return 1;
        }

        return 2;
    }
}
