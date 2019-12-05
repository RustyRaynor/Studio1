using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorN : NodeBT
{
    public override int UpdateNode(Context context)
    {
        for (int i = 0; i < nodeList.Count; i++)
        {
            int result = nodeList[i].UpdateNode(context);

            if (result == 1)
                return 1;

            if (result == 2)
                return 2;
        }

        return 0;
    }
}
