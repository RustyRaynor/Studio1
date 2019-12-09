using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDectN : NodeBT
{
    public override int UpdateNode(Context context) //Detects if player can be heard or not
    {
        Debug.Log("sounddetect");
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
