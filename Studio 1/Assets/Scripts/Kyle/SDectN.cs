using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDectN : NodeBT
{
    public override int UpdateNode(Context context)
    {
        if (context.playerDetected == true)
        {
            if (context.playerCode.soundMade >= 5)
            {
                context.Seek(context.player.transform.position);
                return 2;
            }
        }
        return 0;
    }
}
